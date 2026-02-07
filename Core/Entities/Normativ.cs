using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asugaksharp.Core.Entities
{
    public class Normativ
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        // Роль в ГЭК
        public string RolVGek { get; set; } = string.Empty; // "Председатель", "Секретарь", "Член"

        // Расценки
        public float StavkaZaStudenta { get; set; } // руб за 1 студента
        public float NormaVremeni { get; set; } // часов на 1 студента

        // Основание
        public string Osnovanie { get; set; } = string.Empty; // "приказ ВПО №1156 от 15.12.2023"
        public string Kod { get; set; } = string.Empty; // код основания
    }
}
