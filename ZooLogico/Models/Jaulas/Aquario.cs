using System;
using System.Collections.Generic;
using ZooLogico.Interfaces;
using ZooLogico.Models.Animais;

namespace ZooLogico.Models.Jaulas
{
    public class Aquario : Jaula
    {
        public List<IBranquiado> Animais {get; set;}

        public Aquario() 
        {
            this.Animais = new List<IBranquiado>(3);
        }

        public override bool ColocarNaJaula(Animal animal)
        {
            try 
            {
                IBranquiado branquiado = (IBranquiado) animal;
                this.Animais.Add(branquiado);
                return true;
            } 
            catch (Exception e)
            {   
                return false;
            }
        }
    }
}