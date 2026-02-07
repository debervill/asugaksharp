using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.ProfilPodgotovki;

public class GetProfilPodgotovkisHandler
{
    private readonly AppDbContext _context;
    public GetProfilPodgotovkisHandler(AppDbContext context) => _context = context;

    public async Task<List<ProfilPodgotovkiDto>> ExecuteAsync(CancellationToken ct = default)
    {
        return await _context.ProfilPodgotovki
            .AsNoTracking()
            .Include(p => p.NapravleniePodgotovki)
            .OrderBy(p => p.ShifrPodgot)
            .Select(p => new ProfilPodgotovkiDto(
                p.Id,
                p.Name,
                p.ShifrPodgot,
                p.NapravleniePodgotovkiID,
                p.NapravleniePodgotovki != null ? p.NapravleniePodgotovki.Nazvanie : null))
            .ToListAsync(ct);
    }
}
