using ZooLogico.Interfaces;

namespace ZooLogico.Models.Animais
{
    public class Tucano : IVoador
    {
        public string Voar()
        {
            return this.GetType().Name + " consegue voar!";
        }
    }
}