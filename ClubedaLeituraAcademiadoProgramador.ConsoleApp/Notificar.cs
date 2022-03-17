using System;

namespace ClubedaLeituraAcademiadoProgramador.ConsoleApp
{
    public partial class Program
    {
        public class Notificar
        {
            public void MostrarCabecalho(string titulo, string subtitulo)
            {
                Console.Clear();
                Console.WriteLine(titulo);
                Console.WriteLine();
                Console.WriteLine(subtitulo);
                Console.WriteLine();
            }
            public string ApresentarMenuPrincipal()
            {
                Console.Clear();

                Console.WriteLine("Clube de Leitura");
                Console.WriteLine();

                Console.WriteLine("Digite 1 para o Cadastrar Revistas");
                Console.WriteLine("Digite 2 para o Cadastrar um Emprestimo");
                Console.WriteLine("Digite 3 para o Cadastrar Amigo");

                Console.WriteLine("Digite s para Sair");

                string opcao = Console.ReadLine();
                return opcao;
            }
            public void ApresentarMensagem(string mensagem, ConsoleColor cor)
            {
                Console.ForegroundColor = cor;
                Console.WriteLine(mensagem);
                Console.ResetColor();

                Console.ReadLine();
            }
        }
    }
}
