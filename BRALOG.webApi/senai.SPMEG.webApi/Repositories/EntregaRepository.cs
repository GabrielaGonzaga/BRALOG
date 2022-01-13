using BRALOG.webApi.Interfaces;
using senai.BRALOG.webApi.Contexts;
using senai.BRALOG.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BRALOG.webApi.Repositories
{
    public class EntregaRepository : IEntrega
    {
        BRALOGContext ctx = new BRALOGContext();

        public void Atualizar(Entrega entregaAtualizado)
        {
            ctx.Entregas.Update(entregaAtualizado);
            ctx.SaveChanges();
        }

        public Entrega BuscarPorId(int id)
        {
            return ctx.Entregas.FirstOrDefault(e => e.IdEntrega == id);
        }

        public void Cadastrar(Entrega novoEntrega)
        {
            ctx.Entregas.Add(novoEntrega);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Entregas.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Entrega> Listar()
        {
            return ctx.Entregas.ToList();
        }
    }
}

