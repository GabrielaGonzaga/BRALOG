using System;
using System.Collections.Generic;

#nullable disable

namespace senai.BRALOG.webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Entregas = new HashSet<Entrega>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsu { get; set; }
        public string Nome { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuNavigation { get; set; }
        public virtual ICollection<Entrega> Entregas { get; set; }
    }
}
