using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asugaksharp.Core.Entities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string FioImen { get; set; } = string.Empty;
        public string FioRodit { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public int Pages { get; set; }
        public string Tema { get; set; } = string.Empty;
        public float OrigVkr { get; set; }
        public float Srball { get; set; }

        // Научный руководитель
        public Guid PersonId { get; set; }
        public Person? Person { get; set; }

        // Связь 1:1 с дипломником (после назначения защиты)
        public Diplomnik? Diplomnik { get; set; }
    }
}
