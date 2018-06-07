using System;
using System.Collections.Generic;
using System.Text;

namespace Premium.Services
{
    public class Male : Gender
    {
        public override double GenderFactor { get => 1.2; }
    }
}
