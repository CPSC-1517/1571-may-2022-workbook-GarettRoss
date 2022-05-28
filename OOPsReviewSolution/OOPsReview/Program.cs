// See https://aka.ms/new-console-template for more information
//this class program is by default in the namepsace of the project:  OOPsReview







//an instance class needs to be creates using the 'new' command and the class constructor
//one needs to declare a variable of class datatype: ex Employment
//using the "using statement means that one does not need to fully qualify on each 
//  usage of the class


using OOPsReview.Data;

// a fully qualified reference to employment
// consists of the namespace.classname (just do using OOPsReview.Data;)
//OOPsReview.Data.Employment myEmp = new Employment("Level 5 Programer", SupervisoryLevel.Supervisor, 15.9);

Employment myEmp = new Employment("Level 5 Programer", SupervisoryLevel.Supervisor, 15.9);//default constructor

Console.WriteLine(myEmp.ToString());//use the instance name to reference items within your class
Console.WriteLine($"{myEmp.Title},{myEmp.Level},{myEmp.Years}");


myEmp.SetEmploymentResponsibilityLevel(SupervisoryLevel.DepartmentHead);


Console.WriteLine(myEmp.ToString());

//testing (simulate a unit test)

//Arrange (Set up of test data)
Employment Job = null;

//passing a reference variable to a method
//a class is a reference store
//this passes the actual memory address of the data store to the method
//ANY changes done to the data store within the method WILL be reflected in the
//  data store WHEN you return from the method

CreateJob(ref Job);
Console.WriteLine(Job.ToString());
//passing value argguements to a method AND receiving a value result back from 
// the method
// struct is a value data store

ResidentAddress Address = CreateAddress();
Console.WriteLine(Address.ToString());
//Act (execution of the test you wish to perform)
//test that we can create a person
Person me = null; // a variable of capable of holding a PErson instance
me = CreatePerson(Job, Address);

//Assess (Check you results)
Console.WriteLine($"{me.FirstName} {me.LastName} lives at {me.Address.ToString()}" +
    $"having a job count of {me.NumberOfPositions}");


    void CreateJob(ref Employment job)
{
    //since the class may throw exceptions, you should have user friendly error handling
    try
    {
        job = new Employment(); //default constructor; 'new' command takes a constructor as it's 
        //BECAUSE my properties have public set (mutators), I can "set" the value of the 
        //  property directly from the driver program
        job.Title = "Boss";
        job.Level = SupervisoryLevel.Owner;
        job.Years = 25.5;

        //OR

        //Use the Greedy constrcutor
        //job = new Employment("Boss", SupervisoryLevel.Owner, 25.5);
    }
    catch (ArgumentNullException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (ArgumentOutOfRangeException ex)

    {
        Console.WriteLine(ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

ResidentAddress CreateAddress()
{
    //greedy constructor
    ResidentAddress address = new ResidentAddress(10706, "106 st", "", "", "Edmonton", "AB");
    return address;
}

Person CreatePerson(Employment job, ResidentAddress address)
{
    Person me = new Person("Don", "Welch",address,  null);
    me.AddEmployment(job);
    return me;
}