using System;
using MateODragao.Models;

namespace MateODragao {
    class Program {
        static void Main (string[] args) {

            bool jogadorNaoDesistiu = true;

            do {
                /* INICIO - Menu Principal */
                Console.Clear ();
                System.Console.WriteLine ("===========================");
                System.Console.WriteLine ("       Mate o Dragão!");
                System.Console.WriteLine ("===========================");

                System.Console.WriteLine (" 1 - Iniciar jogo");
                System.Console.WriteLine (" 0 - Sair do jogo");
                System.Console.Write (" Digite o código da opção:");
                string opcaoJogador = Console.ReadLine ();

                /* FIM - Menu Principal */
                switch (opcaoJogador) {
                    case "1":
                        Console.Clear ();

                        /* INICIO - Criando os personagens (objetos) */

                        Guerreiro guerreiro = CriarGuerreiro ();

                        Dragao dragao = CriarDragao();

                        /* FIM - Criando os personagens (objetos) */

                        /* INICIO - Primeiro Diálogo */
                        /**
                         * ! Mostrar aos alunos como uma alteração no jeito de imprimir os diálogos seria muito penosa do jeito anterior pois teria que ser repetida 
                         * ! manualmente, já com o método, basta fazer a alteração nele.
                         */
                        CriarDialogo(guerreiro.Nome, $"{dragao.Nome}, seu louco! Vim-lhe derrotar-lhe!");
                        CriarDialogo(dragao.Nome, "Humano tolinho. Quem pensas que és?");

                        FinalizarDialogo();
                        /* FIM - Primeiro Diálogo */

                        /* INICIO - Segundo Diálogo */
                        System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Eu sou {guerreiro.Nome}! Da casa {guerreiro.Sobrenome}, ó criatura morfética!");
                        System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Vim de {guerreiro.CidadeNatal} para derrotar-te e mostrar meu valor!");
                        System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: QUEM? DE ONDE? Bom, que seja...fritar-te-ei e devorar-te-ei, primata insolente!");

                        FinalizarDialogo();
                        /* FIM - Segundo Diálogo */

                        bool jogadorAtacaPrimeiro = guerreiro.Destreza > dragao.Destreza ? true : false;
                        bool jogadorNaoCorreu = true;

                        /** INICIO - Quando o jogador ataca primeiro */
                        if (jogadorAtacaPrimeiro) {

                            GerarMenuTurnos(guerreiro.Nome);
                            System.Console.WriteLine ("Escolha sua ação");
                            System.Console.WriteLine (" 1 - Atacar");
                            System.Console.WriteLine (" 2 - Fugir");
                            System.Console.Write (" Digite o código da opção:");
                            string opcaoBatalhaJogador = Console.ReadLine ();

                            switch (opcaoBatalhaJogador) {
                                case "1":
                                    Random geradorNumeroAleatorio = new Random ();
                                    int numeroAleatorioJogador = geradorNumeroAleatorio.Next (0, 5);
                                    int numeroAleatorioDragao = geradorNumeroAleatorio.Next (0, 5);
                                    int guerreiroDestrezaTotal = guerreiro.Destreza + numeroAleatorioJogador;
                                    int dragaoDestrezaTotal = guerreiro.Destreza + numeroAleatorioDragao;
                                    int poderAtaqueGuerreiro = guerreiro.Forca > guerreiro.Inteligencia ? guerreiro.Forca + guerreiro.Destreza : guerreiro.Inteligencia + guerreiro.Destreza;

                                    if (guerreiroDestrezaTotal > dragaoDestrezaTotal) {
                                        System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Toma essa lagarto MALDJEETO! BIRLLLL!");
                                        dragao.Vida -= poderAtaqueGuerreiro + 5;
                                        System.Console.WriteLine ($"HP Dragão: {dragao.Vida}");
                                        System.Console.WriteLine ($"HP Jogador: {guerreiro.Vida}");
                                    } else {
                                        System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: Errrrrou, humanóide tosco!");
                                        System.Console.WriteLine ($"HP Dragão: {dragao.Vida}");
                                        System.Console.WriteLine ($"HP Jogador: {guerreiro.Vida}");
                                    }
                                    break;
                                case "2":
                                    System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Simbora fii! FLW VLW!");
                                    jogadorNaoCorreu = false;
                                    break;
                            }
                            System.Console.WriteLine ();
                            System.Console.WriteLine ("Aperte ENTER para prosseguir");
                            Console.ReadLine ();
                        }

                        /** FIM - Quando o jogador ataca primeiro */

                        /** INICIO - Turnos Oficiais */
                        while (dragao.Vida > 0 && guerreiro.Vida > 0 && jogadorNaoCorreu) {

                            GerarMenuTurnos(dragao.Nome);

                            Random geradorNumeroAleatorio = new Random ();
                            int numeroAleatorioJogador = geradorNumeroAleatorio.Next (0, 5);
                            int numeroAleatorioDragao = geradorNumeroAleatorio.Next (0, 5);
                            int guerreiroDestrezaTotal = guerreiro.Destreza + numeroAleatorioJogador;
                            int dragaoDestrezaTotal = guerreiro.Destreza + numeroAleatorioDragao;

                            if (guerreiroDestrezaTotal < dragaoDestrezaTotal) {
                                System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: HA! Estúpido ser!");
                                guerreiro.Vida -= dragao.Forca;
                                MostrarHP(guerreiro.Vida, dragao.Vida);
                                
                            } else {
                                System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Eita lasquera que essa passou perto!");
                                MostrarHP(guerreiro.Vida, dragao.Vida);
                            }

                            FinalizarDialogo();

                            if (guerreiro.Vida <= 0) {
                                System.Console.WriteLine ("JOGADOR Murreeeeeu!");
                                System.Console.WriteLine ();
                                System.Console.WriteLine ("Aperte ENTER para prosseguir");
                                Console.ReadLine ();
                                break;
                            }

                            GerarMenuTurnos(guerreiro.Nome);

                            System.Console.WriteLine ("Escolha sua ação");
                            System.Console.WriteLine (" 1 - Atacar");
                            System.Console.WriteLine (" 2 - Fugir");
                            System.Console.Write (" Digite o código da opção:");

                            string opcaoBatalhaJogador = Console.ReadLine ();

                            switch (opcaoBatalhaJogador) {
                                case "1":
                                    geradorNumeroAleatorio = new Random ();
                                    numeroAleatorioJogador = geradorNumeroAleatorio.Next (0, 5);
                                    numeroAleatorioDragao = geradorNumeroAleatorio.Next (0, 5);
                                    guerreiroDestrezaTotal = guerreiro.Destreza + numeroAleatorioJogador;
                                    dragaoDestrezaTotal = guerreiro.Destreza + numeroAleatorioDragao;
                                    int poderAtaqueGuerreiro = guerreiro.Forca > guerreiro.Inteligencia ? guerreiro.Forca + guerreiro.Destreza : guerreiro.Inteligencia + guerreiro.Destreza;

                                    if (guerreiroDestrezaTotal > dragaoDestrezaTotal) {
                                        System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Toma essa lagarto MALDJEETO!");
                                        dragao.Vida -= poderAtaqueGuerreiro + 5;
                                        
                                    } else {
                                        System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: Errrrrou, humanóide tosssssco!");
                                    }
                                    break;
                                case "2":
                                    System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Simbora fii! FLW VLW!");
                                    jogadorNaoCorreu = false;
                                    break;
                            }

                            if (dragao.Vida <= 0) {
                                System.Console.WriteLine ("DRAGÃO Murreeeeeu!");
                                System.Console.WriteLine ();
                                System.Console.WriteLine ("Aperte ENTER para prosseguir");
                                Console.ReadLine ();
                                break;
                            }

                            System.Console.WriteLine ();
                            System.Console.WriteLine ("Aperte ENTER para prosseguir");
                            Console.ReadLine ();
                        }
                        /** FIM - Turnos Oficiais */

                        break;
                    case "0":
                        jogadorNaoDesistiu = false;
                        break;
                    default:
                        System.Console.WriteLine ("Comando desconhecido");
                        break;

                }

            } while (jogadorNaoDesistiu);

            System.Console.WriteLine ("GAME OVER!");

        }

