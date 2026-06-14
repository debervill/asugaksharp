---
name: pdf-protocol-fields
description: AcroForm field names in PDF protocol templates (Templates/-Протокол .pdf and -Протокол квалификация .pdf) mapped to Diplomnik entity properties, with full data source chains
metadata: 
  node_type: memory
  type: reference
  originSessionId: 185ae60c-0211-44c1-a891-25a4b261caac
---

Field names were discovered via iText7 AcroForm inspection (PdfName.TU gives the alt/tooltip name per field).
See `Features/Protocol/GenerateProtocolHandler.cs` for implementation, `Features/Protocol/DiagnoseTemplatesHandler.cs` to re-inspect.

---

## Граф загрузки данных (EF Core Include)

`GenerateProtocolHandler` загружает одного `Diplomnik` через:

```csharp
_context.Diplomnik
    .Include(x => x.Person)                                         // руководитель
    .Include(x => x.ProfilPodgotovki)
        .ThenInclude(p => p.NapravleniePodgotovki)                  // направление
    .Include(x => x.Konsultanty).ThenInclude(k => k.Person)        // консультанты
    .Include(x => x.Retsenzenty).ThenInclude(r => r.Person)        // рецензенты
    .Include(x => x.Zasedanie).ThenInclude(z => z.Gak)
        .ThenInclude(g => g.Predsedatel)                            // председатель
    .Include(x => x.Zasedanie).ThenInclude(z => z.Gak)
        .ThenInclude(g => g.Sekretar)                               // секретарь
    .Include(x => x.Zasedanie).ThenInclude(z => z.Gak)
        .ThenInclude(g => g.Persons)                                // члены комиссии
    .FirstOrDefaultAsync(x => x.Id == diplomnikId)
```

---

## Вспомогательные методы

| Метод | Сигнатура | Назначение |
|-------|-----------|------------|
| `RussianMonth(int)` | `string` | Номер месяца → родительный падеж ("января", "февраля"…) |
| `ShortName(string)` | `string` | "Иванов Иван Иванович" → "Иванов И.И." |
| `SplitToLines(string, int maxChars, int count)` | `string[]` | Разбивает текст по словам на `count` строк по `maxChars` символов |
| `SplitAtWidth(string, int maxChars)` | `(first, rest)` | Первая часть ≤ `maxChars` символов, остаток — в `rest` |

---

## -Протокол .pdf

### Дата заседания (y≈686)

| Поле | Alt | Значение | Источник |
|------|-----|----------|----------|
| `undefined` | — | день | `Diplomnik.Zasedanie.Date.Day` → `DateOnly.Day.ToString()` |
| `undefined_2` | — | месяц | `RussianMonth(Diplomnik.Zasedanie.Date.Month)` |
| `undefined_3` | — | год | `Diplomnik.Zasedanie.Date.Year.ToString()` |
| `fill_5` | "г. с" | час начала | **нет в модели** — заполняется вручную |
| `fill_6` | "ч" | мин начала | **нет в модели** — заполняется вручную |
| `fill_7` | "мин. до" | час конца | **нет в модели** — заполняется вручную |
| `fill_8` | "ч" | мин конца | **нет в модели** — заполняется вручную |

### Студент (y≈608–553)

| Поле | Alt | Значение | Источник |
|------|-----|----------|----------|
| `fill_10` | "Обучающийся" | ФИО в именительном | `Diplomnik.FioImen` (строка, хранится в БД) |
| `fill_9` | "Вид ВКР" | вид работы | `Diplomnik.VidVkr` (строка, напр. "бакалаврская работа") |
| `fill_11` | "Направление подготовки" | название направления | `Diplomnik.ProfilPodgotovki.NapravleniePodgotovki.Nazvanie` |
| `fill_12` | "Профиль/специализация" | первая часть профиля | `SplitAtWidth(Diplomnik.ProfilPodgotovki.Name, 45).first` — влезает ~45 симв. |

### Тема ВКР (y≈504–456)

