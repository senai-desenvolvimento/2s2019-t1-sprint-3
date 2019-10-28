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
            var codigo = 0;
            do
            {
                Console.Clear();
                System.Console.WriteLine("===============================");
                System.Console.WriteLine("|  Bem- vindo ao Zoo Lógico!  |");
                System.Console.WriteLine("===============================");
                //TODO: Fazer um for para exibir o nome das classes e criar o dicionário para os animais
                foreach (var item in Arca.animais.Values)
                {
                    System.Console.WriteLine($"{"",5}{++codigo}. {item.GetType().Name}");
                }
                System.Console.Write($"\n{"",-1}Digite o código do animal:");
                var opcaoUsuario = Console.ReadLine();

                
                
            } while(!encerrouPrograma);
        }
    }
}
