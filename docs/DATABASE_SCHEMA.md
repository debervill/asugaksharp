# Схема базы данных АСУ ГАК

## Диаграмма связей

```
┌─────────────────────────────────────────────────────────────────────────────────────────┐
│                                    СПРАВОЧНИКИ                                          │
└─────────────────────────────────────────────────────────────────────────────────────────┘

┌───────────────────────────┐     ┌───────────────────────────┐
│        Kafedra            │     │   NapravleniePodgotovki   │
├───────────────────────────┤     ├───────────────────────────┤
│ Id          GUID PK       │     │ Id          GUID PK       │
│ Name        string        │     │ Nazvanie    string        │
│ ShortName   string        │     │ ShifrNapr   string        │
│ Description string?       │     └─────────────┬─────────────┘
│ Phone       string        │                   │ 1
│ Email       string        │                   │
└───────────┬───────────────┘                   │ *
            │ 1                   ┌─────────────▼─────────────┐
            │                     │     ProfilPodgotovki      │
            │                     ├───────────────────────────┤
            │                     │ Id                 GUID PK│
            │                     │ Name               string │
            │                     │ ShifrPodgot        string │
            │                     │ NapravleniePodgotovkiID FK│
            │                     └───────────────────────────┘
            │
            │                     ┌───────────────────────────┐
            │                     │         Normativ          │
            │                     ├───────────────────────────┤
            │                     │ Id               GUID PK  │
            │                     │ RolVGek          string   │
            │                     │ StavkaZaStudenta float    │
            │                     │ NormaVremeni     float    │
            │                     │ Osnovanie        string   │
            │                     │ Kod              string   │
            │                     └───────────────────────────┘

┌─────────────────────────────────────────────────────────────────────────────────────────┐
│                                 ОСНОВНЫЕ СУЩНОСТИ                                       │
└─────────────────────────────────────────────────────────────────────────────────────────┘

            │
            │ *
┌───────────▼───────────────┐         ┌───────────────────────────┐
│          Person           │         │      PeriodZasedania      │
├───────────────────────────┤         ├───────────────────────────┤
│ Id          GUID PK       │         │ Id          GUID PK       │
│ Name        string        │         │ Name        string        │
│ Stepen      string        │         │ DateStart   DateOnly      │
│ Zvanie      string        │         │ DateEnd     DateOnly      │
│ Dolgnost    string        │         │ Primechanie string        │
│ IsPredsed   bool          │         │ KafedraId   GUID FK ──────┼──► Kafedra
│ IsZavKaf    bool          │         └─────────────┬─────────────┘
│ IsSecretar  bool          │                       │ 1
│ IsRecenzent bool          │                       │
│ IsVneshniy  bool          │                       │ *
│ KafedraID   GUID FK ──────┼──► Kafedra  ┌────────▼────────────────┐
└───────────┬───────────────┘            │           Gak            │
            │                            ├───────────────────────────┤
            │ *                          │ Id               GUID PK  │
            │                            │ NomerPrikaza     string   │
            │                            │ Osnovanie        string   │
            │                            │ DataPrikaza      DateTime │
            │                            │ KolvoBudget      int      │
            │                            │ KolvoPlatka      int      │
            │                            │ PeriodZasedaniaId GUID FK │
            │                            │ KafedraID        GUID FK ─┼──► Kafedra
            │                            └─────────────┬─────────────┘
            │                                          │ 1
            │          * ┌─────────────────────────────┤
            └────────────┤                             │ *
                         │               ┌─────────────▼─────────────┐
   Gak.Persons ──────────┘               │        Zasedanie          │
   (many-to-many)                        ├───────────────────────────┤
                                         │ Id                 GUID PK│
                                         │ NapravleniePodgotovki str │
                                         │ Kvalificacia       string │
                                         │ Date               DateOnly│
                                         │ GakID              GUID FK │
                                         └───────────┬───────────────┘
                                                     │ 1
                    ┌────────────────────────────────┼───────────────────────────────┐
                    │                                │                               │
                    │ *                              │ *                             │ *
      ┌─────────────▼─────────────┐   ┌─────────────▼─────────────┐   ┌─────────────▼─────────────┐
      │      PersonZasedanie      │   │        Diplomnik          │   │          Oplata           │
      ├───────────────────────────┤   ├───────────────────────────┤   ├───────────────────────────┤
      │ Id          GUID PK       │   │ Id          GUID PK       │   │ Id               GUID PK  │
      │ PersonId    GUID FK ──────┼─► │ FioImen     string        │   │ PersonId         GUID FK ─┼─► Person
      │ ZasedanieId GUID FK       │   │ FioRodit    string        │   │ GakId            GUID FK ─┼─► Gak
      │ RolVGek     string        │   │ Sex         string        │   │ RolVGek          string   │
      └───────────────────────────┘   │ Pages       int           │   │ KolvoBudget      int      │
               │                      │ Tema        string        │   │ KolvoPlatka      int      │
               │                      │ OrigVkr     float         │   │ Koefficient      float    │
               └──────────► Person    │ Srball      float         │   │ StoimostChasa    float    │
                                      │ PersonId    GUID FK ──────┼─► │ StoimostAkademChasaSNalogami float │
                                      │ ZasedanieId GUID FK       │   │ ObshayaStoimostUslugPoDogovoru float │
                                      └───────────────────────────┘   │ AkademChasov     float    │
                                               │                      │ AstronomChasov   float    │
                                               └──────────► Person    │ SummaBezNalogov  float    │
                                                                      │ NdflProc         float    │
                                                                      │ NdflSumma        float    │
                                                                      │ EnpProc          float    │
                                                                      │ EnpSumma         float    │
                                                                      │ SummaKVyplate    float    │
                                                                      │ SummaSNalogami   float    │
                                                                      │ TotalNachisleno  float    │
                                                                      │ TotalNdfl        float    │
                                                                      │ TotalEnp         float    │
                                                                      │ TotalKVyplate    float    │
                                                                      │ DogovorNumber    int      │
                                                                      │ MoneySource      int      │
      ┌───────────────────────────┐                                   │ DataRascheta     DateTime │
      │           Docs            │                                   │ IsDogovorGenerated bool   │
      ├───────────────────────────┤                                   └───────────────────────────┘
      │ Id          GUID PK       │
      │ Name        string        │
      │ IsUploaded  bool          │
      │ Data        string        │
      │ PersonId    GUID FK ──────┼──► Person
      └───────────────────────────┘
```

