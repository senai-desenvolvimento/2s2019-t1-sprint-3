using System;
using ZooLogico.Models.Animais;

namespace ZooLogico.Views
{

    public class MenuPrincipal
    {
        public static uint Exibir()
        {
            bool querSair = false;
            uint codigo = 0;

            do
            {

                Console.Clear();
                System.Console.WriteLine("===============================");
                System.Console.WriteLine("|   Bem-vindo ao Zoo Lógico!  |");
                System.Console.WriteLine("===============================");
                System.Console.WriteLine("      O que deseja fazer?      ");
                System.Console.WriteLine("      1. ALOCAR                ");
                System.Console.WriteLine("      2. REMOVER               ");
                System.Console.WriteLine("      3. SAIR                  ");
                System.Console.WriteLine("===============================");
                
                //Convertendo para uint, assim garanto que o código não vai funcionar se for negativo
                var converteu = uint.TryParse(Console.ReadLine(), out codigo);
                
                

            } while (!querSair);

            return codigo;
        }
        

    }
}