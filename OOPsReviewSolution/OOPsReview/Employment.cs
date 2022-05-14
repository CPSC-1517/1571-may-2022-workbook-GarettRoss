﻿using System;
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


        //fully implemented property

        // a) a declared storage area (data field)
        // b) declared property signature (access rdt propertyname)
        // c) a coded accessor (get) method :public
        // d) an optional coded mutator (set) method: can be public or private
        //      if the set is private the only way ot place data
        //      into the property is through the constructor or a  behavior (method)

        //When:
        // a) if you are storing the dtata in an explicity declared data field
        // b) if you are doing validation on incoming data
        //  c) creating a property that generates output from pther data sources
        //      within the class (readonly property);  this property would only
        //      have a accessor (get)


        private string _Title;
        private double _Years;
        

        public string Title
        {// a property is associated with a single piece of data 
            get
            {
                //accessor
                //the get "coding block" will return the contents of a data field(s)
                //The return has syntax of    return expression
                return _Title;
            }
            set
            {
                //mutator
                //the set "coding block" receives an incoing value and places it
                //into the associated data field
                //during the setting you might wish to validate the incoming data
                //during the setting you might wish to do some type of logical
                //  processing using the data to set another field
                //the incoming piece of data is refered to using the keyword "value"

                //ensure that the incoming data is not null or empty or just whitespace
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is a required piece of data.");
                }
                //data is considered valid
                _Title = value;
            }
        }
            //auto impemented property
            //each property is responsible for a single piece of data
            //these properties do not refeence a declared private data member
            //the system generates an internal storage area of the return data type
            //the system manages the internal storge for the accessor and mustator
            //THERE IS NO ADDITIONAL LOGIC APPLIED TO THE DATE VALUE !!!!!

            //using an enum for this field will automatically restrict the values
            //  this property can contain

            //syntax access rdt propertyname {get;[private]set;}

            public SupervisoryLevel Level { get; set; }

        public double Years
        {
            get { return _Years; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"Years value {value} is invalid must be 0 or greater");
                }
                _Years = value; 
            }

        }

        //constructor

        //this is used to initialize the phyical object (instance) during it's creation
        //the result of creation is to ensure that the code gets an instance in a 
        // "known state"

        //if your class has No constructor coded then the data members and/or
        // auto implementd properties are set to the C# default data type value
        //
        //You can code one or more constructor in your class definition
        //IF YOU CODE A CONSTRUCTOR FOR THE CLASS, YOU ARE RESPONSIBLE
        //   FOR ALL CONSTRUCTORS USED BY THE CLASS!!!
        //
        //

        //Generally if you are going to code your own constructions you code two types
        //    Default:  this constructor does not take in any parameters
        //              this constructor mimics the default system constructor

        //Greedy:     This constructor has a list of parameters, one for each property,
        //            declare for incoming data

        //  (),(a),(b),(c),(d) - (a,b)(a,c)(a,d)...
        // 
        //syntax : accestype classname ([list of parameters]) {constructor code block}

        //IMPORTANT:  The constructor DOES NOT have a return datatype
        //              You do not call a constructor directly, it is called using the
        //              new command => new classname (.....);

        //DEFAULT Constructor

        public Employment ()
        {
            //constructor body
            //a) empty: values will be set to C# defaults
            // b) you Could assign literal values to your properties with this constructor
            //The values that you give your class data member/properties CAN be assigned 
            //directly to a data member
            //HOWEVER: if you have validated properties, you SHOULD consider saving your
            // date values via the property

            //you CAN code your validation logic within your constructors BECAUSE
            // objects run your constructor when it is created

            //Placing your logic in the constructor could be done if your property has
            //   a private set OR if your public data member is a readonly data member
            //Private sets and readonly data members CAN NOT have their data altered directly

            Level = SupervisoryLevel.TeamMember;
            Title = "Unknown";
        }

        //GREEDY CONSTRUCTOR

        public Employment (string title, SupervisoryLevel level, double years)
        {


            //constructor body
            // a) a parameter for each property
            //b)you could code your validation in this constructor
            // c) validation for publicreadonly data members AND
            //  validation for properties with a private set must be done here
            //      if not done in the property
            Title = title;
            Years = years; //eventually the data will be placed in _Years
            Level = level;
        }
    }
}
