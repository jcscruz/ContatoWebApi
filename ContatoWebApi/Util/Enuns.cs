using System.ComponentModel;

namespace ContatoWebApi.Enuns
{
    public enum CanalContato : int
    {
        [Description("Email")]
        Email = 1,
        [Description("Celular")]
        Celular = 2,
        [Description("Fixo")]
        Fixo = 3
    };
}