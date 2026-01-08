using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asugaksharp.Core.Entities
{
    public class ProfilPodgotovki
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ShifrPodgot { get; set; } = string.Empty;

        public Guid NapravleniePodgotovkiID { get; set; }
        public NapravleniePodgotovki? NapravleniePodgotovki {get; set;}
        public ICollection<ProfilPodgotovki> ProfilPodgotovkis { get; set; } = new List<ProfilPodgotovki>();
    }
}
