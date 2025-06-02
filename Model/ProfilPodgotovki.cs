using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asugaksharp.Model
{
    public class ProfilPodgotovki
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string ShifrPodgot { get; set; } = String.Empty;

        public Guid NapravleniePodgotovkiID { get; set; }
        public NapravleniePodgotovki? NapravleniePodgotovki {get; set;}
    }
}
