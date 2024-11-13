using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SøgemaskineCase.Custom_Types
{
    public struct AgeValidation
    { 
        public static int CalculateAge(DateTime Birthdate) 
        {
            var today = DateTime.Now;
            int age = today.Year - Birthdate.Year;
            if (today < Birthdate.AddYears(age)) age--;
            return age;

        }
    }
}
