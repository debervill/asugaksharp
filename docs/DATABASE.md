# Модель данных

## Обзор

База данных SQLite (`asugak.db`) содержит 10 таблиц для управления процессом защиты ВКР.

## ER-диаграмма

```
┌─────────────────┐       ┌─────────────────┐       ┌─────────────────┐
│    Kafedra      │       │ PeriodZasedania │       │       Gak       │
├─────────────────┤       ├─────────────────┤       ├─────────────────┤
│ Id (PK)         │◄──┬───│ KafedraId (FK)  │       │ Id (PK)         │
│ Name            │   │   │ Id (PK)         │◄──────│ PeriodZasedaniaId│
│ ShortName       │   │   │ Name            │       │ KafedraID (FK)  │──┐
│ Description     │   │   │ DateStart       │       │ NomerPrikaza    │  │
└─────────────────┘   │   │ DateEnd         │       │ KolvoBudget     │  │
                      │   │ Primechanie     │       │ KolvoPlatka     │  │
                      │   └─────────────────┘       └─────────────────┘  │
                      │                                     │            │
                      │                                     ▼            │
┌─────────────────┐   │   ┌─────────────────┐       ┌─────────────────┐ │
│     Person      │   │   │   Zasedanie     │       │   Diplomnik     │ │
├─────────────────┤   │   ├─────────────────┤       ├─────────────────┤ │
│ Id (PK)         │◄──┼───│ Id (PK)         │       │ Id (PK)         │ │
│ KafedraID (FK)  │───┘   │ GakID (FK)      │───────│ PersonId (FK)   │─┤
│ Name            │       │ NapravleniePodg │       │ FioImen         │ │
│ Stepen          │       │ Kvalificacia    │       │ FioRodit        │ │
│ Zvanie          │       │ Date            │       │ Sex             │ │
│ Dolgnost        │       └─────────────────┘       │ Pages           │ │
│ IsPredsed       │                                 │ Tema            │ │
│ IsZavKaf        │                                 │ OrigVkr         │ │
│ IsSecretar      │       ┌─────────────────┐       │ Srball          │ │
│ IsRecenzent     │       │      Docs       │       └─────────────────┘ │
│ IsVneshniy      │       ├─────────────────┤                           │
└─────────────────┘       │ Id (PK)         │                           │
        │                 │ PersonId (FK)   │───────────────────────────┤
        │                 │ Name            │                           │
        ▼                 │ IsUploaded      │                           │
┌─────────────────┐       │ Data            │                           │
│     Oplata      │       └─────────────────┘                           │
├─────────────────┤                                                     │
│ Id (PK)         │       ┌─────────────────┐       ┌─────────────────┐ │
│ PersonId (FK)   │───────│ NapravleniePodg │       │ ProfilPodgotovki│ │
│ Stavka          │       ├─────────────────┤       ├─────────────────┤ │
│ Ndfl            │       │ Id (PK)         │◄──────│ NapravlenieID   │ │
│ Enp             │       │ Nazvanie        │       │ Id (PK)         │ │
│ MoneySource     │       │ ShifrNapr       │       │ Name            │ │
│ DogovorNumber   │       └─────────────────┘       │ ShifrPodgot     │ │
└─────────────────┘                                 └─────────────────┘ │
                                                                        │
                                                    ◄───────────────────┘
```

## Описание сущностей

### Kafedra (Кафедра)

Базовая сущность для организационной структуры.

| Поле | Тип | Описание |
|------|-----|----------|
| Id | Guid | Первичный ключ |
| Name | string | Полное название |
| ShortName | string | Сокращённое название |
| Description | string? | Описание |

### Person (Сотрудник)

Член комиссии, руководитель, рецензент.

| Поле | Тип | Описание |
|------|-----|----------|
| Id | Guid | Первичный ключ |
| Name | string | ФИО |
| Stepen | string | Учёная степень (к.т.н., д.т.н.) |
| Zvanie | string | Учёное звание (доцент, профессор) |
| Dolgnost | string | Должность |
| IsPredsed | bool | Является председателем |
| IsZavKaf | bool | Является зав. кафедрой |
| IsSecretar | bool | Является секретарём |
| IsRecenzent | bool | Является рецензентом |
| IsVneshniy | bool | Внешний сотрудник |
| KafedraID | Guid | FK на Kafedra |

