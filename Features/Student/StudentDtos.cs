namespace asugaksharp.Features.Student;

public record StudentDto(
    Guid Id,
    string FioImen,
    string FioRodit,
    string Sex,
    int Pages,
    string Tema,
    float OrigVkr,
    float Srball,
    Guid PersonId,
    string? PersonName);

public record CreateStudentRequest(
    string FioImen,
    string FioRodit,
    string Sex,
    int Pages,
    string Tema,
    float OrigVkr,
    float Srball,
    Guid PersonId);

public record UpdateStudentRequest(
    Guid Id,
    string FioImen,
    string FioRodit,
    string Sex,
    int Pages,
    string Tema,
    float OrigVkr,
    float Srball,
    Guid PersonId);
