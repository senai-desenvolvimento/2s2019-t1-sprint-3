using System;
using System.Collections.Generic;
using MateODragao.Enums;
using MateODragao.Models;
using MateODragao.Views;

/**
 * * _Aplicação: Mate o Dragão
 * * _Branch: metodos
 * * Objetivo: Transferir a lógica do método Main para métodos públicos a fim de otimizar o nosso código e ensinar a importância de usarmos métodos.
 * * Objetivo: Mostrar a utilidade do #region.
 * * Objetivo: Mostrar a utilidade do break e do continue.
 * * Objetivo: Mostrar as extensões: Better Comments, indent-rainbow, Bracket Pair Colorizer 2, GitLens.
 * * Objetivo: Mostrar como manipular as cores no Console.
 * * Objetivo: Mostrar como usar um enum para melhorar nossas mensagens.
 * ! Objetivo: Explicações sobre modificadores de acesso e static devem ficar pra depois.
 */
namespace MateODragao {
    class Program {
        static void Main (string[] args) {

            bool jogadorNaoDesistiu = true;

            do {
                #region - Menu Principal

                int opcaoJogador = Menus.ApresentarMenuPrincipal();

                #endregion
                switch (opcaoJogador) {
                    case 1:
                        Console.Clear ();

                        #region - Criando os personagens (objetos)

                        Guerreiro guerreiro = CriarGuerreiro ();

                        Dragao dragao = CriarDragao ();

                        #endregion

                        #region - Primeiro Diálogo
                        /**
                         * ! Mostrar aos alunos como uma alteração no jeito de imprimir os diálogos seria muito penosa do jeito anterior pois teria que ser repetida 
                         * ! manualmente, já com o método, basta fazer a alteração nele.
                         */
                        CriarDialogo (guerreiro.Nome, $"{dragao.Nome}, seu louco! Vim-lhe derrotar-lhe!");
                        CriarDialogo (dragao.Nome, "Humano tolinho. Quem pensas que és?");

                        FinalizarDialogo ();
                        #endregion

                        #region - Segundo Diálogo 
                        CriarDialogo (guerreiro.Nome, $"Eu sou {guerreiro.Nome}! Da casa {guerreiro.Sobrenome}, ó criatura morfética!");
                        CriarDialogo (guerreiro.Nome, $"Vim de {guerreiro.CidadeNatal} para derrotar-te e mostrar meu valor!");
                        CriarDialogo (dragao.Nome, $"QUEM? DE ONDE? Bom, que seja...fritar-te-ei e devorar-te-ei, primata insolente!");

                        FinalizarDialogo ();
                        #endregion

                        /**
                        * * Decisão sobre quem ataca primeiro - mudou de Destreza para Agilidade
                        */
                        bool jogadorAtacaPrimeiro = guerreiro.Agilidade > dragao.Agilidade ? true : false;
                        bool jogadorNaoCorreu = true;

                        #region Quando o jogador ataca primeiro
                        Console.Clear();
                        if (jogadorAtacaPrimeiro) {

                            int dano = CriarAtaqueJogador(guerreiro, dragao);
                            if (dano != -1) {
                                dragao.Vida -= dano;
                            } else {
                                jogadorNaoCorreu = false;
                            }
                            MostrarHP(guerreiro.Vida, dragao.Vida);

                            if (dragao.Vida <= 0) {
                                System.Console.WriteLine ("DRAGÃO Murreeeeeu!");
                                System.Console.WriteLine ();
                                System.Console.WriteLine ("Aperte ENTER para prosseguir");
                                Console.ReadLine ();
                                /**
                                * ! Este break tem efeito diferente quando está fora do switch!
                                */
                                break;
                            }
                        }
                        #endregion

                        #region - Turnos Oficiais
                        while (dragao.Vida > 0 && guerreiro.Vida > 0 && jogadorNaoCorreu) {

                            int dano = CriarAtaqueDragao(guerreiro, dragao);
                            
                            guerreiro.Vida -= dano;

                            MostrarHP(guerreiro.Vida, dragao.Vida);

                            if (guerreiro.Vida <= 0) {
                                System.Console.WriteLine ("JOGADOR Murreeeeeu!");
                                System.Console.WriteLine ();
                                System.Console.WriteLine ("Aperte ENTER para prosseguir");
                                Console.ReadLine ();
                                /**
                                * ! Este break tem efeito diferente quando está fora do switch!
                                */
                                break;
                            }

                            dano = CriarAtaqueJogador(guerreiro, dragao);

                            if (dano != -1) {
                                dragao.Vida -= dano;
                            } else {
                                jogadorNaoCorreu = false;
                            }

                            MostrarHP(guerreiro.Vida, dragao.Vida);

                            if (dragao.Vida <= 0) {
                                System.Console.WriteLine ("DRAGÃO Murreeeeeu!");
                                System.Console.WriteLine ();
                                System.Console.WriteLine ("Aperte ENTER para prosseguir");
                                Console.ReadLine ();
                                /**
                                * ! Este break tem efeito diferente quando está fora do switch!
                                */
                                break;
                            }
                        }
                        #endregion

                        break;
                    case 0:
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

            bool terminouDeMontar = false;
            Guerreiro guerreiro = null;

            do {
                System.Console.WriteLine ("Deseja começar com um personagem pronto? Responda com S ou N.");
                string respostaUsuario = Console.ReadLine ();

                switch (respostaUsuario.ToUpper ()) 
                {
                    case "S":
                        guerreiro = new Guerreiro ("Asdrúbal", "Mequetreff", "Pentescopéia", DateTime.Parse ("01/01/1450"), "Espada", "Armadura de ferro", 2, 1, 1, 1, 2);
                        terminouDeMontar = true;
                        break;
                        /**
                         * ! A implementação dessa opção abaixo é facultativa. Somente a opção acima já é o suficiente para que o jogo aconteça. 
                         */
                    case "N":

                        System.Console.Write ("Digite o nome do personagem: ");
                        string nome = Console.ReadLine ();

                        System.Console.Write ("Digite o sobrenome do personagem: ");
                        string sobrenome = Console.ReadLine ();

                        System.Console.Write ("Digite a cidade natal do personagem: ");
                        string cidadeNatal = Console.ReadLine ();

                        System.Console.Write ("Digite a data de nascimento do personagem: ");
                        DateTime dataNascimento = DateTime.Parse (Console.ReadLine ());

                        System.Console.Write ("Digite a ferramenta de ataque do personagem: ");
                        string ferramentaAtaque = Console.ReadLine ();

                        System.Console.Write ("Digite a ferramenta de proteção do personagem: ");
                        string ferramentaProtecao = Console.ReadLine ();

                        int pontosIniciais = 1500;

                        /**
                         * * Vetores para nos ajudar a registrar os atributos do personagem
                         */
                        string[] listaNomesAtributos = { "Força", "Destreza", "Agilidade", "Inteligência", "Vigor" };
                        int[] listaValoresAtributos = { 1, 1, 1, 1, 1 };
                        int maxPontos = 500;
                        while (pontosIniciais != 0) {
                            
                            #region - Distribuição dos pontos
                            int quantidadeNomesAtributos = listaNomesAtributos.Length;

                            for (int i = 0; i < quantidadeNomesAtributos; i++) {
                                #region - Tela de status atual
                                Console.Clear ();
                                System.Console.Write ($"Você possui ");
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                Console.ForegroundColor = ConsoleColor.Black;

                                System.Console.Write ($" {pontosIniciais} pontos ");
                                Console.ResetColor();

                                System.Console.WriteLine(" a serem distribuídos");
                                System.Console.WriteLine ("Seu status atual:");

                                /**
                                * * Sincronizando o vetor com valores baseando-se nos vetores com nomes
                                */
                                for (int j = 0; j < quantidadeNomesAtributos; j++) {
                                    System.Console.WriteLine ($"{listaNomesAtributos[j], 15}: {listaValoresAtributos[j], -2}");
                                }

                                System.Console.WriteLine ();
                                #endregion

                                /*
                                 * É importante verificar a questão dos pontos iniciais (se ainda existem) para que o processo continue normalmente
                                 */
                                if (pontosIniciais <= 0) {
                                    //MostrarMensagem ("Pontos já distribuídos", TipoMensagemEnum.SUCESSO);
                                    /**
                                     * ! Mostrar a utilidade do break
                                     */
                                    break;
                                }

                                /**
                                 * * Se o atributo da vez for maior ou igual a @maxPontos, não podemos mais aumentá-lo, então mandamos o loop prosseguir 
                                 */
                                if (listaValoresAtributos[i] >= maxPontos) {
                                    MostrarMensagem ($"Atributo {listaNomesAtributos[i].ToUpper()} já possui pelo menos {maxPontos} pontos. Passando para o próximo...", TipoMensagemEnum.ALERTA);
                                    /**
                                     * ! Mostrar a utilidade do continue
                                     */
                                    continue;
                                }

                                System.Console.WriteLine ($"Digite  o valor a ser somado em {listaNomesAtributos[i].ToUpper()} do personagem: ");
                                int valor = int.Parse (Console.ReadLine ());
                                
                                if ((valor + listaValoresAtributos[i]) >= maxPontos) {
                                    MostrarMensagem($"{valor} ultrapassa o máximo de {maxPontos} pontos por atributo", TipoMensagemEnum.ERRO);
                                    continue;
                                }

                                /* Aqui ocorre a distribuição dos pontos */
                                if (pontosIniciais >= valor) {
                                    listaValoresAtributos[i] += valor;
                                    pontosIniciais -= valor;

                                } else if (pontosIniciais < valor) {
                                    MostrarMensagem ("Você não possui tantos pontos assim. Tente novamente.", TipoMensagemEnum.ERRO);
                                }
                                
                            }
                            #endregion
                        }
                        MostrarMensagem ("Montagem finalizada!", TipoMensagemEnum.SUCESSO);
                        guerreiro = new Guerreiro (nome, sobrenome, cidadeNatal, dataNascimento, ferramentaAtaque, ferramentaProtecao, listaValoresAtributos);
                        terminouDeMontar = true;
                        break;
                    default:
                        System.Console.WriteLine ("Comando inexistente. Aperte ENTER e tente novamente.");
                        Console.ReadLine ();

                        break;
                }
            } while (!terminouDeMontar);

            return guerreiro;

        }

        public static Dragao CriarDragao () {
            Dragao dragao = new Dragao ("Dragonildo", 5, 3, 2, 3, 5);
            return dragao;
        }

        public static void CriarDialogo (string emissor, string frase) {
            System.Console.WriteLine ($"{emissor.ToUpper()}: {frase}");
        }

        public static void FinalizarDialogo () {
            System.Console.WriteLine ();
            System.Console.WriteLine ("Aperte ENTER para prosseguir");
            Console.ReadLine ();
            Console.Clear ();
        }

        public static void MostrarHP (int guerreiroHP, int dragaoHP) {
            System.Console.WriteLine ($"HP Dragão: {dragaoHP}");
            System.Console.WriteLine ($"HP Jogador: {guerreiroHP}");
            FinalizarDialogo();
        }

        public static void MostrarMensagem (string mensagem, TipoMensagemEnum tipoMensagem) {

            switch (tipoMensagem) {
                case TipoMensagemEnum.ERRO:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case TipoMensagemEnum.SUCESSO:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case TipoMensagemEnum.ALERTA:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case TipoMensagemEnum.MENSAGEM:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                default:
                    break;
            }

            System.Console.WriteLine (mensagem);
            Console.ResetColor ();

            System.Console.WriteLine ("\nAperte ENTER para prosseguir");
            Console.ReadLine ();
            Console.Clear();
        }

        public static int CriarAtaqueJogador (Guerreiro guerreiro, Dragao dragao) {
            GerarMenuTurnos (guerreiro.Nome);
            System.Console.WriteLine ("Escolha sua ação");
            System.Console.WriteLine (" 1 - Atacar");
            System.Console.WriteLine (" 2 - Fugir");
            System.Console.Write (" Digite o código da opção: ");
            string opcaoBatalhaJogador = Console.ReadLine ();

            /**
            * ! Variável nova!
            * ! Dessa vez, não tiraremos a vida direto do inimigo, mas sim, retornaremos o dano total do guerreiro.
            */
            int dano = 0;

            switch (opcaoBatalhaJogador) 
            {
                case "1":
                    Random geradorNumeroAleatorio = new Random ();
                    int numeroAleatorioJogador = geradorNumeroAleatorio.Next (0, 5);
                    int numeroAleatorioDragao = geradorNumeroAleatorio.Next (0, 5);
                    int guerreiroDestrezaTotal = guerreiro.Destreza + numeroAleatorioJogador;
                    int dragaoDestrezaTotal = dragao.Destreza + numeroAleatorioDragao;
                    int poderAtaqueGuerreiro = guerreiro.Forca > guerreiro.Inteligencia ? guerreiro.Forca + guerreiro.Destreza : guerreiro.Inteligencia + guerreiro.Destreza;

                    if (guerreiroDestrezaTotal > dragaoDestrezaTotal) {
                        System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Toma essa lagarto MALDJEETO! BIRLLLL!");
                        dano += poderAtaqueGuerreiro + 5;
                        /*
                        * Foi preciso tirar o MostrarHP daqui, pois o dano ainda não foi calculado!
                        */
                    } else {
                        System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: Errrrrou, humanóide tosco!");
                        /*
                        * Foi preciso tirar o MostrarHP daqui, pois o dano ainda não foi calculado!
                        */
                    }
                    break;
                case "2":
                    System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Simbora fii! FLW VLW!");
                    dano = -1;
                    break;
            }

            return dano;
        }

        public static int CriarAtaqueDragao(Guerreiro guerreiro, Dragao dragao)
        {

            /**
            * ! Variável nova!
            * ! Dessa vez, não tiraremos a vida direto do inimigo, mas sim, retornaremos o dano total do guerreiro.
            */
            int dano = 0;

            GerarMenuTurnos (dragao.Nome);
            Random geradorNumeroAleatorio = new Random ();
            int numeroAleatorioJogador = geradorNumeroAleatorio.Next (0, 5);
            int numeroAleatorioDragao = geradorNumeroAleatorio.Next (0, 5);
            int guerreiroDestrezaTotal = guerreiro.Destreza + numeroAleatorioJogador;
            int dragaoDestrezaTotal = guerreiro.Destreza + numeroAleatorioDragao;

            if (guerreiroDestrezaTotal < dragaoDestrezaTotal) {
                System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: HA! Estúpido ser!");
                dano += dragao.Forca;
                /*
                 * Foi preciso tirar o MostrarHP daqui, pois o dano ainda não foi calculado!
                 */

            } else {
                System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Eita lasquera que essa passou perto!");
                /*
                 * Foi preciso tirar o MostrarHP daqui, pois o dano ainda não foi calculado!
                 */
            }

        return dano;
        }

    }
}