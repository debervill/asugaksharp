namespace asugaksharp.Features.Kafedra.GetKafedraList;

using asugaksharp.Core.Common;

public record GetKafedraListQuery : IRequest<System.Collections.Generic.List<KafedraDto>>;

public record KafedraDto(System.Guid Id, string Name);