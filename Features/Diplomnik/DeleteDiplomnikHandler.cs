using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Diplomnik;

public class DeleteDiplomnikHandler
{
    private readonly AppDbContext _context;
    public DeleteDiplomnikHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _context.Diplomnik.FirstOrDefaultAsync(d => d.Id == id, ct);
        if (entity == null)
            return false;

        _context.Diplomnik.Remove(entity);
        await _context.SaveChangesAsync(ct);
        return true;
    }
}
