using System;
using System.Collections.Generic;

#nullable disable

namespace BRALOG.webApi.Domains
{
    public partial class TiposPagamento
    {
        public TiposPagamento()
        {
            Entregas = new HashSet<Entrega>();
        }

        public int IdTipoPag { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Entrega> Entregas { get; set; }
    }
}
