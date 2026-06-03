using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Diplomnik;

public class GetDiplomniksHandler
{
    private readonly AppDbContext _context;
    public GetDiplomniksHandler(AppDbContext context) => _context = context;

    public async Task<List<DiplomnikDto>> ExecuteAsync(CancellationToken ct = default)
    {
        var list = await _context.Diplomnik
            .AsNoTracking()
            .Include(d => d.Person)
            .Include(d => d.ProfilPodgotovki)
            .Include(d => d.Konsultanty!)
                .ThenInclude(dk => dk.Person)
            .OrderBy(d => d.FioImen)
            .ToListAsync(ct);

        return list.Select(d => new DiplomnikDto(
            d.Id,
            d.FioImen,
            d.FioRodit,
            d.Sex,
            d.Pages,
            d.Tema,
            d.OrigVkr,
            d.Srball,
            d.PersonId,
            d.Person?.Name,
            d.ProfilPodgotovkiId,
            d.ProfilPodgotovki?.Name,
            d.Konsultanty?
                .OrderBy(dk => dk.SortOrder)
                .Select(dk => new KonsultantInfo(dk.PersonId, dk.Person?.Name ?? string.Empty))
                .ToList() ?? new List<KonsultantInfo>()
        )).ToList();
    }
}
