using System;
using System.Linq;
using ZooLogico.Interfaces;
using ZooLogico.Models.Animais;

namespace ZooLogico
{
    /**
     * ----------------------------------------------------------------------------------------------------
     * * _Aplicação: Zoo Lógico
     * * _Branch: zoo-distribuicao
     * * TEMA: INTERFACE E POLIMORFISMO
     * ----------------------------------------------------------------------------------------------------
     *   Objetivo: Exercitar o polimorfismo usando interfaces.
     */
    class Program
    {
        static void Main(string[] args)
        {
            // Variável de controle do Loop Principal
            var encerrouPrograma = false;
            #region Loop Principal
            do
            {
                #region Menu Principal

                var codigo = 0;
                
                Console.Clear();
                System.Console.WriteLine("===============================");
                System.Console.WriteLine("|  Bem- vindo ao Zoo Lógico!  |");
                System.Console.WriteLine("===============================");
                System.Console.WriteLine("     1. ALOCAR                 ");
                System.Console.WriteLine("     2. SAIR                   ");
                System.Console.WriteLine("===============================");

                #endregion
                System.Console.Write($"\n{"",2}Digite o código da ação: ");
                
                // Testando se o usuário digitou um código correto ou não
                try
                {
                    var opcaoUsuario = int.Parse(Console.ReadLine());
                    switch (opcaoUsuario)
                    {
                        case 1:

                        break;
                        case 2:
                        break;
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("Por favor, digite um código válido");
                    Console.ReadLine();
                }
            } while (!encerrouPrograma);
            #endregion
        }

        public static void AlocarAnimal()
        {
            Console.Clear();
                System.Console.WriteLine("===============================");
                System.Console.WriteLine("|       LISTA DE ANIMAIS      |");
                System.Console.WriteLine("===============================");
                for () 
                {

                }
                System.Console.WriteLine("===============================");
        }
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
