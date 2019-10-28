using System.Collections.Generic;
using ZooLogico.Interfaces;

namespace ZooLogico.Models.Habitats
{
    public class Gaiola
    {
        List<IVoador> Animais {get ; set;}

        public Gaiola() 
        {
            this.Animais = new List<IVoador>(3);
        }
    }
}