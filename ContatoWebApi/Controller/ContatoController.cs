using System;
using System.Collections.Generic;
using System.Linq;
using ContatoWebApi.Enuns;
using ContatoWebApi.Models;
using ContatoWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using ContatoWebApi.Util;

namespace ContatoWebApi.Controllers
{
    public class ContatoWebApi : Controller
    {
        private readonly IContatoRepository _repositorio;

        public ContatoWebApi(IContatoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet("v1/contato")]
        public IActionResult ListarContatos()
        {            
            var retorno = _repositorio.Listar(0, 0);

            if (retorno == null)
                return NotFound("Pagina não encontrada");

            return Ok(retorno);
        }

        [HttpGet("v1/contato/{size}/{page}")]
        public IActionResult ListarContatosPorPagina(int size, int page)
        {
            var retorno = _repositorio.Listar(size, page);

            if (retorno == null)
                return NotFound("Pagina não encontrada");

            return Ok(retorno);

        //     var contatos = _repositorio.Listar().ToList();            

        //     if(contatos.Count() == 0)
        //     {
        //         return NotFound("A lista de contatos está vazia.");
        //     }

        //     Contatos ContatosAdicionar = new Contatos();

        //     int registrosPorPagina = size == 0 ? registrosPorPagina = 10: registrosPorPagina = size;

        //     int pagina = page == 0 ? pagina = 0 : pagina = page;

        //     List<Contatos> PaginasContato = new List<Contatos>();

        //     int totalContatos = contatos.Count();

        //     for(int i = 0; i<=totalContatos; i++)
        //     {
        //         Console.WriteLine(i.ToString());

        //         if(contatos.Count == 0)
        //             break;

        //         ContatosAdicionar.ListaContatos.Add(contatos[0]);

        //         contatos.Remove(contatos[0]);
                
        //         if(ContatosAdicionar.ListaContatos.Count() == registrosPorPagina && i == (registrosPorPagina -1))
        //         {                    
        //             PaginasContato.Add(new Contatos{ ListaContatos = ContatosAdicionar.ListaContatos});
        //             ContatosAdicionar.ListaContatos = new List<Contato>();
        //             i=-1;
        //         }

        //     }
            
        //     ContatosAdicionar.ListaContatos.AddRange(contatos);
            
        //     if(ContatosAdicionar.ListaContatos.Count() > 0)
        //     {                
        //         PaginasContato.Add(ContatosAdicionar);             
        //     }

        //     if((pagina + 1) > PaginasContato.Count())
        //     {
        //         return NotFound("Pagina solicitada é maior que o total de páginas disponíveis.");
        //     }

        //     return Ok(PaginasContato[pagina]);
         }

        [HttpGet("v1/contato/{id}")]
        public IActionResult ObterContatoPorId(Guid id)
        {
            var contato = _repositorio.ObterPorId(id);
            
            if(contato == null)
            {
                return NotFound();
            }

            return Ok(contato);
        }

        [HttpPost("v1/contato")]
        public IActionResult InserirContato([FromBody]Contato contato)
        {            

            UtilClasse Validacao = new UtilClasse();

            string MensagemErro = Validacao.ValidarDadosContato(contato);
            
            if( MensagemErro != "")
            {
                return NotFound(MensagemErro);
            }

            _repositorio.Inserir(contato);
            return Ok();
        }

        [HttpPut("v1/contato/{id}")]
        public IActionResult AlterarContatoPorId(Guid id, [FromBody]Contato contato)
        {        

            UtilClasse Validacao = new UtilClasse();

            string MensagemErro = Validacao.ValidarDadosContato(contato);

            if( MensagemErro != "")
            {
                return NotFound(MensagemErro);
            }

            var contatoEditar = _repositorio.ObterPorId(id);

            if(contatoEditar == null)
            {
                return NotFound();
            }

            contatoEditar = contato;
            
            _repositorio.Alterar(contatoEditar);

            return Ok();
        }

        [HttpDelete("v1/contato/{id}")]
        public IActionResult ExcluirContatoPorId(Guid id)
        {
            var contato = _repositorio.ObterPorId(id);
            
            if(contato == null)
            {
                return NotFound();
            }
            
            _repositorio.Excluir(id);

            return Ok(contato);
        }
    }
}