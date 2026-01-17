using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Gak;

public class DeleteGakHandler
{
    private readonly AppDbContext _context;
    public DeleteGakHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _context.Gak.FirstOrDefaultAsync(g => g.Id == id, ct);
        if (entity == null)
            return false;

        _context.Gak.Remove(entity);
        await _context.SaveChangesAsync(ct);
        return true;
    }
}
