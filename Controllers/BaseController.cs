using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleProject1.Commands;

namespace SampleProject1.Controllers
{

    public sealed class Envelope : Envelope<object>
    {
        private Envelope(string errorMessage)
            : base(null, errorMessage)
        {
        }

        public static Envelope<T> Ok<T>(T result)
        {
            return new Envelope<T>(result, null);
        }

        public static Envelope Ok()
        {
            return new Envelope(null);
        }

        public static Envelope Error(string errorMessage)
        {
            return new Envelope(errorMessage);
        }
    }
    public class BaseController : Controller
    {
        protected new IActionResult Ok()
        {
            return base.Ok(Envelope.Ok());
        }

        protected IActionResult Ok<T>(T result)
        {
            return base.Ok(Envelope.Ok(result));
        }

        protected IActionResult Error(string errorMessage)
        {
            return BadRequest(Envelope.Error(errorMessage));
        }
        protected IActionResult Created(string response)
        {
            return StatusCode(StatusCodes.Status201Created, Envelope.Ok(response));
        }
        protected IActionResult FromResult(Result result)
        {
            return result.Success ? Created(result.Response.ToString()) : Error(result.Response.ToString());
        }

        protected IActionResult OkResult(Result result)
        {
            return result.Success ? Ok(result.Response.ToString()) : Error(result.Response.ToString());
        }
    }
}