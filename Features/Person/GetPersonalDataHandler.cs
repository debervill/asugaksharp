using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Person;

public class GetPersonalDataHandler
{
    private readonly AppDbContext _context;
    public GetPersonalDataHandler(AppDbContext context) => _context = context;

    public async Task<PersonalDataDto?> ExecuteAsync(Guid personId, CancellationToken ct = default)
    {
        return await _context.Person
            .AsNoTracking()
            .Where(p => p.Id == personId)
            .Select(p => new PersonalDataDto(
                p.Id,
                p.Name,
                p.PassportSeria,
                p.PassportNomer,
                p.PassportIssuedBy,
                p.RegistrationAddress,
                p.Snils,
                p.Inn,
                p.Email,
                p.Phone))
            .FirstOrDefaultAsync(ct);
    }
}
