using System;
using System.Collections.Generic;

#nullable disable

namespace BRALOG.webApi.Domains
{
    public partial class Produto
    {
        public Produto()
        {
            Entregas = new HashSet<Entrega>();
        }

        public int IdProduto { get; set; }
        public int? IdUsuario { get; set; }
        public string Descricao { get; set; }
        public string Valor { get; set; }
        public int? Qtd { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Entrega> Entregas { get; set; }
    }
}
