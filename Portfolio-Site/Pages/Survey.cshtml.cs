using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PortfolioSite.Models;
using System.Text;

namespace PortfolioSite.Pages
{
    public class SurveyModel : PageModel
    {
        private readonly HttpClient _client;

        public SurveyModel(HttpClient client)
        {
            _client = client;
        }
        public void OnGet()
        {
            
        }
        [BindProperty]
        public Survey Survey { get; set; }  
        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(Survey);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync("https://nicholas-nowosad-portfolio-site.azurewebsites.net/api/survey", data);
                if (response.IsSuccessStatusCode)
                {
                    return Redirect("/PostSuccess");
                }
                else
                    return Page();
            }

            return Page();
        }
    }
}
