using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace asugaksharp.Model
{
    internal class PeriodZasedania
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public DateTime Date { get; set; }
        public string Primechanie { get; set; } = String.Empty;

        //1 ко многим к таблице гэк
        public ICollection<Gak>? Gaks { get; set; }
    }
}
