using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioSite.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace PortfolioSite.Pages
{
    public class SurveyDataModel : PageModel
    {
        private HttpClient _client;

        public SurveyDataModel(HttpClient client)
        {
            _client = client;
        }

        public List<Survey> Surveys { get; set; }
        public async  Task<IActionResult> OnGetAsync()
        {
            var response = await _client.GetAsync("http://localhost:5193/api/survey");
            var result = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<List<Survey>>(result);
            Surveys = model;
            return Page();
        }


    }
}
