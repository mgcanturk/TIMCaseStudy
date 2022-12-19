using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TIMCaseStudy.Application.Features.Queries.Book;
using TIMCaseStudy.Application.Features.Queries.GetAuthors;
using TIMCaseStudy.Common.Infrastructure.Results;
using TIMCaseStudy.Common.Models.RequestModels;

namespace TIMCaseStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("GetAllAuthors")]
        public async Task<IActionResult> GetAllAuthors([FromQuery] GetAuthorQuery query)
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
