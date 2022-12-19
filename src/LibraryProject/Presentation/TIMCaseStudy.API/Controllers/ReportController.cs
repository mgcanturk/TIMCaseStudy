using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using TIMCaseStudy.Common.Infrastructure.Results;
using TIMCaseStudy.Common.Models.RequestModels;
using TIMCaseStudy.Application.Features.Queries.DailyReport;

namespace TIMCaseStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("DailyReport")]
        public async Task<IActionResult> DailyReport([FromQuery] GetDailyReportQuery query)
        {
            try
            {
                var result = await _mediator.Send(query);
                var response = new ApiResponseModel
                {
                    StatusCode = 200,
                    IsResult = true,
                    Result = result
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponseModel
                {
                    StatusCode = 500,
                    IsResult = false,
                    ErrorMessage = ex.Message
                };
                return StatusCode(500, response);
            }
        }
    }
}