### Diplomnik (Дипломник)

Выпускник, защищающий ВКР.

| Поле | Тип | Описание |
|------|-----|----------|
| Id | Guid | Первичный ключ |
| FioImen | string | ФИО в именительном падеже |
| FioRodit | string | ФИО в родительном падеже |
| Sex | string | Пол (М/Ж) |
| Pages | int | Количество страниц ВКР |
| Tema | string | Тема ВКР |
| OrigVkr | float | Процент оригинальности |
| Srball | float | Средний балл |
| PersonId | Guid | FK на Person (руководитель) |

### Gak (Государственная Аттестационная Комиссия)

Состав комиссии для защиты.

| Поле | Тип | Описание |
|------|-----|----------|
| Id | Guid | Первичный ключ |
| NomerPrikaza | string | Номер приказа о составе |
| KolvoBudget | int | Количество бюджетных мест |
| KolvoPlatka | int | Количество платных мест |
| PeriodZasedaniaId | Guid | FK на PeriodZasedania |
| KafedraID | Guid | FK на Kafedra |

### Zasedanie (Заседание)

Отдельное заседание комиссии (день защиты).

| Поле | Тип | Описание |
|------|-----|----------|
| Id | Guid | Первичный ключ |
| NapravleniePodgotovki | string | Направление подготовки |
| Kvalificacia | string | Квалификация (бакалавр/магистр) |
| Date | DateOnly | Дата заседания |
| GakID | Guid | FK на Gak |

### PeriodZasedania (Период заседаний)

Временной период для проведения защит.

| Поле | Тип | Описание |
|------|-----|----------|
| Id | Guid | Первичный ключ |
| Name | string | Название периода |
| DateStart | DateOnly | Дата начала |
| DateEnd | DateOnly | Дата окончания |
| Primechanie | string | Примечание |
| KafedraId | Guid | FK на Kafedra |

### NapravleniePodgotovki (Направление подготовки)

Образовательное направление (09.03.01, 09.03.02, ...).

| Поле | Тип | Описание |
|------|-----|----------|
| Id | Guid | Первичный ключ |
| Nazvanie | string | Название направления |
| ShifrNapr | string | Шифр направления |

### ProfilPodgotovki (Профиль подготовки)

Профиль в рамках направления.

| Поле | Тип | Описание |
|------|-----|----------|
| Id | Guid | Первичный ключ |
| Name | string | Название профиля |
| ShifrPodgot | string | Шифр профиля |
| NapravleniePodgotovkiID | Guid | FK на NapravleniePodgotovki |

### Oplata (Оплата)

Оплата членам комиссии.

| Поле | Тип | Описание |
|------|-----|----------|
| Id | Guid | Первичный ключ |
| Stavka | float | Ставка |
| Ndfl | float | НДФЛ |
| Enp | float | ЕНП |
| MoneySource | int | Источник финансирования |
| DogovorNumber | int | Номер договора |
| PersonId | Guid | FK на Person |

### Docs (Документы)

Прикреплённые документы.

| Поле | Тип | Описание |
|------|-----|----------|
| Id | Guid | Первичный ключ |
| Name | string | Название документа |
| IsUploaded | bool | Загружен ли файл |
| Data | string | Данные/путь к файлу |
| PersonId | Guid | FK на Person |

## Связи

| Связь | Тип | Описание |
|-------|-----|----------|
| Kafedra → Person | 1:N | Сотрудники кафедры |
| Kafedra → PeriodZasedania | 1:N | Периоды защит кафедры |
| Kafedra → Gak | 1:N | Комиссии кафедры |
| PeriodZasedania → Gak | 1:N | Комиссии в периоде |
| Gak → Zasedanie | 1:N | Заседания комиссии |
| Person → Diplomnik | 1:N | Дипломники руководителя |
| Person → Oplata | 1:N | Оплаты сотруднику |
| Person → Docs | 1:N | Документы сотрудника |
| NapravleniePodgotovki → ProfilPodgotovki | 1:N | Профили направления |

## Конфигурация

Подключение к базе данных в `App.xaml.cs`:

```csharp
services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=asugak.db"));
```

Файл базы данных: `asugak.db` в корне проекта.
