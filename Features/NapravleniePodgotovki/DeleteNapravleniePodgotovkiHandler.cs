using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.NapravleniePodgotovki;

public class DeleteNapravleniePodgotovkiHandler
{
    private readonly AppDbContext _context;
    public DeleteNapravleniePodgotovkiHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _context.NapravleniePodgotovki.FirstOrDefaultAsync(n => n.Id == id, ct);
        if (entity == null)
            return false;

        _context.NapravleniePodgotovki.Remove(entity);
        await _context.SaveChangesAsync(ct);
        return true;
    }
}
