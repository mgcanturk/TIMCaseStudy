using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TIMCaseStudy.Application.Repositories;
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
        [HttpPost]
        [Route("BookFilter")]
        public async Task<IActionResult> BookFilter([FromBody] BookFilterCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost]
        [Route("BookTransaction")]
        public async Task<IActionResult> BookTransaction([FromBody] CreateBookTransactionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
