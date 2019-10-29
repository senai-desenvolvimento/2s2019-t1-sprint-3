using System.Collections.Generic;
using ZooLogico.Interfaces;

namespace ZooLogico.Models.Habitats
{
    public class CasaArvore
    {
        List<IArboricula> Animais {get ; set;}

        public CasaArvore() 
        {
            this.Animais = new List<IArboricula>(3);
        }
    }
}