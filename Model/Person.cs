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
        public string Zvanie {  get; set; } = string.Empty;  
        public string Role { get; set; } = string.Empty;
        public string PasportNumber { get; set; } = string.Empty;
        public string SnilsNumber { get; set; } = string.Empty; 
        public string PhoneNumber {  get; set; } = string.Empty;
        
        public string BankName {  get; set; } = string.Empty;

    }
}
