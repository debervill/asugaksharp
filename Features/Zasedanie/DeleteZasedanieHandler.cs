using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Zasedanie;

public class DeleteZasedanieHandler
{
    private readonly AppDbContext _context;
    public DeleteZasedanieHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _context.Zasedanie.FirstOrDefaultAsync(z => z.Id == id, ct);
        if (entity == null)
            return false;

        _context.Zasedanie.Remove(entity);
        await _context.SaveChangesAsync(ct);
        return true;
    }
}
