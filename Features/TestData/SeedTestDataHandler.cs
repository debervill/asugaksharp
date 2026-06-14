using System.Globalization;
using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;
using E = asugaksharp.Core.Entities;

namespace asugaksharp.Features.TestData;

public sealed record SeedTestDataResult(
    int KafedraAdded,
    int PersonsAdded,
    int DiplomnikAdded,
    bool AlreadyExists);

public sealed class SeedTestDataHandler
{
    private const string Marker = "TEST_DATA";
    private readonly AppDbContext _context;

    public SeedTestDataHandler(AppDbContext context) => _context = context;

    public async Task<SeedTestDataResult> ExecuteAsync(CancellationToken ct = default)
    {
        if (await _context.Kafedra.AnyAsync(k => k.Description == Marker, ct) &&
            await _context.Diplomnik.AnyAsync(d => d.FioImen == "Бодря Даниил Ионович", ct))
            return new SeedTestDataResult(0, 0, 0, true);

        // ── 1. Кафедры и сотрудники ──────────────────────────────────────
        int personsAdded = 0, globalIdx = 0;
        var kafedras = new Dictionary<string, (E.Kafedra kaf, List<E.Person> people)>();

        if (!await _context.Kafedra.AnyAsync(k => k.Description == Marker, ct))
        {
            foreach (var ks in KafedraSeeds())
            {
                var kaf = new E.Kafedra { Id = Guid.NewGuid(), Name = ks.Name, ShortName = ks.Short,
                    Description = Marker, Phone = ks.Phone, Email = ks.Email };
                _context.Kafedra.Add(kaf);
                var people = new List<E.Person>();
                foreach (var ps in ks.Persons)
                {
                    var p = MakePerson(kaf.Id, ks.City, ps, ++globalIdx);
                    _context.Person.Add(p); people.Add(p); personsAdded++;
                }
                kafedras[ks.Short] = (kaf, people);
            }
            await _context.SaveChangesAsync(ct);
        }
        else
        {
            // Уже есть — загрузим для переиспользования
            foreach (var kaf in await _context.Kafedra.Where(k => k.Description == Marker).ToListAsync(ct))
            {
                var people = await _context.Person.Where(p => p.KafedraID == kaf.Id).ToListAsync(ct);
                kafedras[kaf.ShortName] = (kaf, people);
            }
        }

        if (await _context.Diplomnik.AnyAsync(d => d.FioImen == "Бодря Даниил Ионович", ct))
            return new SeedTestDataResult(kafedras.Count, personsAdded, 0, false);

        // ── 2. Направления и профили ──────────────────────────────────────
        var napPI = new E.NapravleniePodgotovki { Id = Guid.NewGuid(), ShifrNapr = "09.03.04", Nazvanie = "Программная инженерия" };
        var napEU = new E.NapravleniePodgotovki { Id = Guid.NewGuid(), ShifrNapr = "38.03.01", Nazvanie = "Экономика" };
        var napMM = new E.NapravleniePodgotovki { Id = Guid.NewGuid(), ShifrNapr = "01.03.01", Nazvanie = "Математика" };
        _context.NapravleniePodgotovki.AddRange(napPI, napEU, napMM);

        var profPO = new E.ProfilPodgotovki { Id = Guid.NewGuid(), Name = "Разработка программного обеспечения", NapravleniePodgotovkiID = napPI.Id };
        var profIS = new E.ProfilPodgotovki { Id = Guid.NewGuid(), Name = "Информационные системы",              NapravleniePodgotovkiID = napPI.Id };
        var profEU = new E.ProfilPodgotovki { Id = Guid.NewGuid(), Name = "Экономика и управление предприятием", NapravleniePodgotovkiID = napEU.Id };
        var profMM = new E.ProfilPodgotovki { Id = Guid.NewGuid(), Name = "Математическое моделирование",        NapravleniePodgotovkiID = napMM.Id };
        _context.ProfilPodgotovki.AddRange(profPO, profIS, profEU, profMM);

        // ── 3. Периоды и ГАК ──────────────────────────────────────────────
        var (kafKPI, peopleKPI) = kafedras["КПИ"];
        var (kafKEU, peopleKEU) = kafedras["КЭУ"];
        var (kafKMS, peopleKMS) = kafedras["КМС"];

        var periodKPI = new E.PeriodZasedania { Id = Guid.NewGuid(), Name = "ГАК КПИ 2024",
            DateStart = new DateOnly(2024, 6, 1), DateEnd = new DateOnly(2024, 7, 31), KafedraId = kafKPI.Id };
        var periodKEU = new E.PeriodZasedania { Id = Guid.NewGuid(), Name = "ГАК КЭУ 2024",
            DateStart = new DateOnly(2024, 6, 5), DateEnd = new DateOnly(2024, 7, 20), KafedraId = kafKEU.Id };
        _context.PeriodZasedania.AddRange(periodKPI, periodKEU);

        E.Person KPI(Predicate<E.Person> pred) => peopleKPI.First(p => pred(p));
        E.Person KEU(Predicate<E.Person> pred) => peopleKEU.First(p => pred(p));

        var gakKPI = new E.Gak { Id = Guid.NewGuid(), NomerPrikaza = "1156-ОД",
            Osnovanie = "Приказ ВПО №1156 от 15.12.2023", DataPrikaza = new DateTime(2023,12,15),
            KolvoBudget = 10, KolvoPlatka = 5,
            PeriodZasedaniaId = periodKPI.Id, KafedraID = kafKPI.Id,
            PredsedatelId = KPI(p => p.IsZavKaf).Id, SekretarId = KPI(p => p.IsSecretar).Id,
            Persons = peopleKPI.Where(p => !p.IsZavKaf && !p.IsSecretar).Take(4).ToList() };

        var gakKEU = new E.Gak { Id = Guid.NewGuid(), NomerPrikaza = "0842-ОД",
            Osnovanie = "Приказ ВПО №842 от 10.11.2023", DataPrikaza = new DateTime(2023,11,10),
            KolvoBudget = 8, KolvoPlatka = 3,
            PeriodZasedaniaId = periodKEU.Id, KafedraID = kafKEU.Id,
            PredsedatelId = KEU(p => p.IsZavKaf).Id, SekretarId = KEU(p => p.IsSecretar).Id,
            Persons = peopleKEU.Where(p => !p.IsZavKaf && !p.IsSecretar).Take(4).ToList() };

        _context.Gak.AddRange(gakKPI, gakKEU);

        // ── 4. Заседания ──────────────────────────────────────────────────
        var zasPI1 = new E.Zasedanie { Id = Guid.NewGuid(), NapravleniePodgotovki = napPI.Nazvanie,
            Kvalificacia = "Бакалавр", Date = new DateOnly(2024, 6, 20), GakID = gakKPI.Id };
        var zasPI2 = new E.Zasedanie { Id = Guid.NewGuid(), NapravleniePodgotovki = napPI.Nazvanie,
            Kvalificacia = "Магистр",  Date = new DateOnly(2024, 6, 25), GakID = gakKPI.Id };
        var zasEU  = new E.Zasedanie { Id = Guid.NewGuid(), NapravleniePodgotovki = napEU.Nazvanie,
            Kvalificacia = "Бакалавр", Date = new DateOnly(2024, 6, 18), GakID = gakKEU.Id };
        _context.Zasedanie.AddRange(zasPI1, zasPI2, zasEU);

        await _context.SaveChangesAsync(ct);

        // ── 5. Дипломники ─────────────────────────────────────────────────
        var recKPI  = KPI(p => p.IsRecenzent);
        var rukKPI  = peopleKPI.First(p => !p.IsZavKaf && !p.IsSecretar && !p.IsRecenzent);
        var recKEU  = KEU(p => p.IsRecenzent);
        var rukKEU  = peopleKEU.First(p => !p.IsZavKaf && !p.IsSecretar && !p.IsRecenzent);

        var diplomniks = new[]
        {
            new E.Diplomnik { Id = Guid.NewGuid(), FioImen = "Бодря Даниил Ионович",       FioRodit = "Бодря Даниила Ионовича",
                Sex = "М", Pages = 85, Tema = "Разработка автоматизированной системы управления учебным процессом",
                OrigVkr = 78.5f, Srball = 4.7f, Otsenka = "отлично",     VidVkr = "бакалаврская работа",
                PersonId = rukKPI.Id, ProfilPodgotovkiId = profPO.Id, ZasedanieId = zasPI1.Id },

            new E.Diplomnik { Id = Guid.NewGuid(), FioImen = "Петрова Ксения Алексеевна",  FioRodit = "Петровой Ксении Алексеевны",
                Sex = "Ж", Pages = 92, Tema = "Методы машинного обучения для анализа временных рядов финансовых показателей",
                OrigVkr = 82.0f, Srball = 4.5f, Otsenka = "хорошо",      VidVkr = "магистерская диссертация",
                PersonId = rukKPI.Id, ProfilPodgotovkiId = profIS.Id,  ZasedanieId = zasPI2.Id },

            new E.Diplomnik { Id = Guid.NewGuid(), FioImen = "Захаров Артём Сергеевич",    FioRodit = "Захарова Артёма Сергеевича",
                Sex = "М", Pages = 74, Tema = "Оптимизация цепочки поставок на основе математических методов",
                OrigVkr = 71.3f, Srball = 3.9f, Otsenka = "удовлетворительно", VidVkr = "бакалаврская работа",
                PersonId = rukKEU.Id, ProfilPodgotovkiId = profEU.Id, ZasedanieId = zasEU.Id },

            new E.Diplomnik { Id = Guid.NewGuid(), FioImen = "Малинина Виктория Павловна",  FioRodit = "Малининой Виктории Павловны",
                Sex = "Ж", Pages = 88, Tema = "Информационная система учёта и анализа кадрового состава предприятия",
                OrigVkr = 85.1f, Srball = 4.8f, Otsenka = "отлично",     VidVkr = "бакалаврская работа",
                PersonId = rukKPI.Id, ProfilPodgotovkiId = profIS.Id,  ZasedanieId = zasPI1.Id },

            new E.Diplomnik { Id = Guid.NewGuid(), FioImen = "Громов Илья Дмитриевич",     FioRodit = "Громова Ильи Дмитриевича",
                Sex = "М", Pages = 109, Tema = "Разработка микросервисной архитектуры для системы электронного документооборота",
                OrigVkr = 90.2f, Srball = 5.0f, Otsenka = "отлично",     VidVkr = "магистерская диссертация",
                PersonId = rukKPI.Id, ProfilPodgotovkiId = profPO.Id, ZasedanieId = zasPI2.Id },
        };

        _context.Diplomnik.AddRange(diplomniks);
        await _context.SaveChangesAsync(ct);

        // Рецензенты
        var retsenzenty = new[]
        {
            new E.DiplomnikRetsenzent { Id = Guid.NewGuid(), DiplomnikId = diplomniks[0].Id, PersonId = recKPI.Id, SortOrder = 1 },
            new E.DiplomnikRetsenzent { Id = Guid.NewGuid(), DiplomnikId = diplomniks[1].Id, PersonId = recKPI.Id, SortOrder = 1 },
            new E.DiplomnikRetsenzent { Id = Guid.NewGuid(), DiplomnikId = diplomniks[2].Id, PersonId = recKEU.Id, SortOrder = 1 },
            new E.DiplomnikRetsenzent { Id = Guid.NewGuid(), DiplomnikId = diplomniks[3].Id, PersonId = recKPI.Id, SortOrder = 1 },
            new E.DiplomnikRetsenzent { Id = Guid.NewGuid(), DiplomnikId = diplomniks[4].Id, PersonId = recKPI.Id, SortOrder = 1 },
        };
        _context.DiplomnikRetsenzent.AddRange(retsenzenty);

        // Консультанты (для части дипломников)
        var konsultant1 = peopleKPI.Skip(3).FirstOrDefault();
        if (konsultant1 != null)
        {
            _context.DiplomnikKonsultant.AddRange(
                new E.DiplomnikKonsultant { Id = Guid.NewGuid(), DiplomnikId = diplomniks[0].Id, PersonId = konsultant1.Id, SortOrder = 1 },
                new E.DiplomnikKonsultant { Id = Guid.NewGuid(), DiplomnikId = diplomniks[4].Id, PersonId = konsultant1.Id, SortOrder = 1 }
            );
        }

        await _context.SaveChangesAsync(ct);

        return new SeedTestDataResult(kafedras.Count, personsAdded, diplomniks.Length, false);
    }

