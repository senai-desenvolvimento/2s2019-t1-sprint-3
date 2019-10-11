using System;
using MateODragao.Enums;

namespace MateODragao.Views
{
    public class Mensagens
    {
        public static void MostrarMensagem(string mensagem, TipoMensagemEnum tipoMensagem)
        {

            switch (tipoMensagem)
            {
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

            System.Console.WriteLine(mensagem);
            Console.ResetColor();

            System.Console.WriteLine("\nAperte ENTER para prosseguir");
            Console.ReadLine();
            Console.Clear();
        }
    }
}