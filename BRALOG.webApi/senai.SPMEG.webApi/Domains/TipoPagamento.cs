using System;
using System.Collections.Generic;

#nullable disable

namespace senai.BRALOG.webApi.Domains
{
    public partial class TipoPagamento
    {
        public TipoPagamento()
        {
            Entregas = new HashSet<Entrega>();
        }

        public int IdTipoPag { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Entrega> Entregas { get; set; }
    }
}
