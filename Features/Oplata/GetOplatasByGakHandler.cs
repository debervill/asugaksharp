using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Oplata;

public class GetOplatasByGakHandler
{
    private readonly AppDbContext _context;
    public GetOplatasByGakHandler(AppDbContext context) => _context = context;

    public async Task<List<OplataRowDto>> ExecuteAsync(Guid gakId, CancellationToken ct = default)
    {
        return await _context.Oplata
            .AsNoTracking()
            .Where(o => o.GakId == gakId)
            .Include(o => o.Person)
            .OrderBy(o => o.RolVGek)
            .ThenBy(o => o.Person != null ? o.Person.Name : "")
            .Select(o => new OplataRowDto
            {
                OplataId = o.Id,
                PersonId = o.PersonId,
                PersonName = o.Person != null ? o.Person.Name : "",
                RolVGek = o.RolVGek,
                KolvoBudget = o.KolvoBudget,
                KolvoPlatka = o.KolvoPlatka,
                Koefficient = o.Koefficient,
                StoimostChasa = o.StoimostChasa,
                AkademChasov = o.AkademChasov,
                AstronomChasov = o.AstronomChasov,
                ObshayaStoimostUslugPoDogovoru = o.ObshayaStoimostUslugPoDogovoru,
                SummaBezNalogov = o.SummaBezNalogov,
                NdflSumma = o.NdflSumma,
                EnpSumma = o.EnpSumma,
                SummaKVyplate = o.SummaKVyplate
            })
            .ToListAsync(ct);
    }
}
