using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview.Data
{
    public class Employment
    {
        // an instance of this class will hold data about a person's employment
        //The code of this class is the definition of this data
        //The characteristics (data) of the class will be the following
        //Title, SupervisoryLevel, Years of employment within the company

        //there are 4 components of a class definition

        //data fields (data members)
        //property
        //constructor
        // behavior (method)
    
        //data fields
        // are storage areas in your class
        // these are treated as variables
        // these may be public, private, public read-only

        //property
        //These are access techniques to retrieve or set data in your class without directly touching
        // the storage data field
    
        //A property is associated with a single instance of data
        //A property is public so it can be accessed by an outside user of the class
        //A property must have a get
        //A property may have a set
        // if no set the property is not changeable by the user;read only
        //    commonly used for calculated data of the class
        //the set can either public or private
        //      public: the user can alter the contents of the data
        //      private: only code within the class can alter the contents

        public string Title
        {
            get;
            set;
        }

    }
}
