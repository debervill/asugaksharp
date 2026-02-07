using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Person;

public class UpdatePersonalDataHandler
{
    private readonly AppDbContext _context;
    public UpdatePersonalDataHandler(AppDbContext context) => _context = context;

    public async Task ExecuteAsync(UpdatePersonalDataRequest request, CancellationToken ct = default)
    {
        var person = await _context.Person.FindAsync([request.PersonId], ct);

        if (person == null)
            throw new InvalidOperationException("Сотрудник не найден");

        person.PassportSeria = request.PassportSeria;
        person.PassportNomer = request.PassportNomer;
        person.PassportIssuedBy = request.PassportIssuedBy;
        person.RegistrationAddress = request.RegistrationAddress;
        person.Snils = request.Snils;
        person.Inn = request.Inn;
        person.Email = request.Email;
        person.Phone = request.Phone;

        await _context.SaveChangesAsync(ct);
    }
}
