using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.BRALOG.webApi.Domains;
using senai.BRALOG.webApi.Interfaces;
using senai.BRALOG.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.BRALOG.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuario _usuario { get; set; }

          public LoginController()
        {
            _usuario = new UsuarioRepository();
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            if (novoUsuario.Nome == null || novoUsuario.Email == null || novoUsuario.Senha == null)
            {
                return BadRequest();
            }

            _usuario.Cadastrar(novoUsuario);

            return StatusCode(202);
        }


        [HttpPost("Login")]
        public IActionResult Login(Usuario login)
        {
            login.Senha = Criptografia.CalculaHash(login.Senha);

            Usuario usuario = _usuario.Login(login.Email, login.Senha);

            if (usuario == null)
            {
                return StatusCode(404);
            }

            try
            {

                var claims = new[]
                {
                    //new Claim(JwtRegisteredClaimNames.Name, usuario.Nome),
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("CargoX-Authentication"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "CargoX",
                    audience: "CargoX",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(90),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
