using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Docs;

public class DeleteDocsHandler
{
    private readonly AppDbContext _context;
    public DeleteDocsHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _context.Docs.FirstOrDefaultAsync(d => d.Id == id, ct);
        if (entity == null)
            return false;

        _context.Docs.Remove(entity);
        await _context.SaveChangesAsync(ct);
        return true;
    }
}