| Поле | Alt | Значение | Источник |
|------|-----|----------|----------|
| `Text1` | — | остаток профиля | `SplitAtWidth(ProfilPodgotovki.Name, 45).rest` — то, что не влезло в fill_12 |
| `Text2` | — | тема, строка 1 | `SplitToLines(Diplomnik.Tema, 80, 3)[0]` |
| `Text3` | — | тема, строка 2 | `SplitToLines(Diplomnik.Tema, 80, 3)[1]` |
| `Text4` | — | тема, строка 3 | `SplitToLines(Diplomnik.Tema, 80, 3)[2]` |
| `Text5` | — | — | **не заполняется** (назначение неизвестно) |

> `fill_12` (ширина 285 pt) вмещает ≈45 символов; `Text1` (511 pt) принимает остаток.

### Вопросы на защите (заполняются вручную)

| Поля | Alt | Примечание |
|------|-----|------------|
| `fill_2`, `fill_5_2`, `fill_8_2` | "краткое содержание вопроса" | вручную |
| `fill_3`, `fill_6_2`, `fill_9_2` | "ФИО лица, задавшего вопрос" | вручную |
| `fill_4`, `fill_7_2`, `fill_10_2` | "Характеристика ответа" | вручную |
| `fill_1_2` | "После сообщения… в течении" | время доклада — вручную |

### Руководитель / Консультанты / Рецензенты (y≈433–362)

| Поле | Alt | Значение | Источник |
|------|-----|----------|----------|
| `fill_13` | "Руководитель" | ФИО руководителя | `Diplomnik.Person.Name` (`Person` — FK `PersonId` в `Diplomnik`) |
| `fill_14` | "Консультант(ы)" | перечисление через ", " | `string.Join(", ", Diplomnik.Konsultanty.OrderBy(k=>k.SortOrder).Select(k=>k.Person.Name))` |
| `fill_15` | "Рецензент(ы)" | перечисление через ", " | `string.Join(", ", Diplomnik.Retsenzenty.OrderBy(r=>r.SortOrder).Select(r=>r.Person.Name))` |

> `DiplomnikKonsultant` / `DiplomnikRetsenzent` — связующие таблицы с полем `SortOrder` для сортировки.

### Комиссия ГЭК (y≈305–228)

| Поле | Alt | Значение | Источник |
|------|-----|----------|----------|
| `fill_16` | "Председатель ГЭК" | полное ФИО | `Diplomnik.Zasedanie.Gak.Predsedatel.Name` |
| `fill_17` | "Члены комиссии [1]" | ФИО | `members[0]` |
| `fill_18` | "Члены комиссии [2]" | ФИО | `members[1]` |
| `fill_19` | "Члены комиссии [3]" | ФИО | `members[2]` |
| `fill_20` | "Члены комиссии [4]" | ФИО | `members[3]` |

> `members` = `Gak.Persons.Where(p => p.Id != Gak.PredsedatelId && p.Id != Gak.SekretarId).Select(p => p.Name)`

### Решение и подписи (y≈284–70)

| Поле | Alt | Значение | Источник |
|------|-----|----------|----------|
| `fill_16_2` | "Признать… с оценкой" | оценка | `Diplomnik.Otsenka` (строка, напр. "отлично") |
| `fill_17_2` | "ФИО" | краткое ФИО председателя | `ShortName(Gak.Predsedatel.Name)` |
| `fill_18_2` | "подпись председателя" | краткое ФИО | `ShortName(Gak.Predsedatel.Name)` |
| `fill_19_2` | "ФИО секретаря" | краткое ФИО | `ShortName(Gak.Sekretar.Name)` |
| `fill_20_2` | "подпись" | — | **не заполняется** |

### Объём ВКР (y≈164–70)

| Поле | Alt | Значение | Источник |
|------|-----|----------|----------|
| `fill_21` | "расчётно-пояснительная записка на" | кол-во страниц | `Diplomnik.Pages.ToString()` (nullable `int?`) |
| `fill_22` | "чертежи (таблицы) к работе на" | — | **нет в модели** |
| `fill_23` | "рецензия по работе" | — | **нет в модели** |
| `fill_24` | "ВКР [1]" | — | **нет в модели** |
| `fill_25` | "ВКР [2]" | — | **нет в модели** |
| `fill_26` | "ВКР [3]" | — | **нет в модели** |

### Прочее (заголовок, y≈773–686)

| Поле | Alt | Значение | Источник |
|------|-----|----------|----------|
| `fill_1` | "Протокол №" | номер протокола | вычисляется — см. правило ниже |

