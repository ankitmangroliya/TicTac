using Microsoft.AspNetCore.Mvc;
using TicTac.WebAPI.Models;
using TicTac.WebAPI.Services;

namespace TicTac.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicTacController : ControllerBase
    {
        private readonly ITicTacService _ticTacService;

        public TicTacController(ITicTacService ticTacService)
        {
            _ticTacService = ticTacService;
        }

        [HttpPost]
        public IActionResult Post(RequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                var result = _ticTacService.Post(requestModel);
                return new JsonResult(result);
            }

            return BadRequest(ModelState);
        }
    }
}
