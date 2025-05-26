﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asugaksharp.Model
{
    public class Docs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsUploaded { get; set; }
        public string Data { get; set; } = string.Empty;

        public Guid PersonId { get; set; }
        public Person? Person { get; set; }


    }
}
