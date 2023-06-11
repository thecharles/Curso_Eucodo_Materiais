using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiInicio.Models;

namespace WebApiInicio.Controllers
{





    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        [HttpPost("crirnovocliente")]
        public IActionResult Errado_CriarNovoCliente([FromBody] ClienteModel cliente)
        {
            // Salvar no banco de dados
            return Ok(cliente);
        }

        [HttpPut("atualizarcliente/{id}")]
        public IActionResult Errado_AtualizarCliente([FromRoute] int id, [FromBody] ClienteModel cliente)
        {



            return Ok(cliente);
        }




        [HttpPost]
        public IActionResult CriarNovoCliente([FromBody] ClienteModel cliente)
        {
            // Salvar no banco de dados

            if (cliente.Email == "charles@gmail.com")
            {
                ResponsePadrao response = new ResponsePadrao();
                response.Sucesso = false;
                response.Mensagem = $"Já existe um cliente com o email passado ({cliente.Email})";
                return BadRequest(response);
            }

            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCliente([FromRoute] int id, [FromBody] ClienteModel cliente)
        {

            bool acheiCliente = id == 3;
            if(!acheiCliente)
            {
                return NotFound("Cliente não encontrado");
            }

            bool naoAcheiTelefone = false;
            if(!naoAcheiTelefone)
            {
                return BadRequest("Nao achei o telefone no cadastro do cliente");
            }

            bool temPermissao = this.User.Id == cliente.IdUsuario;
            if(!temPermissao)
            {
                return Unauthorized("Vc não tem permissão para editar esse cliente");
            }

            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            return Ok("Excluido com sucesso");
        }

        [HttpGet("{id}")]
        public IActionResult Consultar(int id)
        {
            ClienteModel novoCliente = new ClienteModel();

            novoCliente.Nome = "Charles";
            novoCliente.Email = "charles@gmail.com";
            novoCliente.Telefone = "11997886688";

            return Ok(novoCliente);
        }


        [HttpPost("{id}/email-reset")]
        public IActionResult DispararEmail([FromRoute] int id)
        {
            ClienteModel novoCliente = new ClienteModel();

            novoCliente.Nome = "Charles";
            novoCliente.Email = "charles@gmail.com";
            novoCliente.Telefone = "11997886688";

            return Ok(novoCliente);
        }
    }
}
