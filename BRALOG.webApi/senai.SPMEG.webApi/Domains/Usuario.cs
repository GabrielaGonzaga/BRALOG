using System;
using System.Collections.Generic;

#nullable disable

namespace BRALOG.webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Clientes = new HashSet<Cliente>();
            Entregas = new HashSet<Entrega>();
            Produtos = new HashSet<Produto>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsu { get; set; }
        public string Nome { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TiposUsuario IdTipoUsuNavigation { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Entrega> Entregas { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
