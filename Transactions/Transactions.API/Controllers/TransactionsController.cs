using Microsoft.AspNetCore.Mvc;
using MediatR;
using Transactions.Application.Queries;
using Transactions.Application.Interfaces;

namespace Transactions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICSVService _csvService;
        public TransactionsController(IMediator mediator,ICSVService csvService)
        {
            _mediator = mediator;
            _csvService = csvService;
        }
        public async Task<IActionResult> GetAll(GetTransactionsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UploadTransactions()
        {
            if (Request.Form.Files.Any()) 
            {
                var file = Request.Form.Files[0];
                return Ok();
            }
            return Ok();
        }
    }
}
