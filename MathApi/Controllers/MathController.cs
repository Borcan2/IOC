using Microsoft.AspNetCore.Mvc;
using MathApi.Models;

namespace MathApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class MathController : ControllerBase
    {

        [HttpPost]
        public ActionResult<MathResponseDTO> Calculate(MathRequestDTO request)
        {

            if (request == null)
            {
                return BadRequest("Request cannot be null");
            }

            int result;

            if(request.Operation == "add")
            {
                result = request.Number1 + request.Number2;
                
            }
            else if(request.Operation == "subtract")
            {
                result = request.Number1 - request.Number2;
            }
            else if(request.Operation == "multi")
            {
                result = request.Number1 * request.Number2;
            }
            else if(request.Operation == "div")
            {
                result = request.Number1 / request.Number2;
            }
            else
            {
                return BadRequest("Invalid Operation");
            }
            var response = new MathResponseDTO
            {
                Result = result,
            };
            return Ok(response);
        }
    }
}