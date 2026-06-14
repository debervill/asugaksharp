using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asugaksharp.Core.Entities
{
    public class Diplomnik
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string FioImen { get; set; } = string.Empty;
        public string FioRodit { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public int? Pages { get; set; }
        public string Tema { get; set; } = string.Empty;
        public float? OrigVkr { get; set; }
        public float? Srball { get; set; }
        public string? Otsenka { get; set; }
        public string? VidVkr { get; set; }

        // Руководитель
        public Guid PersonId { get; set; }
        public Person? Person { get; set; }

        // Профиль подготовки
        public Guid? ProfilPodgotovkiId { get; set; }
        public ProfilPodgotovki? ProfilPodgotovki { get; set; }

        // Заседание
        public Guid? ZasedanieId { get; set; }
        public Zasedanie? Zasedanie { get; set; }
        public int? ZasedanieOrder { get; set; }

        // Консультанты
        public ICollection<DiplomnikKonsultant>? Konsultanty { get; set; }

        // Рецензенты
        public ICollection<DiplomnikRetsenzent>? Retsenzenty { get; set; }
    }
}
