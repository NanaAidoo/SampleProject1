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
    public class PaymentController  : BaseController
    {
        private ApplicationDbContext _context ;

        public PaymentController(ApplicationDbContext context)
        {
          _context = context;   
        }
        [HttpPost]
        [Route("Sample/AddPayments")]
        public IActionResult AddPayment([FromBody] AddPaymentDto addPaymentDto)
        {
            try
            {
                var command = new AddPaymentCommand(addPaymentDto, _context);
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
        [Route("Sample/Payments")]
        public IActionResult GetPayments()
        {
            try
            {
                var query = new GetPaymentsQuery( _context);
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