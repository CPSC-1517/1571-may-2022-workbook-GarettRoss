using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview.Data
{
    public class Employment
    {
        //An instance of this class will hold data about a person's
        //  employment
        //The code of this class is the definition of that data
        //The characteristics (data) of the class
        //  Title, SupervisorLevl, Years of employment within the company

        //there are 4 components of a class definition
        //  data fields (data members)
        //  property
        //  constructor
        //  behaviour (method)

        //data fields
        //  are storage areas in your class
        //  these are treated as variables
        //  these may be public, private, public readonly
        private string _Title;
        private double _Years;

        //property
        //These are access techniques to retrieve or set data in
        //  your class without directly touching the storage data field

        //A property is associated with a single instance of data
        //A property is public so it can be access by an outside user
        //  of the class
        //A property MUST have a get
        //A property MAY have a set
        //  if no set, the property is not changable by the user; readonly
        //      commonly used for calculated data of the class
        //  the set can be either public or  private
        //     public: the user can alter the contents of the data
        //     private: only code within the class can alter the contents of the data

        //fully implemented property

        // a) a declared storage area (data field)
        // b) a declared property signature (access rdt propertyname)
        // c) a coded accessor (get) coding block : public
        // d) an optional coded mutator (set) coding block :pubic or private
        //     if the set is private the only way to place data into this property is
        //      via the constructor or a behaviour (method)

        //When:
        //  a) if you are storing the associate data in an explicitly declared data field
        //  b) if you are doing validation on incoming data
        //  c) creating a property that generates output from other data sources
        //      within the class (readonly property); this property would ONLY have a
        //      accessor (get)

        public string Title
        {
            //a property is assoicated with a single piece of data
            get
            {
                //accessor
                //the get "coding block" will return the contents of a data field(s)
                //the return has syntax of    return expression
                return _Title;
            }
            set
            {
                //mutator
                //the set "coding block" receives an incoming value and places it into the
                //  associated data field
                //during the setting, you might wish to validate the incoming data
                //during the setting, you might wish to do some type of logical
                //  processing using the data to set another field
                //the incoming piece of data is referred to using the keyword "value"

                //ensure that the incoming data is not null or empty or just whitespace
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is a required piece of data.");
                }

                //data is consider valid
                _Title = value;
            }
        }

        //auto implemented property

        //these properties differ only in syntax
        //each property is responsible for a single piece of data
        //these properties do NOT reference a declared private data member
        //the system generates an internal storage area of the return data type
        //the system manages the interal storage for the accessor and mutator
        //THERE IS NO ADDITIONAL LOGIC APPLIED TO THE DATA VALUE !!!!!

        //using an enum for this field will automatically restrict the values
        //  this property can contain

        //syntax  access rdt propertyname {get; [private] set;}

        public SupervisoryLevel Level { get; set; }

        public double Years
        {
            get { return _Years; }
            set
            {
                if (!Utilities.IsZeroPositive(value))
                {
                    throw new ArgumentOutOfRangeException($"Years of {value} is invalid. Must be 0 or greater");
                }
                _Years = value;
            }
        }

        //constructor

        //this is used to initialize the phyiscal object (instance) during its creation
        //the result of creation is to ensure tha the coder gets an instance in a valid
        //  "known state"
        //
        //if your class definition has NO constructor coded, the the data memebers and/or
        //  auto implemented properties are set to the C# default data type value
        //
        //You can code one or more constructors in your class definition
        //IF YOU CODE A CONSTRUCTOR FOR THE CLASS, YOU ARE RESPONSIBLE FOR ALL
        //  CONSTRUCTORS USED BY THE CLASS !!!!
        //
        //generally, if you are going to code your own constructor(s) you code two types
        //  Default: this constructor does NOT take in any parameters
        //           this constructor mimics the default system constructor
        //  Greedy:  this constructor has a list of parameters, one for each property, 
        //           declare for incoming data
        //
        //   (),(a),(b),(c),(d),(a,b)(a,c)(a,d)... 2 raise power of 4 = 16 contructors
        //   (),(a,b,c,d)
        //
        // syntax: accesstype classname([list of parameters]) {constructor code block}
        //
        //IMPORTANT: The constructor DOES NOT have a return datatype
        //           You DO NOT call a constructor direclty, it is called using the 
        //              new command =>    new classname(....);
        //
        //Default constructor
        public Employment()
        {
            //constructor body
            //  a) empty: values will be set to C# defaults
            //  b) you COULD assign literal values to your properties with this constructor

            // the values that you give your class data members/properties CAN be assigned
            //      directly to a data member
            //HOWEVER: if you have validated properties, you SHOULD consider saving your
            //          data values via the property

            //You CAN code your validation logic within your constructors BECAUSE objects
            //  run your constructor when it is created.
            //Placing your logic in the constructor could be done if your property has
            //  a private set OR if your public data member is a readonly data member
            //Private sets and readonly data members CAN NOT have their data altered directly

            Level = SupervisoryLevel.TeamMember;
            Title = "Unknown";
        }



        //Greedy Constructor
        public Employment(string title, SupervisoryLevel level, double years = 0.0)
        {
            //constructor body
            //  a) a parameter for each property
            //  b) you COULD could your validation in this constructor
            //  c) validation for public readonly data members MUST be done here
            //  d) validation for properties with a private set MUST be done here
            //      if not done in the property

            //default parameters

            //WHY? it allows the programer to use your constructor/method with having to
            //  specify all argument in the code to your constructor/method

            //Location: end of parameter list
            //How many: as many as you wish
            //values for your default parameters MUST be a valid value
            //position and order of specified default parameters are important when the
            //  program uses the constructor/method. 
            //default parameters CAN be skipped, HOWEVER, you still must account for the
            //  skipped parameter in your argument call list using commas
            //by giving the default parameter an argument value on the call, the constructor/method
            //  default value is overridden

            //syntax: datatype parametername = default value
            //example: years on this constructor is a default parameter

            //example: skipped defaults (3 default parameters, second one skipped
            //    ...(string requiredparam, int requiredparam, int default1 = 0,
            //          int default2 = 0 , int default 3 = 1)
            //
            //call:  ...("required string", 25, 10, , 5)  default2 was skipped

            Title = title;
            Level = level;
            Years = years; //eventually the data will be placed in _Years

        }

        //Behaviours (a.k.a. methods)

        //a behaviour is any method in your class
        //behaviours can be private (for use by the class only); public (for use by the outside
        //  user)
        //all rules about methods are in effect

        //a special method may be placed in your class to reflect the data stored by the 
        //  instance (object) based on this class definition
        //this method is part of the system software and can be overriden by your own
        //  version of the method

        public override string ToString()
        {
            //this string is known as a "comma separate values (csv)" string
            //this string uses the get; of the property
            return $"{Title},{Level},{Years}";
        }

        public void SetEmploymentResponsibilityLevel(SupervisoryLevel level)
        {
            //this method, in this example would not be necessary as the access directly
            //  the Level (property) is public ( set; )
            //HOWEVER: IF the Level property had a private set;, the outsider user would NOT
            //  have direct access to changing the property.
            //THERFORE: a method (besides the constructor) would need to be supplied to allow
            //  the outsider user the ability to alter the property value (if they so desired)

            //this assignment uses the set; of the property
            Level = level;
        }

        //Parse(string)
        //  attempt to change the contents of string to another data type
        //  no condition was checked before doing the change
        //  example  string 55; int x = int.Parse(string); success
        //           string bob; int x = int.Parse(string); aborted

        //bool TryParse(string, out resultvariable)
        //  check to see if the Parse could actually be done
        //  the result of the attempt was
        //  a) true and the converted string value placed into the resultvariable
        //  b) false and no conversion of the string AND NO abort
        //
        //  int resultvariable = 0;
        //  if(TryParse(string, out resultvariable) { ....... }

        //classes are a developer defined datatype just like int, double, ...
        //therefore, should a class be able to take a string can convert it into
        //   an instance of the class?
        //CAN a class have their own .Parse and .TryParse
        //
        //string: "Boss,Owner,5.5" parsed into an instance of Employment
        //

        //Employment.Parse(string)
        //the method will:
        //  validate there are sufficient values for an instance
        //  will us primitive datatype .Parse() to convert the individual values
        //  will return a loaded instance of the Employment class
        //  will use the FormatException() if insufficient data is supplied

        //as the instance is loaded on the return statement, the Employment constructor
        //  will be used thus any error generated by the constructor shall still be
        //  created

        //THIS METHOD WILL NOT RETAIN ANY DATA
        //THIS METHOD WILL BE A SHARED METHOD ( static )
        public static Employment Parse(string text)
        {
            //text is a string of csv values (comma separated values)
            //   value1,value2,value3,.....
            //Step1 separate the string of values into individual string values
            //  the result will be an array of strings
            // each array element represents a value
            // the string class method .Split(delimiter) is use for this action
            // a delimiter can be ANY C# recongized character
            // in a csv string, the delimiter character is a comma
            string[] pieces = text.Split(',');

            //step 2 verify that sufficient values exist to create the Employment instance
            if (pieces.Length != 3)
            {
                throw new FormatException($"String not in expected format. Missing value {text}");
            }

            //step 3 return a new instance of the Employment class
            // create a new instance on the return statement
            // as the instance is being created, the Employment constructor will be used
            // ANY validation occuring during the execution of the constructor will still be
            //      done, whether the logic is in the constructor OR in the individual property
            // use the primitive .Parse() methods for C# datatypes ie int, double, ...
            return new Employment(
                        pieces[0],
                        (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), pieces[1]),
                        double.Parse(pieces[2]));
        }

        //the TryParse () method will receive a string and output an instance of
        //employment as an output parameter
        //
        //syntax of a TryParse:   xxxx.TryParse(string, out receiving variable)
        //               int example  int.TryParse(input data, out myIntegerNumber

        //xxx can be any data type
        // Can xxxx be a class; yes - a class is a developer defined datatype

        //the mthod will return a boolean value indicating if the action with 
        //the method was successful
        // the action within the method will be to call the .parse() method
        //this is the same concept of parcing primitive data types already in c#

        public static bool TryParse(string text, out Employment result)
        {
            //why the value null?
            //the default value for any class instance (the object) is null
            result = null;

            bool valid = false;

            try
            {
                if (string.IsNullOrWhiteSpace(text))
                { throw new ArgumentNullException("Parsing string is empty"); }
                //action : try to parse the string using .parse()
                result = Parse(text);
                valid = true;
            }
            catch (FormatException ex)
            {
                //Do not print out the error
                //Instead rethrow the exception
                //think of this a s a relay race - passing the baton
                //this method DOES NOT actually handle the display of the error
                //the display of an error message is done by the driver routine (in
                //out case is the code in Program.cs
                throw new FormatException(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
                {
                throw new ArgumentOutOfRangeException(ex.Message);
            }
            catch (Exception ex)
            {
                //handle any other unexpected error
                throw new Exception($"TryParse Employment unexpected error: {ex.Message}");
            }
            return valid;

        }






    }
}
