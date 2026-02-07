using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.ProfilPodgotovki;

public class DeleteProfilPodgotovkiHandler
{
    private readonly AppDbContext _context;
    public DeleteProfilPodgotovkiHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _context.ProfilPodgotovki.FirstOrDefaultAsync(p => p.Id == id, ct);
        if (entity == null)
            return false;

        _context.ProfilPodgotovki.Remove(entity);
        await _context.SaveChangesAsync(ct);
        return true;
    }
}
