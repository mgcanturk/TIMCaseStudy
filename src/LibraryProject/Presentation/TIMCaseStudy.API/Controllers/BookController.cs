using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TIMCaseStudy.Application.Features.Queries.Book;
using TIMCaseStudy.Application.Repositories;
using TIMCaseStudy.Common.Infrastructure.Results;
using TIMCaseStudy.Common.Models.Queries;
using TIMCaseStudy.Common.Models.RequestModels;

namespace TIMCaseStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("BookFilter")]
        public async Task<IActionResult> BookFilter([FromQuery] GetBookFilterQuery query)
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
        [HttpPost]
        [Route("BookTransaction")]
        public async Task<IActionResult> BookTransaction([FromBody] CreateBookTransactionCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
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
