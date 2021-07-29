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
    public class VendorController  : BaseController
    {

         private ApplicationDbContext _context ;

        public VendorController(ApplicationDbContext context)
        {
          _context = context;   
        }
        
        [HttpPost]
        [Route("Sample/AddVendors")]
        public IActionResult AddVendor([FromBody] AddVendorDto addVendorDto)
        {
            try
            {
                var command = new AddVendorCommand(addVendorDto, _context);
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
        [Route("Sample/Vendors")]
        public IActionResult GetVendors()
        {
            try
            {
                var query = new GetVendorsQuery( _context);
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