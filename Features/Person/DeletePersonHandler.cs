using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Person;

public class DeletePersonHandler
{
    private readonly AppDbContext _context;
    public DeletePersonHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _context.Person.FirstOrDefaultAsync(p => p.Id == id, ct);
        if (entity == null)
            return false;

        _context.Person.Remove(entity);
        await _context.SaveChangesAsync(ct);
        return true;
    }
}
