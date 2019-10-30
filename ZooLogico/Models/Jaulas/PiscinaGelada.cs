using System;
using System.Collections.Generic;
using ZooLogico.Interfaces;
using ZooLogico.Models.Animais;

namespace ZooLogico.Models.Jaulas
{
    public class PiscinaGelada : Jaula
    {
        public List<IQuionofilo> Animais { get; private set; }

        public PiscinaGelada()
        {
            this.Animais = new List<IQuionofilo>(3);
        }

        public override bool ColocarNaJaula(Animal animal)
        {
            try
            {
                IQuionofilo quionofilo = (IQuionofilo) animal;
                this.Animais.Add(quionofilo);
                return true;
            }
            catch (Exception e)
            {
                System.Console.WriteLine("");
                return false;
            }
        }
    }
}