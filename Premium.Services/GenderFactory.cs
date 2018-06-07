using System;
using System.Collections.Generic;
using System.Text;

namespace Premium.Services
{
    public static class GenderFactory
    {
        public static Gender CreateInstance(string gender)
        {
            Gender genderClass = null;
            switch(gender)
            {
                case "Male":
                    genderClass = new Male();
                    break;

                case "Female":
                    genderClass = new Female();
                    break;
            }
            return genderClass;
        }
    }
}
