using System;
using ZooLogico.Models.Animais;

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
            var encerrouPrograma = false;
            do
            {
                System.Console.WriteLine("==============================");
                System.Console.WriteLine("|  Bem- vindo ao Zoo Lógico! |");
                System.Console.WriteLine("==============================");
                //TODO: Fazer um for para exibir o nome das classes e criar o dicionário para os animais
                foreach (var item in Arca.animais.Values)
                {
                    System.Console.WriteLine(item.GetType().Name);
                }

                Console.ReadLine();
                
                
            } while(!encerrouPrograma);
        }
    }
}
