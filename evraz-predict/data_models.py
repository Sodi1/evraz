from typing import Dict, List, Union, Optional

from pydantic import BaseModel, Field, ValidationError, validator


class Record(BaseModel):
    date: str
    signal:float
    sv_warning_min: float
    sv_warning_max: float
    sv_alarm_min: float
    sv_alarm_max: float


class Pack(BaseModel):
    charts: List[Dict[str, List]]


class Result(BaseModel):
    signal_id: str
    data: List[Record]