        private static Guerreiro CriarGuerreiro () {

            // System.Console.WriteLine ("Deseja começar com um personagem pronto? Responda com S ou N.");
            // string respostaUsuario = Console.ReadLine ();
            Guerreiro guerreiro = guerreiro = new Guerreiro ("Asdrúbal", "Mequetreff", "Pentescopéia", DateTime.Parse ("01/01/1450"), "Espada", "Armadura de ferro", 3, 2, 2, 2, 3);
            /* switch (respostaUsuario.ToUpper ()) {
                case "s":
                    guerreiro = new Guerreiro ("Asdrúbal", "Mequetreff", "Pentescopéia", DateTime.Parse ("01/01/1450"), "Espada", "Armadura de ferro", 3, 2, 2, 2, 3);
                    
                    break;
                case "n":
                    System.Console.WriteLine("Digite o nome do personagem:");
                    string nome = Console.ReadLine();

                    System.Console.WriteLine("Digite o sobrenome do personagem:");
                    string sobrenome = Console.ReadLine();

                    System.Console.WriteLine("Digite a cidade natal do personagem:");
                    string cidadeNatal = Console.ReadLine();

                    System.Console.WriteLine("Digite o data de nascimento do personagem:");
                    DateTime dataNascimento = DateTime.Parse(Console.ReadLine());

                    System.Console.WriteLine("Digite a ferramenta de ataque do personagem:");
                    string ferramentaAtaque = Console.ReadLine();

                    System.Console.WriteLine("Digite a ferramenta de proteção do personagem:");
                    string ferramentaProtecao = Console.ReadLine();

                    System.Console.WriteLine("Agora você possui 13");

                    System.Console.WriteLine("Digite a Força do personagem:");
                    int forca = int.Parse(Console.ReadLine());
                
                    System.Console.WriteLine("Digite a Destreza do personagem:");
                    string ferramentaAtaque = Console.ReadLine();

                    Guerreiro guerreiro = new Guerreiro();
                    break;
                default:
                    System.Console.WriteLine ("Comando inexistente. Aperte ENTER e tente novamente.");
                    Console.ReadLine ();
                    break;
            }*/
            return guerreiro;

        }

        private static Dragao CriarDragao () 
        {
            Dragao dragao = new Dragao ("Dragonildo", 5 , 3, 2, 3, 5);
            return dragao;
        }

        private static void CriarDialogo(string emissor, string frase)
        {
            System.Console.WriteLine($"{emissor.ToUpper()}: {frase}");
        }

        private static void FinalizarDialogo() 
        {
            System.Console.WriteLine ();
            System.Console.WriteLine ("Aperte ENTER para prosseguir");
            Console.ReadLine ();
            Console.Clear ();
        }

        private static void GerarMenuTurnos(string quemEstaAgindo) {
            Console.Clear ();
            System.Console.WriteLine ("------------------------------");
            System.Console.WriteLine ($"       Turno de {quemEstaAgindo}:");
            System.Console.WriteLine ("------------------------------");
        }

        private static void MostrarHP(int guerreiroHP, int dragaoHP)
        {
            System.Console.WriteLine ($"HP Dragão: {dragaoHP}");
            System.Console.WriteLine ($"HP Jogador: {guerreiroHP}");
        }
    }
}