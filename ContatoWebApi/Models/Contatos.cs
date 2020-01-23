using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContatoWebApi.Models
{
    public class Contatos
    {
        public Contatos()
        {
            ListaContatos = new List<Contato>();
        }

        public List<Contato> ListaContatos {get; set;}
    }
}