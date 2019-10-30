using System;
using System.Collections.Generic;
using ZooLogico.Interfaces;
using ZooLogico.Models.Animais;

namespace ZooLogico.Models.Jaulas
{
    public class Gaiola : Jaula
    {
        public List<IVoador> Animais {get ; set;}

        public Gaiola() 
        {
            this.Animais = new List<IVoador>(3);
        }

        public override bool ColocarNaJaula(Animal animal)
        {
            try 
            {
                IVoador voador = (IVoador) animal;
                this.Animais.Add(voador);
                return true;
            } 
            catch (Exception e)
            {   
                return false;
            }
        }
    }
}