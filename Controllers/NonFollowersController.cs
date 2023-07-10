using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("[controller]")]
    [ApiController]
    public class NonFollowersController : ControllerBase
    {

        [HttpGet()]
        public async Task<ActionResult<string>> Consultar()
            => "testeeeee";
    }
}
