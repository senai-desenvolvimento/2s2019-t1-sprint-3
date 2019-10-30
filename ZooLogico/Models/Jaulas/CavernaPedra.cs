using System;
using System.Collections.Generic;
using ZooLogico.Interfaces;
using ZooLogico.Models.Animais;

namespace ZooLogico.Models.Jaulas
{
    public class CavernaPedra : Jaula
    {
        public List<ITerrestre> Animais {get ; set;}

        public CavernaPedra() 
        {
            this.Animais = new List<ITerrestre>(3);
        }

        public override bool ColocarNaJaula(Animal animal)
        {
            try 
            {
                ITerrestre terrestre = (ITerrestre) animal;
                this.Animais.Add(terrestre);
                return true;
            } 
            catch (Exception e)
            {   
                return false;
            }
        }
    }
}