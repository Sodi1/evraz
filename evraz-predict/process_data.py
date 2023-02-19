import json
from typing import List

from darts import TimeSeries
import pandas as pd
import numpy as np
from darts import TimeSeries
from darts.dataprocessing.transformers import Scaler
from darts.utils.timeseries_generation import datetime_attribute_timeseries
from datetime import datetime, timedelta
import requests
from pydantic.tools import parse_obj_as

from data_models import Record, Pack, Result


def get_data(start_time, end_time, ids) -> List[Result]:
    final_url = 'https://evraz-api.kovalev.team/api/chart_values?'
    final_url += '&'.join([f'signal_kind_ids[]={i}' for i in ids])
    final_url += f'&start_time={start_time}&end_time={end_time}&include_setpoints=1'
    # print(final_url)
    response = requests.get(final_url)
    res = parse_obj_as(Pack, response.json())
    result = []
    for i in ids:
        result.append(Result(
            signal_id=i,
            data=[
                Record(
                    date=res.charts[0][i][rec][0],
                    signal=res.charts[0][i][rec][1],
                    sv_warning_min=res.charts[0][i][rec][2],
                    sv_warning_max=res.charts[0][i][rec][3],
                    sv_alarm_min=res.charts[0][i][rec][4],
                    sv_alarm_max=res.charts[0][i][rec][5],
                ) for rec in range(len(res.charts[0][i]))
            ]
        ))

    return result


def result_to_timeseries(data: Result):
    temp = {}
    try:
        temp = {
            'date': [datetime.fromisoformat(i.date) for i in data.data],
            'value': [i.signal for i in data.data]
        }
    except KeyError:
        print('Неверно задан тип элемента.')

    df = pd.DataFrame.from_dict(temp)

    delta = df.date.max() - df.date.min()
    all_datetimes = [df.date.min() + timedelta(minutes=i)
                     for i in range(int(delta.total_seconds()/60) + 1)]

    df['date'] = pd.to_datetime(df.date).dt.tz_localize(None)
    df['date'] = df['date'].dt.floor('Min')

    res = TimeSeries.from_dataframe(
        df, time_col='date', value_cols='value', fill_missing_dates=True, freq='min')
    return res


def prepare_ts(ts: TimeSeries,
               transformer: Scaler,
               split_date: str = '2023-02-16T00:18:00.000',
               future_days: int = 10) -> tuple:
    # Создание тренировочного и валидационного датасета
    # train, val = ts.split_after(pd.Timestamp(split_date))
    train, val = ts[:-1000], ts[-1000:]

    # Нормализация
    train_transformed = transformer.fit_transform(train)
    val_transformed = transformer.transform(val)
    # series_transformed = transformer.transform(ts)

    # Создание временных ковариантов
    minutes_series = datetime_attribute_timeseries(
        pd.date_range(start=ts.start_time(), freq=ts.freq_str,  # type: ignore
                      periods=len(ts)+future_days*1440),
        attribute="minute",
        one_hot=False,
    )
    second_series = datetime_attribute_timeseries(
        minutes_series, attribute="second", one_hot=True
    )

    # covariates = hours_series.stack(minutes_series)
    covariates = minutes_series.stack(second_series)

    covariates = Scaler().fit_transform(covariates)

    cov_train, cov_val = covariates[:-1000], covariates[-1000:]

    return train_transformed, val_transformed, cov_train, cov_val
