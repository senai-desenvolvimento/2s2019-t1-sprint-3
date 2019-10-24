using ZooLogico.Interfaces;

namespace ZooLogico.Models.Animais
{
    public class Tartaruga : IAquatico
    {
        public string Nadar()
        {
            return this.GetType().Name + " consegue nadar!";
        }
    }
}