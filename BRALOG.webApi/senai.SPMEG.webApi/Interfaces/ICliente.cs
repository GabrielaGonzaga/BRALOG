using senai.BRALOG.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.BRALOG.webApi.Interfaces
{
    interface ICliente
    {
        List<Cliente> Listar();

        void Cadastrar(Cliente novoCliente);

        void Deletar(int id);

        void Atualizar(Cliente produtoAtualizado);

        Cliente BuscarPorId(int id);

    }
}
