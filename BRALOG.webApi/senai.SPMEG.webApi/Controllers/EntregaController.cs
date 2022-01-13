using BRALOG.webApi.Interfaces;
using BRALOG.webApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using senai.BRALOG.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BRALOG.webApi.Controllers
{
        [Produces("application/json")]
        [Route("api/[controller]")]
        [ApiController]
        public class EntregaController : Controller
        {
            private IEntrega _entrega { get; set; }

            public EntregaController()
            {
                _entrega = new EntregaRepository();
            }

            [HttpPost]
            public IActionResult Cadastrar(Entrega novoEntrega)
            {
                try
                {
                    _entrega.Cadastrar(novoEntrega);
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
                    return Ok(_entrega.Listar());
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
                    return Ok(_entrega.BuscarPorId(id));
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            [HttpPut("{id}")]
            public IActionResult Atualizar(Entrega entregaAtualizado)
            {
                try
                {
                    _entrega.Atualizar(entregaAtualizado);
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
                    _entrega.Deletar(id);

                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
        }
    }

