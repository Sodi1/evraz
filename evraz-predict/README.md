# evraz-predict

Сервис прогнозирования временного ряда для определения времени выхода из строя ротора эксгаутера  агломашины.

Платформы:
|Платформа|Поддержка|
|---------|---------|
| Windows |   ✅   |
|  Linux  |   ✅   |

aarch64, Python 3.10+

### Подготовка

Нужно поставить зависимости:

```cmd
python3 -m venv env
```

```cmd
python3 env\Scripts\activate
```

```cmd
pip3 install -r requirements.txt
```

### Использование

Пример запуска:

```bash
uvicorn main:app --reload
```

Пример запроса:

```bash
curl -X 'GET' \
  'https://url.site/predict?signal_id=2859&start_date=2023-02-16&end_date=2023-02-17' \
  -H 'accept: application/json'
```

- `signal_id`: Внутренний ID компонента из панели администратора (`"2859"`)
- `start_date`: Начальная дата для продолжения прогноза (`"2023-02-16"`)
- `end_date`: Конечная дата для продолжения прогноза (`"2023-02-17"`)


Пример ответа:

```json
{
    "data": [
        [
        "2023-02-16T18:20:00",
        0.3497422250032254
        ],
        [
        "2023-02-16T18:21:00",
        0.35429708855702446
        ],
        [
        "2023-02-16T18:22:00",
        0.35911009378584624
        ],
        [
        "2023-02-16T18:23:00",
        0.36461951932019127
        ]
    ]
}
```


Документация (OpenAPI):

```bash
https://url.site/docs
```

### Запуск сервиса

Переместить файл `evraz-predict.service` в директорию `/home/USERNAME/.config/systemd/user`.

Заменить все вхождения `USERNAME` на имя пользователя.

Запуск:

```bash
systemctl --user start evraz-predict.service
```
