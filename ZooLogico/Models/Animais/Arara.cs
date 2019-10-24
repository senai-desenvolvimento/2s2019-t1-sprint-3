using ZooLogico.Interfaces;

namespace ZooLogico.Models.Animais
{
    public class Arara : IVoador
    {
        public string Voar()
        {
            return this.GetType().Name + " consegue voar!";
        }
    }
}