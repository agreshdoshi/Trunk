using System;

namespace Premium.Services
{
    public abstract class Gender
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public virtual double GenderFactor { get; }
    }
}
