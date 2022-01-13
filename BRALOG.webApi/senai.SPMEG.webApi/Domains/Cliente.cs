using System;
using System.Collections.Generic;

#nullable disable

namespace senai.BRALOG.webApi.Domains
{
    public partial class Cliente
    {
        public Cliente()
        {
            Entregas = new HashSet<Entrega>();
        }

        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string NomeCompleto { get; set; }
        public string Telefone { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }

        public virtual ICollection<Entrega> Entregas { get; set; }
    }
}
