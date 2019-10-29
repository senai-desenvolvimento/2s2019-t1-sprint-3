using System;
using ZooLogico.Models.Animais;

namespace ZooLogico.Views
{
    public class MenuAnimais
    {
        public static Animal ExibirMenuAnimais(string verbo)
        {
            bool querSair = false;
            Animal animal = null;
            do
            {
                var codigo = 0;
                Console.Clear();
                System.Console.WriteLine("===================================");
                System.Console.WriteLine($" Escolha o animal a ser {verbo} ");
                System.Console.WriteLine("===================================");
                // Gerar os itens do menu de forma automática
                foreach (var item in Arca.Animais.Values)
                {
                    System.Console.WriteLine($"{"",5}{++codigo}. {item.GetType().Name}");
                }

                System.Console.Write($"\n{"",2}Digite o código do animal: ");

                // Testando se o usuário digitou um código correto ou não
                try
                {
                    var opcaoUsuario = int.Parse(Console.ReadLine());
                    // Coloca o animal encontrado na Arca na variável criada acima
                    animal = Arca.Animais[opcaoUsuario];
                }

                catch (Exception e)
                {
                    System.Console.WriteLine("Por favor, digite um código válido");
                    Console.ReadLine();
                }

            } while (!querSair);
            // Retorna a variável animal, tendo ela um objeto animal ou não.
            return animal;
        }
    }
}