using System;
using System.Collections.Generic;
using System.Linq;
using ContatoWebApi.Models;

namespace ContatoWebApi.Repositories
{    

    public class ContatoRepository : IContatoRepository
    {
        private readonly List<Contato> _Dados;

        public ContatoRepository()
        {
            _Dados = new List<Contato>();
        }

        public IEnumerable<Contato> Listar()
        {
            return _Dados;
        }

        public Contato ObterPorId(Guid id)
        {
            return _Dados.FirstOrDefault(x=> x.Id == id);
        }

         public void Inserir(Contato contato)
        {
            _Dados.Add(contato);
        }

        public void Alterar(Contato contato)
        {
            var contatoEditar =_Dados.FindIndex(0, 1, x => x.Id == contato.Id);
            _Dados[contatoEditar] = contato;
        }

        public void Excluir(Guid id)
        {
            var contatoExcluir =_Dados.FirstOrDefault(x=> x.Id == id);
            
            _Dados.Remove(contatoExcluir);
        }
        
    }
}