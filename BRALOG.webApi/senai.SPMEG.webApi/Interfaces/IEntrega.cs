using BRALOG.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BRALOG.webApi.Interfaces
{
    interface IEntrega
    {
        List<Entrega> Listar();

        void Cadastrar(Entrega novoEntrega);

        void Deletar(int id);

        void Atualizar(Entrega produtoAtualizado);

        Entrega BuscarPorId(int id);

        List<Entrega> MinhasEntregas(int id);
    }
}
