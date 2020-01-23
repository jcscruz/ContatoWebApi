using System;
using System.Collections.Generic;
using ContatoWebApi.Models;

namespace ContatoWebApi.Repositories
{
    public interface IContatoRepository
    {
        //IEnumerable<Contato> Listar();
        IEnumerable<Contato> Listar(int page, int size);

        Contato ObterPorId(Guid id);
        
        void Inserir(Contato contato);

        void Alterar(Contato contato);

        void Excluir(Guid id);        

    }
}