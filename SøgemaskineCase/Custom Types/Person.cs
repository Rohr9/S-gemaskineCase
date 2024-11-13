using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SøgemaskineCase.Custom_Types
{
    public abstract class Person : ISeachable
    {
        public string Forname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }

        public string GetName() => $"{Forname} {Lastname}";
    }
}
