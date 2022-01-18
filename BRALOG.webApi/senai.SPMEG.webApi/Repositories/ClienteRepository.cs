using BRALOG.webApi.Contexts;
using BRALOG.webApi.Domains;
using Microsoft.EntityFrameworkCore;
using senai.BRALOG.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.BRALOG.webApi.Repositories
{
    public class ClienteRepository : ICliente
    {
        BRALOGContext ctx = new BRALOGContext();

        public void Atualizar(Cliente clienteAtualizado)
        {
            ctx.Clientes.Update(clienteAtualizado);
            ctx.SaveChanges();
        }

        public Cliente BuscarPorId(int id)
        {
            return ctx.Clientes.FirstOrDefault(e => e.IdCliente == id);
        }

        public void Cadastrar(Cliente novoCliente)
        {
            ctx.Clientes.Add(novoCliente);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Clientes.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Cliente> Listar()
        {
            return ctx.Clientes.ToList();
        }

        public List<Cliente> MeusClientes(int id)
        {
            throw new NotImplementedException();
        }

        //public List<Cliente> MeusClientes(int id)
        //{
        //    return ctx.Entregas

        //    .Include(c => c.IdUsuárioNavigation)

        //    .Where(c => c.IdUsuárioNavigation. == id)

        //    .ToList();
        //}
    }
}
