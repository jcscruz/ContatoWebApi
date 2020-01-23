using System;
using ContatoWebApi.Models;
using ContatoWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(_repositorio.Listar());
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
            _repositorio.Inserir(contato);
            return Ok();
        }

        [HttpPut("v1/contato/{id}")]
        public IActionResult AlterarContatoPorId(Guid id, [FromBody]Contato contato)
        {
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