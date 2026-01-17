using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.ProfilPodgotovki;

public class UpdateProfilPodgotovkiHandler
{
    private readonly AppDbContext _context;
    public UpdateProfilPodgotovkiHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(UpdateProfilPodgotovkiRequest request, CancellationToken ct = default)
    {
        var entity = await _context.ProfilPodgotovki.FirstOrDefaultAsync(p => p.Id == request.Id, ct);
        if (entity == null)
            return false;

        entity.Name = request.Name;
        entity.ShifrPodgot = request.ShifrPodgot;
        entity.NapravleniePodgotovkiID = request.NapravleniePodgotovkiId;

        await _context.SaveChangesAsync(ct);
        return true;
    }
}
