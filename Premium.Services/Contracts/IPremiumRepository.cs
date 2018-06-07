using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Premium.Services
{
    public interface IPremiumRepository
    {
       Task<double> CalculatePremiumAsync(Gender gender);
    }
}
