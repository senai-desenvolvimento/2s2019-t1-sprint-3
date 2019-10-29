using System;
using System.Linq;
using ZooLogico.Interfaces;
using ZooLogico.Models.Animais;
using ZooLogico.Views;

namespace ZooLogico
{
    /**
     * ----------------------------------------------------------------------------------------------------
     * * _Aplicação: Zoo Lógico
     * * _Branch: master
     * * TEMA: INTERFACE E POLIMORFISMO
     * ----------------------------------------------------------------------------------------------------
     *   Objetivo: Exercitar o polimorfismo usando interfaces.
     */
    class Program
    {
        static void Main(string[] args)
        {
            MenuPrincipal.Exibir();
            Console.ReadLine();
            
        }

        // ! Mudamos esse método
        public static void ClassificarAnimal(Animal animal)
        {
            // Esse @ é para que possamos usar o nome interface para a variável, que é uma palavra reservada do C#!
            var classe = animal.GetType();
            var @interface = classe.GetInterfaces().FirstOrDefault();

            if ((typeof(IAquatico)).Equals(@interface))
            {
                System.Console.WriteLine($":::{classe.Name} pode ir para a Piscina:::");
            }
            else if ((typeof(IArboricula)).Equals(@interface))
            {
                System.Console.WriteLine($":::{classe.Name} pode ir para a Casa na Árvore:::");
            }
            else if ((typeof(IBranquiado)).Equals(@interface))
            {
                System.Console.WriteLine($":::{classe.Name} pode ir para o Aquário:::");
            }
            else if ((typeof(IQuionofilo)).Equals(@interface))
            {
                System.Console.WriteLine($":::{classe.Name} pode ir para a Piscina Gelada:::");
            }
            else if ((typeof(ITerrestre)).Equals(@interface))
            {
                System.Console.WriteLine($":::{classe.Name} pode ir para os Pastos ou Caverna de Pedra:::");
            }
            else if ((typeof(IVoador)).Equals(@interface))
            {
                System.Console.WriteLine($":::{classe.Name} pode ir para a Gaiola:::");
            }

            Console.ReadLine();

        }


    }
}
