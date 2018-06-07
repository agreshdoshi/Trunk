using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Premium.Services
{
    public class PremiumRepository : IPremiumRepository
    {
  
        public async Task<double> CalculatePremiumAsync(Gender gender)
        {
            var age = GetAge(gender.DOB) ;
            // This is not a right way. Even this can be abstracted. Taking a shortcut here.
            var premium = age > 18 && age < 65?  age * gender.GenderFactor * 100: 0;
            return premium;
        }


        private double GetAge(DateTime dob)
        {
            DateTime zeroTime = new DateTime(1, 1, 1);
            TimeSpan ts = DateTime.Now - dob;
            int years = (zeroTime + ts).Year - 1;
            return years;
        }
    }
}
