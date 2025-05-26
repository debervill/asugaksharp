

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asugaksharp.Model
{
    public class PeriodZasedania
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public string Primechanie { get; set; } = String.Empty;

        //1 ко многим к таблице гэк
        public ICollection<Gak>? Gaks { get; set; }
    }
}
