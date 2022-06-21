using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Samples
{
    public class BasicDataManagementModel : PageModel
    {
        [BindProperty]
        public int Num { get; set; }
        [BindProperty]
        public string MassText { get; set; }
        public string Feedback { get; set; }
        public void OnGet()
        {
            //BindProperty is an annotation that handles two way data transfer
            // two-way? means output to form for display AND input from form for processing



            if (Num == 0)
            {
                Feedback = "executing the OnGet method for the Get request";
            }
            else
            {
                Feedback = $"You entered the value {Num} displayed by OnGet";
            }
        }
            public void OnPost()
            {
                Feedback = $"You entered the value {Num} display by OnPost\n" +
                    $" This is the {MassText}";
            }
        }
    }

