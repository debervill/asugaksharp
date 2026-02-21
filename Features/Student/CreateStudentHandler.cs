using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Student;

public class CreateStudentHandler
{
    private readonly AppDbContext _context;
    public CreateStudentHandler(AppDbContext context) => _context = context;

    public async Task<Guid> ExecuteAsync(CreateStudentRequest request, CancellationToken ct = default)
    {
        var entity = new Core.Entities.Student
        {
            Id = Guid.NewGuid(),
            FioImen = request.FioImen,
            FioRodit = request.FioRodit,
            Sex = request.Sex,
            Pages = request.Pages,
            Tema = request.Tema,
            OrigVkr = request.OrigVkr,
            Srball = request.Srball,
            PersonId = request.PersonId
        };

        _context.Student.Add(entity);
        await _context.SaveChangesAsync(ct);

        return entity.Id;
    }
}
