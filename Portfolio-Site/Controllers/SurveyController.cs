using Microsoft.AspNetCore.Mvc;
using PortfolioSite.Models;
using PortfolioSite.Services;
using MongoDB.Driver;

namespace PortfolioSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly SurveyService _surveyService;
        public SurveyController(SurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpGet]
        public async Task<List<Survey>> Get()=>
            await _surveyService.GetAsync();

        //[HttpGet("{id:length(24)}")]
        //public async Task<ActionResult<Survey>> Get(string id)
        //{
        //    var survey = await _surveyService.GetAsync(id);

        //    if (survey is null)
        //    {
        //        return NotFound();
        //    }

        //    return survey;
        //}

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(Survey newSurvey)
        {
            await _surveyService.CreateAsync(newSurvey);

            return CreatedAtAction(nameof(Get), new { id = newSurvey.Id }, newSurvey);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Survey updatedSurvey)
        {
            var survey = await _surveyService.GetAsync(updatedSurvey.Id, updatedSurvey.Password);

            if (survey is null)
            {
                return NotFound();
            }

            updatedSurvey.Id = survey.Id;

            await _surveyService.UpdateAsync(updatedSurvey);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> delete(DeleteSurvey delete)
        {
            var survey = await _surveyService.GetAsync(delete.Id,delete.Password);

            if (survey is null || survey.Password is null)
            {
                return NotFound();
            }

            await _surveyService.RemoveAsync(survey.Id,survey.Password);

            return NoContent();
        }
    }
}
