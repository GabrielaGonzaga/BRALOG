using BRALOG.webApi.Domains;
using BRALOG.webApi.Interfaces;
using BRALOG.webApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace BRALOG.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private IProduto _produto { get; set; }

        public ProdutoController()
        {
            _produto = new ProdutoRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(Produto novoProduto)
        {
            try
            {
                _produto.Cadastrar(novoProduto);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_produto.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                return Ok(_produto.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Produto produtoAtualizado)
        {
            try
            {
                _produto.Atualizar(produtoAtualizado);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _produto.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("MeusProdutos")]
        public IActionResult MeusProdutos()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(u => u.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_produto.MeusProdutos(idUsuario));
            }
            catch (Exception erro)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar os produtos se o usuário não estiver logado!",
                    erro
                });
            }
        }
    }
}