    // ── Вспомогательные ───────────────────────────────────────────────────

    private static Core.Entities.Person MakePerson(Guid kafedraId, string city, PS s, int i)
    {
        var snilsBase = 112233440 + (i * 13);
        return new Core.Entities.Person
        {
            Id = Guid.NewGuid(), Name = s.Name, Stepen = s.Stepen, Zvanie = s.Zvanie, Dolgnost = s.Dolgnost,
            IsPredsed = s.IsPredsed, IsZavKaf = s.IsZavKaf, IsSecretar = s.IsSecretar,
            IsRecenzent = s.IsRecenzent, IsVneshniy = s.IsVneshniy,
            PassportSeria    = (5400 + i).ToString("0000", CultureInfo.InvariantCulture),
            PassportNomer    = (100000 + i).ToString("000000", CultureInfo.InvariantCulture),
            PassportIssuedBy = $"УМВД России по г. {city}",
            RegistrationAddress = $"г. {city}, ул. Советская, д. {10 + i % 40}, кв. {1 + i % 80}",
            Snils = FormatSnils(snilsBase, (i * 7) % 100),
            Inn   = (540100000000L + i).ToString("000000000000", CultureInfo.InvariantCulture),
            Email = $"person{i}@example.ru",
            Phone = $"+7 (913) 55{i % 10}-{(i * 3) % 90:00}-{(i * 7) % 90:00}",
            KafedraID = kafedraId
        };
    }

