using System;
using System.Collections.Generic;

#nullable disable

namespace senai.BRALOG.webApi.Domains
{
    public partial class Estado
    {
        public Estado()
        {
            Entregas = new HashSet<Entrega>();
        }

        public int IdEstado { get; set; }
        public string Sigla { get; set; }

        public virtual ICollection<Entrega> Entregas { get; set; }
    }
}
