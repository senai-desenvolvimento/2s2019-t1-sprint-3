using System.Collections.Generic;
using ZooLogico.Interfaces;

namespace ZooLogico.Models.Habitats
{
    public class PiscinaGelada
    {
        List<IQuionofilo> Animais {get; set;}

        public PiscinaGelada() 
        {
            this.Animais = new List<IQuionofilo>(3);
        }
    }
}