using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzBuzzWeb.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public List<FizzBuzzForm> FizzBuzzs { get; set; }   
        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Data");

            if (!string.IsNullOrEmpty(Data))
            {
                FizzBuzzs = JsonConvert.DeserializeObject<List<FizzBuzzForm>>(Data);
            }
        }
    }
}
