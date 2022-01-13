using senai.BRALOG.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BRALOG.webApi.Interfaces
{
    interface IProduto
    {
        List<Produto> Listar();

        void Cadastrar(Produto novoProduto);

        void Deletar(int id);

        void Atualizar(Produto produtoAtualizado);

        Produto BuscarPorId(int id);
    }
}
