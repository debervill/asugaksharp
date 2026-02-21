using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Student;

public class GetStudentsHandler
{
    private readonly AppDbContext _context;
    public GetStudentsHandler(AppDbContext context) => _context = context;

    public async Task<List<StudentDto>> ExecuteAsync(CancellationToken ct = default)
    {
        return await _context.Student
            .AsNoTracking()
            .Include(s => s.Person)
            .OrderBy(s => s.FioImen)
            .Select(s => new StudentDto(
                s.Id,
                s.FioImen,
                s.FioRodit,
                s.Sex,
                s.Pages,
                s.Tema,
                s.OrigVkr,
                s.Srball,
                s.PersonId,
                s.Person != null ? s.Person.Name : null))
            .ToListAsync(ct);
    }
}
