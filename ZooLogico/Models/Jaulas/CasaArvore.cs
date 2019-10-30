using System;
using System.Collections.Generic;
using ZooLogico.Interfaces;
using ZooLogico.Models.Animais;

namespace ZooLogico.Models.Jaulas
{
    public class CasaArvore : Jaula
    {
        public List<IArboricula> Animais {get ; set;}

        public CasaArvore() 
        {
            this.Animais = new List<IArboricula>(3);
        }

        public override bool ColocarNaJaula(Animal animal)
        {
            try 
            {
                IArboricula arboricula = (IArboricula) animal;
                this.Animais.Add(arboricula);
                return true;
            } 
            catch (Exception e)
            {   
                return false;
            }
        }
    }
}