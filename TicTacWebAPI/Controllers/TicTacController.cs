using Microsoft.AspNetCore.Mvc;
using System;
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
            try
            {
                var result = _ticTacService.Post(requestModel);
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
