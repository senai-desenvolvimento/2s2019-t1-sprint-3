using System.Collections.Generic;
using ZooLogico.Interfaces;

namespace ZooLogico.Models.Habitats
{
    public class Aquario
    {
        List<IBranquiado> Animais {get ; set;}

        public Aquario() 
        {
            this.Animais = new List<IBranquiado>(3);
        }
    }
}