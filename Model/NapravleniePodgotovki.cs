using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asugaksharp.Model
{
    public class NapravleniePodgotovki
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Nazvanie { get; set; } = String.Empty;
        public string ShifrNapr { get; set; } = String.Empty;

        public ICollection<ProfilPodgotovki> ProfilPodgotovkis { get; set; }    
        
        

    }
}
