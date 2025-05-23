using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace asugaksharp.Model
{
    internal class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Stepen { get; set; } = string.Empty;
        public string Zvanie { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;


        //от таблицы заседание

        public ICollection<Zasedanie> Zasedanies { get; set; }
       
        //от таблицы докс
        public ICollection<Docs>? Docs { get; set; }

        //от таблицы Дипломник
        public ICollection<Diplomnik>? Diplomniks { get; set;}

        //от таблицы оплата

        public ICollection<Oplata>? Oplatas { get; set; }
        


     
    }
}
