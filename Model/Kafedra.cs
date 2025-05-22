using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asugaksharp.Model
{
    internal class Kafedra
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;
        public string Fiozav { get; set; }= string.Empty;

        //от таблицы гак
        public ICollection<Gak>? Gaks { get; set; }
    }
}
