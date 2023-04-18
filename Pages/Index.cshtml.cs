using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]

        public FizzBuzzForm FizzBuzz { get; set; }

        [BindProperty(SupportsGet =true)]

        public String Name { get; set; }

        public String AlertMessgae { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public IActionResult OnPost()
        {
            var List = new List<FizzBuzzForm>();

            var sessionData = HttpContext.Session.GetString("Data");
            if(!string.IsNullOrWhiteSpace(sessionData))
            {
                List = JsonConvert.DeserializeObject<List<FizzBuzzForm>>(sessionData);
            }

            List.Add(FizzBuzz);

            if(FizzBuzz.Year == 0)
            {
                ModelState.Remove("FizzBuzz.Year");
                ModelState.AddModelError("FizzBuzz.Year", "Pole Rok urodzenia nie może być puste");
            }
            /*if(!ModelState.IsValid)
            {
                AlertMessgae = "Podane wartości są nieprawidłowe";
                return Page();  
            }*/

            FizzBuzz.checkYear();
            HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(List));

            if (FizzBuzz.leapYear)
            {
                AlertMessgae = $"{FizzBuzz.Name} urodził/a się w {FizzBuzz.Year} roku. To był rok przestępny.";
            }
            else
            {
                AlertMessgae = $"{FizzBuzz.Name} urodził/a się w {FizzBuzz.Year} roku. To nie był rok przestępny.";
            }

            return Page();  

        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
        }
    }
}