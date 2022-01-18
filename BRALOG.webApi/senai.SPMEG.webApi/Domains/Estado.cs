using System;
using System.Collections.Generic;

#nullable disable

namespace BRALOG.webApi.Domains
{
    public partial class Estado
    {
        public Estado()
        {
            Clientes = new HashSet<Cliente>();
            Entregas = new HashSet<Entrega>();
        }

        public int IdEstado { get; set; }
        public string Sigla { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Entrega> Entregas { get; set; }
    }
}
