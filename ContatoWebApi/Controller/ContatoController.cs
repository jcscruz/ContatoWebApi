using System;
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

            contatoEditar.Nome = contato.Nome;
            contatoEditar.Canal = contato.Canal;
            contatoEditar.Valor = contato.Valor;
            contatoEditar.Obs = contato.Obs;
            
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