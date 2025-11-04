using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asugaksharp.Core.Entities
{
    public class PeriodZasedania
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public string Primechanie { get; set; } = string.Empty;

        //1 ко многим к таблице гэк
        public ICollection<Gak>? Gaks { get; set; }

        public Guid KafedraId { get; set; }
        
        [ForeignKey(nameof(KafedraId))]
        public Kafedra? Kafedra { get; set; }

    }
}
