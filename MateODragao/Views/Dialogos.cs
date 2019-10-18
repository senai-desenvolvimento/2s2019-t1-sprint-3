using System;

namespace MateODragao.Views
{
    public class Dialogos
    {

        public static void FinalizarDialogo()
        {
            System.Console.WriteLine("\nAperte ENTER para prosseguir");
            Console.ReadLine();
            Console.Clear();
        }

        public static void CriarDialogo(string emissor, string frase)
        {
            System.Console.WriteLine($"{emissor.ToUpper()}: {frase}");
        }
        
    }
}