using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public static class Utilities
    {

        //static classes are not instantiated by the outside user (developer)
        //static class items are referenced using the classname.xxxxx
        //methods within this class have the keyword static in the their signature
        //static classes are shared between all outside users at the same time
        //DO NOT consider saving data within a static class BECASUE you cannot be 
        //    certain it will be there when you you use the class again
        // consider placing generic re-usable methods in static classes


        //example of overloaded methods
        //the method signatures are different
        public static bool IsZeroPositive(int value)
        {
            bool valid = true;
            if (value < 0)
            {
                valid = false;
            }
            return valid;
        }
        public static bool IsZeroPositive(double value)
        {
            bool valid = true;
            if (value < 0)
            {
                valid = false;
            }
            return valid;
        }
        public static bool IsZeroPositive(decimal value)
        {
            bool valid = true;
            if (value < 0)
            {
                valid = false;
            }
            return valid;
        }
    }
}
