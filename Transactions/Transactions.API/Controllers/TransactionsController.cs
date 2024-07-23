using Microsoft.AspNetCore.Mvc;
using MediatR;
using Transactions.Application.Queries;
using Transactions.Application.Commands;
using Transactions.Application.Interfaces;
using System.Collections.Generic;

namespace Transactions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICSVService _csvService;
        private readonly IXMLService _xmlService;
        public TransactionsController(IMediator mediator,ICSVService csvService, IXMLService xmlService)
        {
            _mediator = mediator;
            _csvService = csvService;
            _xmlService = xmlService;
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
                var transactions = new List<AddTransactionCommand>();
                switch (Path.GetExtension(file.FileName))
                {
                    case "csv":
                        transactions = _csvService.ReadCSVFile<AddTransactionCommand>(file.OpenReadStream()).ToList();
                        break;
                    case "xml":
                        transactions = _xmlService.ReadXMLFile<AddTransactionCommand>(file.OpenReadStream()).ToList();
                        break;
                    default:
                        throw new Exception();
                }                
                foreach (var transaction in transactions)                 
                    await _mediator.Send(transaction);
                
                return Ok();
            }
            return Ok();
        }
    }
}
