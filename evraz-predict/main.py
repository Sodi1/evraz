from fastapi import FastAPI, status
from fastapi.responses import JSONResponse


import numpy as np
import pandas as pd
from scipy.optimize import curve_fit  # type: ignore
from scipy.signal import savgol_filter  # type: ignore
from darts import TimeSeries  # type: ignore
from darts.dataprocessing.transformers import Scaler  # type: ignore
from darts.metrics import rho_risk  # type: ignore
from darts.metrics import mae, mape, mse  # type: ignore
from darts.models import RNNModel, TCNModel  # type: ignore
from darts.utils.likelihood_models import QuantileRegression  # type: ignore
from darts.utils.timeseries_generation import datetime_attribute_timeseries  # type: ignore


from data_models import Record, Pack, Result
from process_data import get_data, result_to_timeseries, prepare_ts

tags_metadata = [
    {
        "name": "predict",
        "description": "Операции для получения прогноза.",
    },
    {
        "name": "settings",
        "description": "Настройка параметров точной модели прогноза.",
    },
]

app = FastAPI(
    title="Evraz Forecast",
    version="0.0.1",
    description="API для взаимодействия с моделями прогнозирования.",
    openapi_tags=tags_metadata,
    redoc_url=None)


fast_model = RNNModel.load("models/first_model")
future_days = 1


@app.get("/predict", tags=["predict"],
         summary="Быстрый прогноз",
         status_code=status.HTTP_200_OK)
async def fast(signal_id:str, start_date: str, end_date:str) -> JSONResponse:
    transformer = Scaler()
    # raw_train_data = get_data('2023-02-16', '2023-02-17', ['2859'])
    print(start_date, end_date, [signal_id])
    raw_train_data = get_data(start_date, end_date, [signal_id])
    data = result_to_timeseries(raw_train_data[0])

    train_data, val_data, covar_train_data, covar_val_data = prepare_ts(
    data,
    transformer,
    split_date='',
    future_days=future_days)

    # Создание временных ковариантов
    minutes_series = datetime_attribute_timeseries(
        pd.date_range(start=data.start_time(), freq=data.freq_str,  # type: ignore
                    periods=len(data)+future_days*1440),
        attribute="minute",
        one_hot=False,
    )
    second_series = datetime_attribute_timeseries(
        minutes_series, attribute="second", one_hot=True
    )

    # covariates = hours_series.stack(minutes_series)
    covariates = minutes_series.stack(second_series)

    covariates = Scaler().fit_transform(covariates)

    # Само прогнозирование
    pred_series = fast_model.predict(n=len(data),
                                     future_covariates=covariates)

    # Перевод в нормальную размерность
    pred_series = transformer.inverse_transform(
        pred_series).pd_dataframe()  # type: ignore

    pred_series_dict = pred_series.to_dict()
    response = {'data': []}
    for key, value in pred_series_dict['value'].items():
        response["data"].append([str(key.isoformat()), value])
        # response[str(key.isoformat())] = value

    return JSONResponse(status_code=status.HTTP_200_OK, content=response)
