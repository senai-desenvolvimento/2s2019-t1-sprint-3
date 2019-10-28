using System.Collections.Generic;
using ZooLogico.Interfaces;

namespace ZooLogico.Models.Habitats
{
    public class Pasto
    {
        List<ITerrestre> Animais {get ; set;}

        public Pasto() 
        {
            this.Animais = new List<ITerrestre>(3);
        }
    }
}