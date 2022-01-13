using senai.BRALOG.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.BRALOG.webApi.Interfaces
{
    public interface IUsuario
    {
        public void Cadastrar(Usuario novoUsuario);
        public Usuario Login(string email, string senha);
    }
}
