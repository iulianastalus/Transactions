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
    public class TransactionsController(IMediator mediator, IFileHandlerService fileHandleService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(GetTransactionsQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadTransactions()
        {
            if (Request.Form.Files.Any()) 
            {
                var file = Request.Form.Files[0];
                var transactions = fileHandleService.HandleFile(file.FileName, file.OpenReadStream());                               
                await mediator.Send(transactions);
                
                return Ok();
            }
            return BadRequest();
        }
    }
}
