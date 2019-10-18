using System;
using MateODragao.Enums;
using MateODragao.Models;

namespace MateODragao.Views
{
    public class Menus
    {

        /// <summary>
        ///     Método que cria o menu principal e devolve o código referente à escolha do usuário
        /// </summary>
        /// <returns>O código de escolha do usuário</returns>

        public static int ApresentarMenuPrincipal()
        {
            bool escolheu = false;
            int codigo = 0;
            // TODO: Implementar via Enum
            string[] opcoesMenu = { "Iniciar Jogo", "Carregar Jogo", "Sair do Jogo", };

            int opcaoMenuSelecionada = 0;

            do
            {

                Console.Clear();
                System.Console.WriteLine("==============================");
                System.Console.WriteLine("||       Mate o Dragão!     ||");
                System.Console.WriteLine("==============================");

                for (int i = 0; i < opcoesMenu.Length; i++)
                {
                    string titulo = TratarTituloMenu(opcoesMenu[i]);
                    if (opcaoMenuSelecionada == i)
                    {
                        DestacarOpcao($"|  - {opcoesMenu[opcaoMenuSelecionada],-23} |".Replace("-", ">"));
                    }
                    else
                    {
                        System.Console.WriteLine($"|  - {opcoesMenu[i],-23} |");
                    }
                }

                System.Console.WriteLine("==============================");

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        opcaoMenuSelecionada = opcaoMenuSelecionada == 0 ? opcaoMenuSelecionada : --opcaoMenuSelecionada;

                        break;
                    case ConsoleKey.DownArrow:
                        opcaoMenuSelecionada = opcaoMenuSelecionada == opcoesMenu.Length - 1 ? opcaoMenuSelecionada : ++opcaoMenuSelecionada;

                        break;
                    case ConsoleKey.Enter:
                        escolheu = true;
                        break;
                }

            } while (!escolheu);
            return codigo;
        }

        // Conteúdo estava no método GerarMenuTurnos()
        public static void ApresentarMenuTurnos(string nome)
        {
            Console.Clear();

            // TODO: Tornar dinâmica esta barra de título
            System.Console.WriteLine("------------------------------");
            System.Console.WriteLine($"      Turno de {nome}");
            System.Console.WriteLine("------------------------------");
        }

        // Conteúdo tirado do método CriarAtaqueJogador()
        public static void ApresentarMenuBatalha()
        {
            System.Console.WriteLine("Escolha sua ação");
            System.Console.WriteLine(" 1 - Atacar");
            // TODO: Implementar no futuro
            // System.Console.WriteLine (" 2 - Habilidades");
            System.Console.WriteLine(" 2 - Fugir");
            System.Console.Write(" Digite o código da opção: ");
            string opcaoBatalhaJogador = Console.ReadLine();
        }

        public static Guerreiro ApresentarMenuCriacaoDePersonagem()
        {
            int pontosIniciais = 1500;
            /**
             * * Vetores para nos ajudar a registrar os atributos do personagem
             */
            string[] listaNomesAtributos = { "Força", "Destreza", "Agilidade", "Inteligência", "Vigor" };
            int[] listaValoresAtributos = { 1, 1, 1, 1, 1 };
            int maxPontos = 500;

            System.Console.Write("Digite o nome do personagem: ");
            string nome = Console.ReadLine();

            System.Console.Write("Digite o sobrenome do personagem: ");
            string sobrenome = Console.ReadLine();

            System.Console.Write("Digite a cidade natal do personagem: ");
            string cidadeNatal = Console.ReadLine();

            System.Console.Write("Digite a data de nascimento do personagem: ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());

            System.Console.Write("Digite a ferramenta de ataque do personagem: ");
            string ferramentaAtaque = Console.ReadLine();

            System.Console.Write("Digite a ferramenta de proteção do personagem: ");
            string ferramentaProtecao = Console.ReadLine();

            while (pontosIniciais != 0)
            {

                #region - Distribuição dos pontos
                int quantidadeNomesAtributos = listaNomesAtributos.Length;

                for (int i = 0; i < quantidadeNomesAtributos; i++)
                {
                    #region - Tela de status atual
                    Console.Clear();
                    System.Console.Write($"Você possui ");
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;

                    System.Console.Write($" {pontosIniciais} pontos ");
                    Console.ResetColor();

                    System.Console.WriteLine(" a serem distribuídos");
                    System.Console.WriteLine("Seu status atual:");

                    /**
                     * * Sincronizando o vetor com valores baseando-se nos vetores com nomes
                     */
                    for (int j = 0; j < quantidadeNomesAtributos; j++)
                    {
                        System.Console.WriteLine($"{listaNomesAtributos[j],15}: {listaValoresAtributos[j],-2}");
                    }

                    System.Console.WriteLine();
                    #endregion

                    /*
                     * É importante verificar a questão dos pontos iniciais (se ainda existem) para que o processo continue normalmente
                     */
                    if (pontosIniciais <= 0)
                    {
                        //MostrarMensagem ("Pontos já distribuídos", TipoMensagemEnum.SUCESSO);
                        /**
                         * ! Mostrar a utilidade do break
                         */
                        break;
                    }

                    /**
                     * * Se o atributo da vez for maior ou igual a @maxPontos, não podemos mais aumentá-lo, então mandamos o loop prosseguir 
                     */
                    if (listaValoresAtributos[i] >= maxPontos)
                    {
                        Mensagens.MostrarMensagem($"Atributo {listaNomesAtributos[i].ToUpper()} já possui pelo menos {maxPontos} pontos. Passando para o próximo...", TipoMensagemEnum.ALERTA);
                        /**
                         * ! Mostrar a utilidade do continue
                         */
                        continue;
                    }

                    System.Console.WriteLine($"Digite  o valor a ser somado em {listaNomesAtributos[i].ToUpper()} do personagem: ");
                    int valor = int.Parse(Console.ReadLine());

                    if ((valor + listaValoresAtributos[i]) >= maxPontos)
                    {
                        Mensagens.MostrarMensagem($"{valor} ultrapassa o máximo de {maxPontos} pontos por atributo", TipoMensagemEnum.ERRO);
                        continue;
                    }

                    /* Aqui ocorre a distribuição dos pontos */
                    if (pontosIniciais >= valor)
                    {
                        listaValoresAtributos[i] += valor;
                        pontosIniciais -= valor;

                    }
                    else if (pontosIniciais < valor)
                    {
                        Mensagens.MostrarMensagem("Você não possui tantos pontos assim. Tente novamente.", TipoMensagemEnum.ERRO);
                    }

                }
                #endregion
            }
            Mensagens.MostrarMensagem("Montagem finalizada!", TipoMensagemEnum.SUCESSO);
        
            return new Guerreiro(nome, sobrenome, cidadeNatal, dataNascimento, ferramentaAtaque, ferramentaProtecao, listaValoresAtributos);
        }
        private static string TratarTituloMenu(string titulo)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(titulo.Replace("_", " ").ToLower());
        }

        private static void DestacarOpcao(string opcao)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            System.Console.WriteLine($"{opcao}");
            Console.ResetColor();
        }
    }
}