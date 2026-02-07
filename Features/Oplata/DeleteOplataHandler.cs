using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Oplata;

public class DeleteOplataHandler
{
    private readonly AppDbContext _context;
    public DeleteOplataHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _context.Oplata.FirstOrDefaultAsync(o => o.Id == id, ct);
        if (entity == null)
            return false;

        _context.Oplata.Remove(entity);
        await _context.SaveChangesAsync(ct);
        return true;
    }
}
