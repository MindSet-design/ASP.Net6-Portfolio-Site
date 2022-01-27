using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PortfolioSite.Pages
{
    public class PostSuccessModel : PageModel
    {
        public IActionResult OnPost()
        {
            return Redirect("/SurveyData");
        }
    }
}
