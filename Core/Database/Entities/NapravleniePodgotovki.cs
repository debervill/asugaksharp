using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace asugaksharp.Core.Entities
{
    public class NapravleniePodgotovki
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Nazvanie { get; set; } = string.Empty;
        public string ShifrNapr { get; set; } = string.Empty;

        public ICollection<ProfilPodgotovki> ProfilPodgotovkis { get; set; }    
        
        

    }
}
