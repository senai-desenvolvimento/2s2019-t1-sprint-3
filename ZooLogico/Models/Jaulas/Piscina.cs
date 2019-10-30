using System;
using System.Collections.Generic;
using ZooLogico.Interfaces;
using ZooLogico.Models.Animais;

namespace ZooLogico.Models.Jaulas
{
    //TODO: Implementar com interface IAnfibio (IAquatico e ITerrestre)
    public class Piscina : Jaula
    {
        public List<IAquatico> Animais {get; set;}

        public Piscina() 
        {
            this.Animais = new List<IAquatico>(3);
        }

        public override bool ColocarNaJaula(Animal animal)
        {
            try 
            {
                IAquatico aquatico = (IAquatico) animal;
                this.Animais.Add(aquatico);
                return true;
            } 
            catch (Exception e)
            {   
                return false;
            }
        }
    }
}