---

## Описание таблиц

### Kafedra — Кафедра

| Поле | Тип | Описание |
|------|-----|----------|
| Id | GUID | Первичный ключ |
| Name | string | Полное название кафедры |
| ShortName | string | Сокращённое название |
| Description | string? | Описание |
| Phone | string | Телефон |
| Email | string | Email |

---

### Person — Персона (сотрудник/рецензент)

| Поле | Тип | Описание |
|------|-----|----------|
| Id | GUID | Первичный ключ |
| Name | string | ФИО |
| Stepen | string | Учёная степень |
| Zvanie | string | Учёное звание |
| Dolgnost | string | Должность |
| IsPredsed | bool | Является председателем |
| IsZavKaf | bool | Является зав. кафедрой |
| IsSecretar | bool | Является секретарём |
| IsRecenzent | bool | Является рецензентом |
| IsVneshniy | bool | Внешний сотрудник |
| KafedraID | GUID FK | Ссылка на кафедру |

---

### NapravleniePodgotovki — Направление подготовки

| Поле | Тип | Описание |
|------|-----|----------|
| Id | GUID | Первичный ключ |
| Nazvanie | string | Название направления |
| ShifrNapr | string | Шифр направления |

---

### ProfilPodgotovki — Профиль подготовки

| Поле | Тип | Описание |
|------|-----|----------|
| Id | GUID | Первичный ключ |
| Name | string | Название профиля |
| ShifrPodgot | string | Шифр профиля |
| NapravleniePodgotovkiID | GUID FK | Ссылка на направление |

---

### PeriodZasedania — Период заседаний

| Поле | Тип | Описание |
|------|-----|----------|
| Id | GUID | Первичный ключ |
| Name | string | Название периода |
| DateStart | DateOnly | Дата начала |
| DateEnd | DateOnly | Дата окончания |
| Primechanie | string | Примечание |
| KafedraId | GUID FK | Ссылка на кафедру |

---

### Gak — Государственная аттестационная комиссия

| Поле | Тип | Описание |
|------|-----|----------|
| Id | GUID | Первичный ключ |
| NomerPrikaza | string | Номер приказа |
| Osnovanie | string | Основание (приказ) |
| DataPrikaza | DateTime | Дата приказа |
| KolvoBudget | int | Кол-во бюджетных мест |
| KolvoPlatka | int | Кол-во платных мест |
| PeriodZasedaniaId | GUID FK | Ссылка на период |
| KafedraID | GUID FK | Ссылка на кафедру |

---

### Zasedanie — Заседание ГАК

| Поле | Тип | Описание |
|------|-----|----------|
| Id | GUID | Первичный ключ |
| NapravleniePodgotovki | string | Направление подготовки |
| Kvalificacia | string | Квалификация |
| Date | DateOnly | Дата заседания |
| GakID | GUID FK | Ссылка на ГАК |

---

### PersonZasedanie — Связь Персона-Заседание (many-to-many)

