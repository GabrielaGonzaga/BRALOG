
using BRALOG.webApi.Contexts;
using BRALOG.webApi.Domains;
using BRALOG.webApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BRALOG.webApi.Repositories
{
    public class ProdutoRepository : IProduto
    {
        BRALOGContext ctx = new BRALOGContext();

        public void Atualizar(Produto produtoAtualizado)
        {
            ctx.Produtos.Update(produtoAtualizado);
            ctx.SaveChanges();
        }


        public Produto BuscarPorId(int id)
        {
            return ctx.Produtos.FirstOrDefault(e => e.IdProduto == id);
        }

        public void Cadastrar(Produto novoProduto)
        {
            ctx.Produtos.Add(novoProduto);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Produtos.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Produto> Listar()
        {
            return ctx.Produtos.ToList();
        }

        public List<Produto> MeusProdutos(int id)
        {
            return ctx.Produtos

            .Include(c => c.IdUsuarioNavigation)

            .Where(c => c.IdUsuarioNavigation.IdUsuario == id)

            .ToList();
        }
    }
}

