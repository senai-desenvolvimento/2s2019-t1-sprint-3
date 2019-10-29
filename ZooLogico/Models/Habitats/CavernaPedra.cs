using System.Collections.Generic;
using ZooLogico.Interfaces;

namespace ZooLogico.Models.Habitats
{
    public class CavernaPedra
    {
        List<ITerrestre> Animais {get ; set;}

        public CavernaPedra() 
        {
            this.Animais = new List<ITerrestre>(3);
        }
    }
}