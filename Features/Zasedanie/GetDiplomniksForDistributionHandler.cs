using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Zasedanie;

public class GetDiplomniksForDistributionHandler
{
    private readonly AppDbContext _context;
    public GetDiplomniksForDistributionHandler(AppDbContext context) => _context = context;

    public async Task<(List<DiplomnikForDistributionDto> Unassigned, List<DiplomnikForDistributionDto> Assigned)>
        ExecuteAsync(Guid zasedanieId, CancellationToken ct = default)
    {
        var all = await _context.Diplomnik
            .AsNoTracking()
            .Include(d => d.Person).ThenInclude(p => p!.Kafedra)
            .Include(d => d.ProfilPodgotovki).ThenInclude(p => p!.NapravleniePodgotovki)
            .Where(d => d.ZasedanieId == null || d.ZasedanieId == zasedanieId)
            .OrderBy(d => d.FioImen)
            .ToListAsync(ct);

        static DiplomnikForDistributionDto ToDto(Core.Entities.Diplomnik d) => new(
            d.Id,
            d.FioImen,
            d.Tema,
            d.Person?.Name,
            d.ProfilPodgotovki?.Name,
            d.Person?.KafedraID,
            d.Person?.Kafedra?.Name,
            d.ProfilPodgotovki?.NapravleniePodgotovkiID,
            d.ProfilPodgotovki?.NapravleniePodgotovki?.Nazvanie,
            d.VidVkr,
            d.ZasedanieOrder);

        var unassigned = all.Where(d => d.ZasedanieId == null).Select(ToDto).ToList();
        var assigned   = all.Where(d => d.ZasedanieId == zasedanieId)
                            .OrderBy(d => d.ZasedanieOrder ?? int.MaxValue)
                            .ThenBy(d => d.FioImen)
                            .Select(ToDto).ToList();

        return (unassigned, assigned);
    }
}
