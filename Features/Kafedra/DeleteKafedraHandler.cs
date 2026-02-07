using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Kafedra;

public class DeleteKafedraHandler
{
    private readonly AppDbContext _context;
    public DeleteKafedraHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _context.Kafedra.FirstOrDefaultAsync(k => k.Id == id, ct);
        if (entity == null)
            return false;

        _context.Kafedra.Remove(entity);
        await _context.SaveChangesAsync(ct);
        return true;
    }
}
