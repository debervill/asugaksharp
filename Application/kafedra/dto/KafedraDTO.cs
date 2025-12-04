using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asugaksharp.ApplicationLayer.kafedra.DTO
{
    // ApplicationLayer/DTOs/KafedraDto.cs
    public record KafedraDto(Guid Id, string Name);

    public record CreateKafedraDto(string Name);

    public record UpdateKafedraDto(Guid Id, string Name);
}