---

## -Протокол квалификация .pdf

### Дата (Text6–Text8)

| Поле | Значение | Источник |
|------|----------|----------|
| `Text6` | день | `Diplomnik.Zasedanie.Date.Day.ToString()` |
| `Text7` | месяц | `RussianMonth(Diplomnik.Zasedanie.Date.Month)` |
| `Text8` | год | `Diplomnik.Zasedanie.Date.Year.ToString()` |

### Студент и ВКР (Text9–Text13)

| Поле | Значение | Источник |
|------|----------|----------|
| `Text9` | ФИО студента | `Diplomnik.FioImen` |
| `Text10` | направление подготовки | `Diplomnik.ProfilPodgotovki.NapravleniePodgotovki.Nazvanie` |
| `Text11` | профиль/специализация (начало) | `SplitAtWidth(ProfilPodgotovki.Name, 45).first` |
| `Text12` | профиль/специализация (продолжение) | `SplitAtWidth(ProfilPodgotovki.Name, 45).rest` — если не вместилось в Text11 |
| `Text13` | вид ВКР | `Diplomnik.VidVkr` |

### Комиссия (Text14–Text18)

Все члены комиссии (председатель + члены) перечисляются через ", " в полной форме (ФИО целиком).
Если строка не вмещается (~65 символов), остаток переносится на следующее поле.

| Поле | Значение | Источник |
|------|----------|----------|
| `Text14` | строка 1 | `SplitCommissionToLines([predsedatel, ...members], 65, 5)[0]` |
| `Text15` | строка 2 | `...[1]` |
| `Text16` | строка 3 | `...[2]` |
| `Text17` | строка 4 | `...[3]` |
| `Text18` | строка 5 | `...[4]` |

> `SplitCommissionToLines` — вспомогательный метод в `GenerateProtocolHandler`: раскладывает список имён по строкам с разделителем ", ", при переполнении начинает новую строку.

### Решение (Text19–Text21)

| Поле | Значение | Источник |
|------|----------|----------|
| `Text19` | ФИО в родительном падеже | `Diplomnik.FioRodit` ("выдать диплом [кому]") |
| `Text20` | оценка | `Diplomnik.Otsenka` |
| `Text21` | квалификация | `Diplomnik.Zasedanie.Kvalificacia` (строка из `Zasedanie`) |

### Подписи

| Поле | Alt | Значение | Источник |
|------|-----|----------|----------|
| `fill_2` | "ФИО" | краткое ФИО председателя | `ShortName(Gak.Predsedatel.Name)` |
| `fill_4` | "ФИО" | краткое ФИО секретаря | `ShortName(Gak.Sekretar.Name)` |

---

## Правила вычисления полей

### Номер протокола (`fill_1` в -Протокол .pdf)

**Правило:** сквозная нумерация в рамках одного ГАК, независимо от количества дней заседаний.

**Алгоритм:**
1. Взять все `Zasedanie` текущего ГАК (`Diplomnik.Zasedanie.GakID`), отсортировать по `Date` ascending.
2. Для каждого заседания взять список дипломников в порядке их записи (или по отдельному полю порядка, если появится).
3. Пронумеровать дипломников сквозно: первый дипломник первого дня — №1, последний дипломник последнего дня — №N.
4. Номер протокола конкретного дипломника = его порядковый номер в этом сквозном списке.

**Что нужно для реализации:** при загрузке данных выполнить запрос по всем дипломникам ГАКа, выстроить их в порядке (дата заседания → порядок внутри заседания), вычислить индекс текущего дипломника и передать в `fill_1`.

---

## Поля без источника в модели (требуют доработки)

| Шаблон | Поля | Что нужно добавить |
|--------|------|--------------------|
| -Протокол .pdf | `fill_5..fill_8` | Время начала/конца заседания → добавить `Zasedanie.TimeStart` / `TimeEnd` |
| -Протокол .pdf | `fill_1` (Протокол №) | Номер вычисляется сквозно по ГАКу — правило описано выше, реализация в `GenerateProtocolHandler` отсутствует |
| -Протокол .pdf | `fill_22..fill_26` | Объём чертежей, подписи за ВКР → добавить поля в `Diplomnik` |
