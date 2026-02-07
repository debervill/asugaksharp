using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asugaksharp.Core.Entities
{
    public class PersonZasedanie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        // Связи
        public Guid PersonId { get; set; }
        public Person? Person { get; set; }

        public Guid ZasedanieId { get; set; }
        public Zasedanie? Zasedanie { get; set; }

        // Роль person на конкретном заседании
        public string RolVGek { get; set; } = string.Empty; // "Председатель"/"Секретарь"/"Член"
    }
}
