using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Oplata;

public class SaveOplatasByGakHandler
{
    private readonly AppDbContext _context;
    public SaveOplatasByGakHandler(AppDbContext context) => _context = context;

    public async Task ExecuteAsync(Guid gakId, List<OplataRowDto> rows, CancellationToken ct = default)
    {
        var totalNachisleno = rows.Sum(r => r.SummaBezNalogov);
        var totalNdfl = rows.Sum(r => r.NdflSumma);
        var totalEnp = rows.Sum(r => r.EnpSumma);
        var totalKVyplate = rows.Sum(r => r.SummaKVyplate);

        // Получаем существующие записи для этого ГАК
        var existingOplatas = await _context.Oplata
            .Where(o => o.GakId == gakId)
            .ToListAsync(ct);

        foreach (var row in rows)
        {
            var existing = existingOplatas.FirstOrDefault(o => o.PersonId == row.PersonId);

            if (existing != null)
            {
                // Обновляем существующую запись
                existing.RolVGek = row.RolVGek;
                existing.KolvoBudget = row.KolvoBudget;
                existing.KolvoPlatka = row.KolvoPlatka;
                existing.Koefficient = row.Koefficient;
                existing.StoimostChasa = row.StoimostChasa;
                existing.StoimostAkademChasaSNalogami = row.StoimostAkademChasaSNalogami;
                existing.ObshayaStoimostUslugPoDogovoru = row.ObshayaStoimostUslugPoDogovoru;
                existing.AkademChasov = row.AkademChasov;
                existing.AstronomChasov = row.AstronomChasov;
                existing.SummaBezNalogov = row.SummaBezNalogov;
                existing.NdflProc = 13f;
                existing.NdflSumma = row.NdflSumma;
                existing.EnpProc = 30f;
                existing.EnpSumma = row.EnpSumma;
                existing.SummaKVyplate = row.SummaKVyplate;
                existing.SummaSNalogami = row.SummaBezNalogov + row.EnpSumma;
                existing.TotalNachisleno = totalNachisleno;
                existing.TotalNdfl = totalNdfl;
                existing.TotalEnp = totalEnp;
                existing.TotalKVyplate = totalKVyplate;
                existing.DataRascheta = DateTime.Now;
            }
            else
            {
                // Создаём новую запись
                var newId = Guid.NewGuid();
                var entity = new Core.Entities.Oplata
                {
                    Id = newId,
                    PersonId = row.PersonId,
                    GakId = gakId,
                    RolVGek = row.RolVGek,
                    KolvoBudget = row.KolvoBudget,
                    KolvoPlatka = row.KolvoPlatka,
                    Koefficient = row.Koefficient,
                    StoimostChasa = row.StoimostChasa,
                    StoimostAkademChasaSNalogami = row.StoimostAkademChasaSNalogami,
                    ObshayaStoimostUslugPoDogovoru = row.ObshayaStoimostUslugPoDogovoru,
                    AkademChasov = row.AkademChasov,
                    AstronomChasov = row.AstronomChasov,
                    SummaBezNalogov = row.SummaBezNalogov,
                    NdflProc = 13f,
                    NdflSumma = row.NdflSumma,
                    EnpProc = 30f,
                    EnpSumma = row.EnpSumma,
                    SummaKVyplate = row.SummaKVyplate,
                    SummaSNalogami = row.SummaBezNalogov + row.EnpSumma,
                    TotalNachisleno = totalNachisleno,
                    TotalNdfl = totalNdfl,
                    TotalEnp = totalEnp,
                    TotalKVyplate = totalKVyplate,
                    DataRascheta = DateTime.Now,
                    IsDogovorGenerated = false
                };
                _context.Oplata.Add(entity);
                row.OplataId = newId; // Устанавливаем Id в DTO
            }
        }

        await _context.SaveChangesAsync(ct);
    }
}
