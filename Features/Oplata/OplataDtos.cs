namespace asugaksharp.Features.Oplata;

public record OplataDto(
    Guid Id,
    float Stavka,
    float Ndfl,
    float Enp,
    int MoneySource,
    int DogovorNumber,
    Guid PersonId,
    string? PersonName);

public record CreateOplataRequest(
    float Stavka,
    float Ndfl,
    float Enp,
    int MoneySource,
    int DogovorNumber,
    Guid PersonId);

public record UpdateOplataRequest(
    Guid Id,
    float Stavka,
    float Ndfl,
    float Enp,
    int MoneySource,
    int DogovorNumber,
    Guid PersonId);
