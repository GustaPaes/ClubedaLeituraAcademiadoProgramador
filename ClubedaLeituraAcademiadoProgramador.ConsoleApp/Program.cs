using System;

namespace ClubedaLeituraAcademiadoProgramador.ConsoleApp
{
    public partial class Program
    {
        #region Variáveis do Clube de Livros

        const int CAPACIDADE_REGISTROS = 100;

        static int[] idsRevista = new int[CAPACIDADE_REGISTROS];

        static string[] colecaoRevista = new string[CAPACIDADE_REGISTROS];
        static double[] numedicaorevista = new double[CAPACIDADE_REGISTROS];
        static DateTime[] anoRevista = new DateTime[CAPACIDADE_REGISTROS];
        static string[] caixaGuardada = new string[CAPACIDADE_REGISTROS];


        static int[] idsEmprestimo = new int[CAPACIDADE_REGISTROS];

        static string[] amigoemprestado = new string[CAPACIDADE_REGISTROS];
        static double[] revistaemprestada = new double[CAPACIDADE_REGISTROS];
        static DateTime[] dataemprestimo = new DateTime[CAPACIDADE_REGISTROS];
        static DateTime[] datadevolução = new DateTime[CAPACIDADE_REGISTROS];


        static int[] idsAmigos = new int[CAPACIDADE_REGISTROS];

        static string[] nomeAmigos = new string[CAPACIDADE_REGISTROS];
        static string[] nomeResponsavel = new string[CAPACIDADE_REGISTROS];
        static string[] telefoneAmigos = new string[CAPACIDADE_REGISTROS];
        static string[] enderecoAmigos = new string[CAPACIDADE_REGISTROS];


        private static int IdRevista;
        private static int IdEmprestimo;
        private static int IdAmigos;

        #endregion

        static void Main(string[] args)
        {
            while (true)
            {
                Notificar notificar = new Notificar();

                string opcao = notificar.ApresentarMenuPrincipal();

                if (opcao == "s" || opcao == "S")
                    break;

                if (opcao == "1")
                {
                    Revista revista = new Revista();

                    string opcaoCadastroRevista = revista.ApresentarMenuCadastroRevista();
                    
                    if (opcaoCadastroRevista == "s")
                        break;
                    
                    else if (opcaoCadastroRevista == "1")
                        revista.InserirNovaRevista();

                    else if (opcaoCadastroRevista == "2")
                        revista.VisualizarRevistas(true);
                }

                if (opcao == "2")
                {
                    Revista revista = new Revista();
                    Emprestimo emprestimo = new Emprestimo();

                    string opcaoCadastroEmprestimo = emprestimo.ApresentarMenuCadastroEmprestimo();

                    if (opcaoCadastroEmprestimo == "s")
                        break;

                    else if (opcaoCadastroEmprestimo == "1")
                        emprestimo.InserirNovoEmprestimo();

                    else if (opcaoCadastroEmprestimo == "2")
                        emprestimo.VisualizarEmprestimo(true);

                    else if (opcaoCadastroEmprestimo == "3")
                        revista.VisualizarRevistas(true);
                } 

                if (opcao == "3")
                {
                    Amigos amigos = new Amigos();

                    string opcaoCadastroAmigos = amigos.ApresentarMenuCadastroAmigos();

                    if (opcaoCadastroAmigos == "s")
                        break;

                    else if (opcaoCadastroAmigos == "1")
                        amigos.InserirNovoAmigos();

                    else if (opcaoCadastroAmigos == "2")
                        amigos.VisualizarAmigos(true);
                }

            }
        }

        #region Métodos de uso geral

        //public static void MostrarCabecalho(string titulo, string subtitulo)
        //{
        //    Console.Clear();
        //    Console.WriteLine(titulo);
        //    Console.WriteLine();
        //    Console.WriteLine(subtitulo);
        //    Console.WriteLine();
        //}
        //public static string ApresentarMenuPrincipal()
        //{
        //    Console.Clear();

        //    Console.WriteLine("Clube de Leitura");
        //    Console.WriteLine();

        //    Console.WriteLine("Digite 1 para o Cadastrar Revistas");
        //    Console.WriteLine("Digite 2 para o Cadastrar um Emprestimo");
        //    Console.WriteLine("Digite 3 para o Cadastrar Amigo");

        //    Console.WriteLine("Digite s para Sair");

        //    string opcao = Console.ReadLine();
        //    return opcao;
        //}
        //public static void ApresentarMensagem(string mensagem, ConsoleColor cor)
        //{
        //    Console.ForegroundColor = cor;
        //    Console.WriteLine(mensagem);
        //    Console.ResetColor();

        //    Console.ReadLine();
        //}

#endregion
    }
}
