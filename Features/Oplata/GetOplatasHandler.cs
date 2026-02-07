using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Oplata;

public class GetOplatasHandler
{
    private readonly AppDbContext _context;
    public GetOplatasHandler(AppDbContext context) => _context = context;

    public async Task<List<OplataDto>> ExecuteAsync(CancellationToken ct = default)
    {
        return await _context.Oplata
            .AsNoTracking()
            .Include(o => o.Person)
            .OrderBy(o => o.Person != null ? o.Person.Name : "")
            .Select(o => new OplataDto(
                o.Id,
                o.PersonId,
                o.Person != null ? o.Person.Name : null,
                o.GakId,
                o.RolVGek,
                o.KolvoBudget,
                o.KolvoPlatka,
                o.Koefficient,
                o.StoimostChasa,
                o.StoimostAkademChasaSNalogami,
                o.ObshayaStoimostUslugPoDogovoru,
                o.AkademChasov,
                o.AstronomChasov,
                o.SummaBezNalogov,
                o.NdflProc,
                o.NdflSumma,
                o.EnpProc,
                o.EnpSumma,
                o.SummaKVyplate,
                o.SummaSNalogami,
                o.DogovorNumber,
                o.MoneySource,
                o.DataRascheta,
                o.IsDogovorGenerated))
            .ToListAsync(ct);
    }
}
