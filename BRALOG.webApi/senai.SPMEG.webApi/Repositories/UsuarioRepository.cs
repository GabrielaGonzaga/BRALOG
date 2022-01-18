using BRALOG.webApi.Contexts;
using BRALOG.webApi.Domains;
using senai.BRALOG.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.BRALOG.webApi.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        BRALOGContext ctx = new BRALOGContext();

        public void Cadastrar(Usuario novoUsuario)
        {
            novoUsuario.Senha = Criptografia.CalculaHash(novoUsuario.Senha);
            Usuario conf = ctx.Usuarios.FirstOrDefault(a => a.Email.ToLower() == novoUsuario.Email.ToLower());

            if (conf == null)
            {
                ctx.Usuarios.Add(novoUsuario);
                ctx.SaveChanges();
            }
        }

        public Usuario Login(string email, string senha)
        {
            Usuario usuario = ctx.Usuarios.FirstOrDefault(a => a.Email == email && a.Senha == senha);
            return usuario;
        }
    }
}
