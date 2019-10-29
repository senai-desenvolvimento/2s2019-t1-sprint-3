using System.Collections.Generic;
using ZooLogico.Interfaces;

namespace ZooLogico.Models.Habitats
{
    //TODO: Implementar com interface IAnfibio (IAquatico e ITerrestre)
    public class Piscina
    {
        List<IAquatico> Animais {get; set;}

        public Piscina() 
        {
            this.Animais = new List<IAquatico>(3);
        }
    }
}