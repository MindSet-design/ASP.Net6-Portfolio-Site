using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioSite.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;

namespace PortfolioSite.Pages
{
    public class SurveyDataModel : PageModel
    {
        private readonly HttpClient _client;

        public SurveyDataModel(HttpClient client)
        {
            _client = client;
        }
        
        public List<Survey>? Surveys { get; set; }
        public async  Task<IActionResult> OnGetAsync()
        {
            var response = await _client.GetAsync("http://localhost:5193/api/survey");
            var result = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<List<Survey>>(result);
            Surveys = json;
            return Page();
        }

        [BindProperty]
        public DeleteSurvey Delete { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            var json = JsonConvert.SerializeObject(Delete);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("http://localhost:5193/api/survey", data);
            return Redirect("/SurveyData");
        }

    }
}
