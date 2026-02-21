using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asugaksharp.Core.Entities
{
    public class Diplomnik
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        // Привязка к студенту (1:1)
        public Guid StudentId { get; set; }
        public Student? Student { get; set; }

        //от таблицы Заседание
        public Guid ZasedanieId { get; set; }
        public Zasedanie? Zasedanie { get; set; }

    }
}