| Поле | Тип | Описание |
|------|-----|----------|
| Id | GUID | Первичный ключ |
| PersonId | GUID FK | Ссылка на персону |
| ZasedanieId | GUID FK | Ссылка на заседание |
| RolVGek | string | Роль на заседании (Председатель/Секретарь/Член) |

---

### Diplomnik — Дипломник

| Поле | Тип | Описание |
|------|-----|----------|
| Id | GUID | Первичный ключ |
| FioImen | string | ФИО (именительный падеж) |
| FioRodit | string | ФИО (родительный падеж) |
| Sex | string | Пол |
| Pages | int | Кол-во страниц ВКР |
| Tema | string | Тема ВКР |
| OrigVkr | float | Оригинальность ВКР (%) |
| Srball | float | Средний балл |
| PersonId | GUID FK | Научный руководитель |
| ZasedanieId | GUID FK | Ссылка на заседание |

---

### Oplata — Оплата членам комиссии

| Поле                               | Тип       | Описание                               |
|------------------------------------|-----------|----------------------------------------|
| Id                                 | GUID      | Первичный ключ                         |
| PersonId                           | GUID FK   | Ссылка на персону                      |
| GakId                              | GUID FK   | Ссылка на ГАК                          |
| RolVGek                            | string    | Роль в ГЭК                             |
| KolvoBudget                        | int       | Количество бюджетных студентов         |
| KolvoPlatka                        | int       | Количество платных студентов           |
| Koefficient                        | float     | Коэффициент                            |
| StoimostChasa                      | float     | Стоимость часа                         |
| StoimostAkademChasaSNalogami       | float     | Стоимость акад. часа с налогами (x1.3) |
| ObshayaStoimostUslugPoDogovoru     | float     | Общая стоимость услуг по договору      |
| AkademChasov                       | float     | Академические часы                     |
| AstronomChasov                     | float     | Астрономические часы                   |
| SummaBezNalogov                    | float     | Сумма без налогов                      |
| NdflProc                           | float     | Процент НДФЛ                           |
| NdflSumma                          | float     | Сумма НДФЛ                             |
| EnpProc                            | float     | Процент ЕНП                            |
| EnpSumma                           | float     | Сумма ЕНП                              |
| SummaKVyplate                      | float     | К выплате (на руки)                    |
| SummaSNalogami                     | float     | Полная стоимость                       |
| TotalNachisleno                    | float     | Итог: начислено по ГАК                 |
| TotalNdfl                          | float     | Итог: НДФЛ по ГАК                      |
| TotalEnp                           | float     | Итог: ЕНП по ГАК                       |
| TotalKVyplate                      | float     | Итог: к выплате по ГАК                 |
| DogovorNumber                      | int       | Номер договора                         |
| MoneySource                        | int       | Источник финансирования                |
| DataRascheta                       | DateTime  | Дата расчёта                           |
| IsDogovorGenerated                 | bool      | Договор сгенерирован                   |

---

### Normativ — Нормативы оплаты

| Поле | Тип | Описание |
|------|-----|----------|
| Id | GUID | Первичный ключ |
| RolVGek | string | Роль в ГЭК |
| StavkaZaStudenta | float | Ставка за студента (руб) |
| NormaVremeni | float | Норма времени (часов) |
| Osnovanie | string | Основание (приказ) |
| Kod | string | Код основания |

---

### Docs — Документы

| Поле | Тип | Описание |
|------|-----|----------|
| Id | GUID | Первичный ключ |
| Name | string | Название документа |
| IsUploaded | bool | Загружен ли |
| Data | string | Данные/путь к файлу |
| PersonId | GUID FK | Ссылка на персону |

---

## Связи между таблицами

| Связь | Тип | Описание |
|-------|-----|----------|
| Kafedra → Person | 1:N | У кафедры много сотрудников |
| Kafedra → PeriodZasedania | 1:N | У кафедры много периодов |
| Kafedra → Gak | 1:N | У кафедры много ГАК |
| PeriodZasedania → Gak | 1:N | В периоде много ГАК |
| Gak → Zasedanie | 1:N | В ГАК много заседаний |
| Gak ↔ Person | N:M | Персоны в составе ГАК |
| Zasedanie ↔ Person | N:M | Через PersonZasedanie (с ролью) |
| Zasedanie → Diplomnik | 1:N | На заседании много дипломников |
| Zasedanie → Oplata | 1:N | На заседании много оплат |
| Person → Diplomnik | 1:N | Руководитель у дипломников |
| Person → Docs | 1:N | У персоны много документов |
| Person → Oplata | 1:N | У персоны много оплат |
| NapravleniePodgotovki → ProfilPodgotovki | 1:N | У направления много профилей |
