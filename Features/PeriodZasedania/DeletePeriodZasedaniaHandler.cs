using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.PeriodZasedania;

public class DeletePeriodZasedaniaHandler
{
    private readonly AppDbContext _context;
    public DeletePeriodZasedaniaHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _context.PeriodZasedania.FirstOrDefaultAsync(p => p.Id == id, ct);
        if (entity == null)
            return false;

        _context.PeriodZasedania.Remove(entity);
        await _context.SaveChangesAsync(ct);
        return true;
    }
}
