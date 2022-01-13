using System;
using System.Collections.Generic;

#nullable disable

namespace senai.BRALOG.webApi.Domains
{
    public partial class Entrega
    {
        public int IdEntrega { get; set; }
        public int? IdProduto { get; set; }
        public int? IdUsuário { get; set; }
        public int? IdCliente { get; set; }
        public int? IdTipoPag { get; set; }
        public int? IdEstado { get; set; }
        public string Cidade { get; set; }
        public int? QtdTotal { get; set; }
        public string ValorTotal { get; set; }
        public DateTime Data { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual Produto IdProdutoNavigation { get; set; }
        public virtual TipoPagamento IdTipoPagNavigation { get; set; }
        public virtual Usuario IdUsuárioNavigation { get; set; }
    }
}
