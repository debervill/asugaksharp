namespace asugaksharp.Features.Person;

public record PersonalDataDto(
    Guid PersonId,
    string Name,
    string? PassportSeria,
    string? PassportNomer,
    string? PassportIssuedBy,
    string? RegistrationAddress,
    string? Snils,
    string? Inn,
    string? Email,
    string? Phone);

public record UpdatePersonalDataRequest(
    Guid PersonId,
    string? PassportSeria,
    string? PassportNomer,
    string? PassportIssuedBy,
    string? RegistrationAddress,
    string? Snils,
    string? Inn,
    string? Email,
    string? Phone);