    private static string FormatSnils(int b, int s)
    {
        var r = Math.Abs(b) % 1_000_000_000;
        return $"{r / 1_000_000:000}-{r / 1_000 % 1_000:000}-{r % 1_000:000} {s:00}";
    }

    private static List<KS> KafedraSeeds() => new()
    {
        new("Кафедра прикладной информатики",  "КПИ", "8 (383) 200-11-22",  "kpi@example.ru", "Новосибирск", new[]
        {
            new PS("Иванов Иван Петрович",       "д.т.н.",    "профессор", "заведующий кафедрой",    IsZavKaf: true),
            new PS("Петрова Анна Сергеевна",     "к.т.н.",    "доцент",    "доцент",                 IsSecretar: true),
            new PS("Сидоров Николай Андреевич",  "к.т.н.",    "доцент",    "старший преподаватель",  IsRecenzent: true),
            new PS("Кузнецова Мария Игоревна",   "к.ф.-м.н.", "доцент",    "преподаватель"),
            new PS("Орлов Дмитрий Олегович",     "к.т.н.",    "доцент",    "старший преподаватель"),
            new PS("Волкова Елена Викторовна",   "к.т.н.",    "доцент",    "ассистент"),
        }),
        new("Кафедра экономики и управления",  "КЭУ", "8 (3812) 55-66-77", "keu@example.ru", "Омск", new[]
        {
            new PS("Смирнов Алексей Николаевич",  "д.э.н.", "профессор", "заведующий кафедрой",         IsZavKaf: true),
            new PS("Фёдорова Ольга Павловна",     "к.э.н.", "доцент",    "заместитель заведующего",     IsSecretar: true),
            new PS("Захарова Ирина Владимировна", "к.э.н.", "доцент",    "доцент",                      IsRecenzent: true),
            new PS("Попов Андрей Евгеньевич",     "к.э.н.", "доцент",    "старший преподаватель"),
            new PS("Морозова Татьяна Юрьевна",   "к.э.н.", "доцент",    "преподаватель"),
            new PS("Громов Сергей Валерьевич",   "к.э.н.", "доцент",    "ассистент"),
            new PS("Лебедев Павел Дмитриевич",   "к.э.н.", "доцент",    "преподаватель"),
        }),
        new("Кафедра математики и статистики", "КМС", "8 (3822) 44-55-66", "kms@example.ru", "Томск", new[]
        {
            new PS("Павлов Юрий Степанович",       "д.ф.-м.н.", "профессор", "заведующий кафедрой",   IsZavKaf: true),
            new PS("Васильева Наталья Алексеевна", "к.ф.-м.н.", "доцент",    "доцент",                IsSecretar: true),
            new PS("Егоров Кирилл Сергеевич",      "к.ф.-м.н.", "доцент",    "старший преподаватель"),
            new PS("Николаева Светлана Романовна", "к.ф.-м.н.", "доцент",    "преподаватель"),
            new PS("Семёнов Артём Ильич",          "к.ф.-м.н.", "доцент",    "ассистент"),
            new PS("Крылов Максим Константинович", "к.ф.-м.н.", "доцент",    "преподаватель",         IsRecenzent: true),
        }),
    };

    private sealed record KS(string Name, string Short, string Phone, string Email, string City, PS[] Persons);
    private sealed record PS(string Name, string Stepen, string Zvanie, string Dolgnost,
        bool IsPredsed = false, bool IsZavKaf = false, bool IsSecretar = false,
        bool IsRecenzent = false, bool IsVneshniy = false);
}
