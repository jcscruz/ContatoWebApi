using System.Collections.Generic;

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