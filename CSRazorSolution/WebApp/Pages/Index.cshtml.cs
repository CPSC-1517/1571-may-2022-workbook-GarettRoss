using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    //this web page Model class inherits from PageModel
    public class IndexModel : PageModel
    {
        //this default page uses a system class called ILogger at <T>
        //this is composition 
        private readonly ILogger<IndexModel> _logger;

        //constructor
        //this constructor receives an injection of a service
        //this injection is refered to as Injection Dependency
        //this is a local field

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //this is a local property
       public string MyName { get; set; }
        
        //this is a class behaviour (method)
        //this method, OnGet() executes for any Get Request
        //this method wil be the first methos executed when the page is first used
        //excellent "event" to use to do any initialization to your web page display
        public void OnGet()
        {
            //once in the request method, you are in control of what is being processed on the webpage for the current request
            Random rnd = new Random();
            int value = rnd.Next(0,100);//100 not included
            if (value % 2 ==0 )
            {
                MyName = $"Garett ({value}) welcome to the wide world of Razor.";
                    
            }
            else
            {
                MyName = null;
            }
            //control is returned to the web server
        }
    }
}