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

        public IEnumerable<Contato> Listar(int size, int page)
        {
            List<Contato> dadosRetorno = new List<Contato>(_Dados);

            if(dadosRetorno.Count() == 0)
            {
                return null;
            }

            Contatos ContatosAdicionar = new Contatos();

            int registrosPorPagina = size == 0 ? registrosPorPagina = 10: registrosPorPagina = size;

            int pagina = page == 0 ? pagina = 0 : pagina = page;

            List<Contatos> PaginasContato = new List<Contatos>();

            int totalContatos = dadosRetorno.Count();

            for(int i = 0; i<=totalContatos; i++)
            {
                Console.WriteLine(i.ToString());

                if(dadosRetorno.Count == 0)
                    break;

                ContatosAdicionar.ListaContatos.Add(dadosRetorno[0]);

                dadosRetorno.Remove(dadosRetorno[0]);
                
                if(ContatosAdicionar.ListaContatos.Count() == registrosPorPagina && i == (registrosPorPagina -1))
                {                    
                    PaginasContato.Add(new Contatos{ ListaContatos = ContatosAdicionar.ListaContatos});
                    ContatosAdicionar.ListaContatos = new List<Contato>();
                    i=-1;
                }

            }
            
            ContatosAdicionar.ListaContatos.AddRange(dadosRetorno);
            
            if(ContatosAdicionar.ListaContatos.Count() > 0)
            {                
                PaginasContato.Add(ContatosAdicionar);             
            }

            if((pagina + 1) > PaginasContato.Count())
            {
                return null;
            }

            return PaginasContato[pagina].ListaContatos;
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