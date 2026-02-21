using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Student;

public class DeleteStudentHandler
{
    private readonly AppDbContext _context;
    public DeleteStudentHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _context.Student.FirstOrDefaultAsync(d => d.Id == id, ct);
        if (entity == null)
            return false;

        _context.Student.Remove(entity);
        await _context.SaveChangesAsync(ct);
        return true;
    }
}
