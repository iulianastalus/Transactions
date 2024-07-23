using Microsoft.AspNetCore.Mvc;
using MediatR;
using Transactions.Application.Queries;
using Transactions.Application.Commands;
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

        [HttpGet]
        public async Task<IActionResult> GetAll(GetTransactionsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadTransactions()
        {
            if (Request.Form.Files.Any()) 
            {
                var file = Request.Form.Files[0];
                var transactions = _csvService.ReadCSV<List<AddTransactionCommand>>(file.OpenReadStream());
                foreach (var transaction in transactions)                 
                    await _mediator.Send(transaction);
                
                return Ok();
            }
            return Ok();
        }
    }
}
