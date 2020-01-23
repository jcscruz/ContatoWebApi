using System;

namespace ContatoWebApi.Models
{

    public class Contato
    {

        public Contato()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        
        public string Nome { get; set; }

        public string Canal {get; set;}

        public string Valor {get; set;}

        public string Obs {get; set;}
    }
}