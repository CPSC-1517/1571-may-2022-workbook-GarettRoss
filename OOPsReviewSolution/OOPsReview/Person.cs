using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview.Data
{
    public class Person
    {
        //example of a composite class
        //a composite class uses other classes/structs in it's definition
        //a composite class is recognized with the phrase "has a" class
        //this class of Person "has a" resident address
        //this class "has a" List<T> where <T> represents a data type and in this class
        // <T> is a collection of Employment

        //review video on inheritence and composition

        //each instance of this class will represent an individual
        //this class will define the following characteristics of a person
        //  
        //First Name, Last Name, the current resident address, List of employment positions

        private string _FirstName;
        private string _LastName;

        public String FirstName
        {
            get { return _FirstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name is required");
                }
                //else { _FirstName = value; }
                _FirstName = value;
            }
        }
        public String LastName
        {
            get { return _LastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last name is required");
                }

                _LastName = value;
            }
        }
            //composition actually uses the other struct/class as a property/field within
            // the definition of the class being specified (created)
            //in this example address is a field (data member)

            //this field is not a property
            //the data type is a developer defined datatype (struct)

            public ResidentAddress Address;



        public List<Employment> EmploymentPositions { get;private set; }

        public Person ()
        {
            //the system will automatically assign default system values to
            //  our dtatmembers according to their datatype
            //strings --> null
            //objects --> null

            // firstname and lastname has validation voiding a null value
            FirstName = "Unknown";
            LastName = "Unknown";
            //if one tried to reference an instance's data and the instance is 
            // null THEN one would get a null exception
            //even though you have no instances to store, you will at least have 
            //  someplce to put the data ONCE it is supplied


            EmploymentPositions = new List<Employment> ();
        }



    }
}
