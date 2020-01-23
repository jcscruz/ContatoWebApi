using System.Collections.Generic;
using ContatoWebApi.Models;

namespace ContatoWebApi.Util
{

    public class UtilClasse
    {        
        List<string> CanaisPermitidos = new List<string>(new string[] { "Email", "Celular", "Fixo" });        

        public string ValidarDadosContato(Contato contato)
        {
            if(string.IsNullOrWhiteSpace(contato.Nome))            
                return "Nome é obrigatório.";

            if(string.IsNullOrWhiteSpace(contato.Canal))            
                return "Canal de comunicação é obrigatório.";

            if(string.IsNullOrWhiteSpace(contato.Valor))            
                return "Valor é obrigatório.";

            if(!CanaisPermitidos.Contains(contato.Canal))
            {
                return "Canal de comunicação inválido.  Os canais permitidos são Email, Celular e Fixo.";
            }

            return "";
        }



    }
}