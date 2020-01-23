using System;
using System.ComponentModel.DataAnnotations;

namespace ContatoWebApi.Models
{

    public class Contato
    {

        public Contato()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        //[Required]
        public string Nome { get; set; }

        //[Required]
        public string Canal {get; set;}

        //[Required]
        public string Valor {get; set;}

        public string Obs {get; set;}
    }
}