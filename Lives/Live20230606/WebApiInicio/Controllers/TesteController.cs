using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiInicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        [HttpGet("Exemplo1")]
        public IActionResult ConsultarExemplo1()
        {
            string[] listaCidades = new string[] { "São Paulo", "Ibiuna", "São Roque"};

            return Ok(listaCidades);
        }


        [HttpGet("Exemplo2")]
        public IActionResult ConsultarExemplo2()
        {
            return Ok("São Paulo Ibiuna Sao Roque");
        }
    }
}
