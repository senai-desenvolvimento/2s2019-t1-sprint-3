using System;
using System.Linq;
using ZooLogico.Interfaces;
using ZooLogico.Models.Animais;
using ZooLogico.Models.Jaulas;

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
                System.Console.WriteLine("     1. ALOCAR ANIMAL          ");
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
                            Animal animal = SelecionarAnimal();
                            SelecionarJaula(animal);
                            break;
                        case 2:
                            encerrouPrograma = true;
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

        public static Animal SelecionarAnimal()
        {
            bool escolheuAnimal = false;
            Animal animal = null;
            do
            {
                var codigo = 0;
                Console.Clear();
                System.Console.WriteLine("===============================");
                System.Console.WriteLine("|       LISTA DE ANIMAIS      |");
                System.Console.WriteLine("===============================");
                foreach (var item in Arca.Animais.Values)
                {
                    System.Console.WriteLine($"{"",5}{++codigo}. {item.GetType().Name}");
                }
                System.Console.Write($"\n{"",2}Digite o código do animal: ");

                // Testando se o usuário digitou um código correto ou não
                try
                {
                    var opcaoUsuario = int.Parse(Console.ReadLine());
                    animal = Arca.Animais[opcaoUsuario];

                    escolheuAnimal = true;
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("Por favor, digite um código válido");
                    Console.ReadLine();
                }
                System.Console.WriteLine("===============================");
            } while (!escolheuAnimal);
            return animal;
        }

        public static void SelecionarJaula(Animal animal)
        {
            bool alocou = false;
            do
            {

                var codigo = 0;
                Console.Clear();
                System.Console.WriteLine("===============================");
                System.Console.WriteLine("|       LISTA DE JAULAS       |");
                System.Console.WriteLine("===============================");
                System.Console.WriteLine("    1. Aquario                 ");
                System.Console.WriteLine("    2. Casa na Árvore          ");
                System.Console.WriteLine("    3. Caverna de Pedra        ");
                System.Console.WriteLine("    4. Gaiola                  ");
                System.Console.WriteLine("    5. Pasto                   ");
                System.Console.WriteLine("    6. Piscina                 ");
                System.Console.WriteLine("    7. Piscina com gelo        ");
                System.Console.WriteLine("===============================");
                System.Console.Write("   Digite o código da jaula: ");
                codigo = int.Parse(Console.ReadLine());

                switch (codigo)
                {
                    case 1:
                        Aquario aquario = new Aquario();
                        alocou = aquario.ColocarNaJaula(animal);
                        break;
                    case 2:
                        CasaArvore casaArvore = new CasaArvore();
                        alocou = casaArvore.ColocarNaJaula(animal);
                    break;
                    case 3:
                        CavernaPedra caverna = new CavernaPedra();
                        alocou = caverna.ColocarNaJaula(animal);
                    break;
                    case 4:
                        Gaiola gaiola = new Gaiola();
                        alocou = gaiola.ColocarNaJaula(animal);
                    break;
                    case 5:
                        Pasto pasto = new Pasto();
                        alocou = pasto.ColocarNaJaula(animal);
                    break;
                    case 6:
                        Piscina piscina = new Piscina();
                        alocou = piscina.ColocarNaJaula(animal);
                    break;
                    case 7:
                        PiscinaGelada gelada = new PiscinaGelada();
                        alocou = gelada.ColocarNaJaula(animal);
                    break;
                }

                if (alocou) 
                {
                    System.Console.WriteLine("Animal alocado com sucesso!");
                }
                else 
                {
                    System.Console.WriteLine("Não foi possível alocal esse animal ali");
                }
                Console.ReadLine();
                
            } while (!alocou);
        }
        public static void ClassificarAnimal(Animal animal)
        {
            // Esse @ é para que possamos usar o nome interface para a variável, que é uma palavra reservada do C#!
            var classe = animal.GetType();
            var @interface = classe.GetInterfaces().FirstOrDefault();



            Console.ReadLine();

        }




    }
}
