using System;

namespace MateODragao.Views {
    public class MenuPrincipal {

        enum OpcoesMenu {
            INICIAR_JOGO,
            SAIR_DO_JOGO
        }

        /// <summary>
        ///     Método que cria o menu principal
        /// </summary>
        /// <returns>O código de escolha do usuário</returns>

        public static int ApresentarMenuPrincipal () {
            bool escolheu = false;
            int codigo = 0;
            // string[] opcoesMenu = Enum.GetNames(typeof (OpcoesMenu));
            string[] opcoesMenu = { "Iniciar Jogo", "Sair do Jogo", "( >'_')>" };

            int opcaoMenuSelecionada = 0;

            do {

                Console.Clear ();
                System.Console.WriteLine ("==============================");
                System.Console.WriteLine ("||       Mate o Dragão!     || ");
                System.Console.WriteLine ("==============================");

                for (int i = 0; i < opcoesMenu.Length; i++) {
                    string titulo = TratarTituloMenu (opcoesMenu[i]);
                    if (opcaoMenuSelecionada == i) {
                        DestacarOpcao ($"|  - {opcoesMenu[opcaoMenuSelecionada],-23} |".Replace("-", ">"));
                    } else {
                        System.Console.WriteLine ($"|  - {opcoesMenu[i],-23} |");
                    }
                }

                System.Console.WriteLine ("==============================");

                var key = Console.ReadKey (true).Key;

                switch (key) {
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

        public static string TratarTituloMenu (string titulo) {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase (titulo.Replace ("_", " ").ToLower ());
        }

        public static void DestacarOpcao (string opcao) {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            System.Console.WriteLine ($"{opcao}");
            Console.ResetColor ();
        }
    }
}