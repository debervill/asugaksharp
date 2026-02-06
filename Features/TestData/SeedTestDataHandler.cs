using System.Globalization;
using Microsoft.EntityFrameworkCore;
using asugaksharp.Core.Entities;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.TestData;

public sealed record SeedTestDataResult(int KafedraAdded, int PersonsAdded, bool AlreadyExists);

public sealed class SeedTestDataHandler
{
    private const string TestDataMarker = "TEST_DATA";
    private readonly AppDbContext _context;

    public SeedTestDataHandler(AppDbContext context) => _context = context;

    public async Task<SeedTestDataResult> ExecuteAsync(CancellationToken ct = default)
    {
        if (await _context.Kafedra.AnyAsync(k => k.Description == TestDataMarker, ct))
            return new SeedTestDataResult(0, 0, true);

        var seeds = GetSeeds();
        var personsAdded = 0;
        var globalIndex = 0;

        foreach (var seed in seeds)
        {
            var kafedra = new Core.Entities.Kafedra
            {
                Id = Guid.NewGuid(),
                Name = seed.Name,
                ShortName = seed.ShortName,
                Description = TestDataMarker,
                Phone = seed.Phone,
                Email = seed.Email
            };

            _context.Kafedra.Add(kafedra);

            foreach (var personSeed in seed.Persons)
            {
                globalIndex++;
                _context.Person.Add(BuildPerson(kafedra.Id, seed.City, personSeed, globalIndex));
                personsAdded++;
            }
        }

        await _context.SaveChangesAsync(ct);
        return new SeedTestDataResult(seeds.Count, personsAdded, false);
    }

    private static Core.Entities.Person BuildPerson(Guid kafedraId, string city, PersonSeed seed, int index)
    {
        var passportSeria = (5400 + index).ToString("0000", CultureInfo.InvariantCulture);
        var passportNumber = (100000 + index).ToString("000000", CultureInfo.InvariantCulture);
        var issuedBy = $"УМВД России по г. {city}";
        var address = $"г. {city}, ул. Советская, д. {10 + (index % 40)}, кв. {1 + (index % 80)}";

        var snilsBase = 112233440 + (index * 13);
        var snilsSuffix = (index * 7) % 100;
        var snils = FormatSnils(snilsBase, snilsSuffix);

        var inn = (540100000000 + index).ToString("000000000000", CultureInfo.InvariantCulture);
        var phone = $"+7 (913) 55{index % 10}-{(index * 3) % 90:00}-{(index * 7) % 90:00}";
        var email = $"person{index}@example.ru";

        return new Core.Entities.Person
        {
            Id = Guid.NewGuid(),
            Name = seed.Name,
            Stepen = seed.Stepen,
            Zvanie = seed.Zvanie,
            Dolgnost = seed.Dolgnost,
            IsPredsed = seed.IsPredsed,
            IsZavKaf = seed.IsZavKaf,
            IsSecretar = seed.IsSecretar,
            IsRecenzent = seed.IsRecenzent,
            IsVneshniy = seed.IsVneshniy,
            PassportSeria = passportSeria,
            PassportNomer = passportNumber,
            PassportIssuedBy = issuedBy,
            RegistrationAddress = address,
            Snils = snils,
            Inn = inn,
            Email = email,
            Phone = phone,
            KafedraID = kafedraId
        };
    }

    private static string FormatSnils(int baseValue, int suffix)
    {
        var raw = Math.Abs(baseValue) % 1_000_000_000;
        return $"{raw / 1_000_000:000}-{(raw / 1_000) % 1_000:000}-{raw % 1_000:000} {suffix:00}";
    }

    private static List<KafedraSeed> GetSeeds()
    {
        return new List<KafedraSeed>
        {
            new(
                "Кафедра прикладной информатики",
                "КПИ",
                "8 (383) 200-11-22",
                "kpi@example.ru",
                "Новосибирск",
                new[]
                {
                    new PersonSeed("Иванов Иван Петрович", "д.т.н.", "профессор", "заведующий кафедрой", IsZavKaf: true),
                    new PersonSeed("Петрова Анна Сергеевна", "к.т.н.", "доцент", "доцент", IsSecretar: true),
                    new PersonSeed("Сидоров Николай Андреевич", "к.т.н.", "доцент", "старший преподаватель", IsRecenzent: true),
                    new PersonSeed("Кузнецова Мария Игоревна", "к.ф.-м.н.", "доцент", "преподаватель"),
                    new PersonSeed("Орлов Дмитрий Олегович", "к.т.н.", "доцент", "старший преподаватель"),
                    new PersonSeed("Волкова Елена Викторовна", "к.т.н.", "доцент", "ассистент")
                }),
            new(
                "Кафедра экономики и управления",
                "КЭУ",
                "8 (3812) 55-66-77",
                "keu@example.ru",
                "Омск",
                new[]
                {
                    new PersonSeed("Смирнов Алексей Николаевич", "д.э.н.", "профессор", "заведующий кафедрой", IsZavKaf: true),
                    new PersonSeed("Фёдорова Ольга Павловна", "к.э.н.", "доцент", "заместитель заведующего", IsSecretar: true),
                    new PersonSeed("Захарова Ирина Владимировна", "к.э.н.", "доцент", "доцент", IsRecenzent: true),
                    new PersonSeed("Попов Андрей Евгеньевич", "к.э.н.", "доцент", "старший преподаватель"),
                    new PersonSeed("Морозова Татьяна Юрьевна", "к.э.н.", "доцент", "преподаватель"),
                    new PersonSeed("Громов Сергей Валерьевич", "к.э.н.", "доцент", "ассистент"),
                    new PersonSeed("Лебедев Павел Дмитриевич", "к.э.н.", "доцент", "преподаватель")
                }),
            new(
                "Кафедра математики и статистики",
                "КМС",
                "8 (3822) 44-55-66",
                "kms@example.ru",
                "Томск",
                new[]
                {
                    new PersonSeed("Павлов Юрий Степанович", "д.ф.-м.н.", "профессор", "заведующий кафедрой", IsZavKaf: true),
                    new PersonSeed("Васильева Наталья Алексеевна", "к.ф.-м.н.", "доцент", "доцент", IsSecretar: true),
                    new PersonSeed("Егоров Кирилл Сергеевич", "к.ф.-м.н.", "доцент", "старший преподаватель"),
                    new PersonSeed("Николаева Светлана Романовна", "к.ф.-м.н.", "доцент", "преподаватель"),
                    new PersonSeed("Семёнов Артём Ильич", "к.ф.-м.н.", "доцент", "ассистент"),
                    new PersonSeed("Крылов Максим Константинович", "к.ф.-м.н.", "доцент", "преподаватель", IsRecenzent: true)
                })
        };
    }

    private sealed record KafedraSeed(
        string Name,
        string ShortName,
        string Phone,
        string Email,
        string City,
        PersonSeed[] Persons);

    private sealed record PersonSeed(
        string Name,
        string Stepen,
        string Zvanie,
        string Dolgnost,
        bool IsPredsed = false,
        bool IsZavKaf = false,
        bool IsSecretar = false,
        bool IsRecenzent = false,
        bool IsVneshniy = false);
}
