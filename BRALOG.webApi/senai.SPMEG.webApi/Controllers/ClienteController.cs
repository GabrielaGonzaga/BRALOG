using Microsoft.AspNetCore.Mvc;
using senai.BRALOG.webApi.Domains;
using senai.BRALOG.webApi.Interfaces;
using senai.BRALOG.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.BRALOG.webApi.Controllers

{    
    [Produces("application/json")]
     [Route("api/[controller]")]
     [ApiController]
    public class ClienteController : Controller
    {
        private ICliente _cliente{ get; set; }

        public ClienteController()
        {
            _cliente = new ClienteRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(Cliente novoCliente)
        {
            try
            {
                _cliente.Cadastrar(novoCliente);
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
                return Ok(_cliente.Listar());
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
                return Ok(_cliente.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Cliente clienteAtualizado)
        {
            try
            {
                _cliente.Atualizar(clienteAtualizado);
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
                _cliente.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
