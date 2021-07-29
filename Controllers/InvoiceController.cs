using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleProject1.Commands;
using SampleProject1.Commands.Dtos;
using SampleProject1.Data;
using SampleProject1.Exceptions;
using SampleProject1.Queries;

namespace SampleProject1.Controllers
{
    public class InvoiceController  : BaseController
    {

         private ApplicationDbContext _context ;

        public InvoiceController(ApplicationDbContext context)
        {
          _context = context;   
        }

        [HttpPost]
        [Route("Sample/AddInvoices")]
        public IActionResult AddInvoice([FromBody] AddInvoiceDto addInvoiceDto)
        {
            try
            {
                var command = new AddInvoiceCommand(addInvoiceDto, _context);
                var result = command.Handle();
                return OkResult(result);
            }
            catch (DomainException ex)
            {
                return Error(ex.Message);
            }
       
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }  
        }


         [HttpGet]
        [Route("Sample/Invoices")]
        public IActionResult GetInvoices()
        {
            try
            {
                var query = new GetInvoicesQuery( _context);
                var result = query.Handle();
                return Ok(result);
            }
            catch (DomainException ex)
            {
                return Error(ex.Message);
            }
       
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }  
        }
    }
}