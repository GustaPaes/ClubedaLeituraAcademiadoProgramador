using System;

namespace ClubedaLeituraAcademiadoProgramador.ConsoleApp
{
    public class Program
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
                string opcao = ApresentarMenuPrincipal();

                if (opcao == "s" || opcao == "S")
                    break;

                if (opcao == "1")
                {
                    string opcaoCadastroRevista = ApresentarMenuCadastroRevista();

                    if (opcaoCadastroRevista == "s")
                        break;

                    else if (opcaoCadastroRevista == "1")
                        InserirNovaRevista();

                    else if (opcaoCadastroRevista == "2")
                        VisualizarRevistas(true);
                }

                if (opcao == "2")
                {
                    string opcaoCadastroEmprestimo = ApresentarMenuCadastroEmprestimo();

                    if (opcaoCadastroEmprestimo == "s")
                        break;

                    else if (opcaoCadastroEmprestimo == "1")
                        InserirNovoEmprestimo();

                    else if (opcaoCadastroEmprestimo == "2")
                        VisualizarEmprestimo(true);

                    else if (opcaoCadastroEmprestimo == "3")
                        VisualizarRevistas(true);
                }

                if (opcao == "3")
                {
                    string opcaoCadastroAmigos = ApresentarMenuCadastroAmigos();

                    if (opcaoCadastroAmigos == "s")
                        break;

                    else if (opcaoCadastroAmigos == "1")
                        InserirNovoEmprestimo();

                    else if (opcaoCadastroAmigos == "2")
                        VisualizarEmprestimo(true);
                }


            }
        }

        #region Cadastro de Revistas

        public static string ApresentarMenuCadastroRevista()
        {
            Console.Clear();

            Console.WriteLine("Clube do Livro");
            Console.WriteLine();

            Console.WriteLine("Digite 1 para inserir nova Revista");
            Console.WriteLine("Digite 2 para visualizar Revistas");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        public static void InserirNovaRevista()
        {
            MostrarCabecalho("Cadastro de Revistas", "Registrando uma nova revista:");

            IdRevista++;

            GravarRevista(0);

            ApresentarMensagem("Revista cadastrada com sucesso", ConsoleColor.Green);
        }
        public static void GravarRevista(int IdRevistaSelecionada)
        {
            string revista = ObterTipoColecao();

            double numedicao = ObterNumeroEdicao();

            DateTime anorevista = ObterAnoRevista();

            string caixaguardada = ObterCaixadaRevista();

            int posicao;

            if (IdRevistaSelecionada == 0)
            {
                posicao = ObterPosicaoVagaParaRevistas();
                idsRevista[posicao] = IdRevista;
            }
            else
                posicao = ObterPosicaoOcupadaParaRevistas(IdRevistaSelecionada);

            colecaoRevista[posicao] = revista;
            numedicaorevista[posicao] = numedicao;
            anoRevista[posicao] = anorevista;
            caixaGuardada[posicao] = caixaguardada;
        }
        public static int VisualizarRevistas(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho("Cadastro de Revista", "Visualizando revista:");

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-55} | {2,-35}", "Id", "Coleção", "Caixa Guardada");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            int numeroRevistasCadastrados = 0;

            for (int i = 0; i < idsRevista.Length; i++)
            {
                if (idsRevista[i] > 0)
                {
                    Console.Write("{0,-10} | {1,-55} | {2,-35}", idsRevista[i], colecaoRevista[i], caixaGuardada[i]);

                    Console.WriteLine();

                    numeroRevistasCadastrados++;
                }
            }

            if (numeroRevistasCadastrados == 0)
                ApresentarMensagem("Nenhuma Revista cadastrada!", ConsoleColor.DarkYellow);
            else
                Console.ReadLine();

            return numeroRevistasCadastrados;
        }
        public static int ObterPosicaoVagaParaRevistas()
        {
            int posicao = 0;

            for (int i = 0; i < idsRevista.Length; i++)
            {
                if (idsRevista[i] == 0)
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
        public static int ObterPosicaoOcupadaParaRevistas(int idRevistaSelecionado)
        {
            int posicao = 0;

            for (int i = 0; i < idsRevista.Length; i++)
            {
                if (idRevistaSelecionado == idsRevista[i])
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
        public static bool ExisteRevista(int idSelecionado)
        {
            for (int i = 0; i < idsRevista.Length; i++)
            {
                if (idsRevista[i] == idSelecionado)
                    return true;
            }

            return false;
        } //NÃO UTILIZADO ATÉ O MOMENTO, PARA VERIFICAR SE EXISTE DADOS NO ID DA REVISTA

        #region Validações de Cadastro de Revistas

        public static string ObterTipoColecao()
        {
            string revista;

            bool revistaInvalida;
            do
            {
                revistaInvalida = false;
                Console.Write("Digite o tipo de Coleção da Revista: ");
                revista = Console.ReadLine();

                if (revista.Length < 3)
                {
                    revistaInvalida = true;
                    ApresentarMensagem("Nome inválido. No mínimo 2 caracteres", ConsoleColor.Red);
                }

            } while (revistaInvalida);

            return revista;
        }
        public static double ObterNumeroEdicao()
        {
            double numedicao;

            bool numedicaoValido;
            do
            {
                Console.Write("Digite o numero da Edição: ");
                numedicaoValido = Double.TryParse(Console.ReadLine(), out numedicao);

                if (PrecoEstaInvalido(numedicao, numedicaoValido))
                    ApresentarMensagem("Numero de Edição inválido. Por favor digite um valor numérico positivo.", ConsoleColor.Red);

            } while (!numedicaoValido);

            return numedicao;
        }
        public static bool PrecoEstaInvalido(double numedicao, bool numedicaoValido)
        {
            return !numedicaoValido || numedicao <= 0;
        }
        public static DateTime ObterAnoRevista()
        {
            DateTime anorevista;
            bool anorevistaValida;
            do
            {
                Console.Write("Digite o ano da Revista: ");
                anorevistaValida = DateTime.TryParse(Console.ReadLine(), out anorevista);

                if (AnoRevistaExcedeDiaDeHoje(anorevista))
                {
                    anorevistaValida = false;
                    ApresentarMensagem("Data do ano da Revista não pode ser maior que hoje.", ConsoleColor.Red);
                }

                if (!anorevistaValida)
                    ApresentarMensagem("Data inválida. Digite uma data válida no formato 'dd/MM/aaaa'.", ConsoleColor.Red);

            } while (!anorevistaValida);

            return anorevista;
        }
        public static bool AnoRevistaExcedeDiaDeHoje(DateTime anorevista)
        {
            return anorevista > DateTime.Today;
        }
        public static string ObterCaixadaRevista()
        {
            string caixaguardada;

            bool caixaguardadaInvalido;
            do
            {
                caixaguardadaInvalido = false;
                Console.Write("Digite a Caixa onde está guardada: ");
                caixaguardada = Console.ReadLine();

                if (TamanhoFabricanteEstaInvalido(caixaguardada))
                {
                    ApresentarMensagem("Caixa inválida. Por favor insira uma caixa.", ConsoleColor.Red);

                    caixaguardadaInvalido = true;
                }

            } while (caixaguardadaInvalido);

            return caixaguardada;
        }
        public static bool TamanhoFabricanteEstaInvalido(string caixaguardada)
        {
            return caixaguardada.Length == 0;
        }
        #endregion
        
        #endregion

        #region Cadastro de Empréstimo

        public static string ApresentarMenuCadastroEmprestimo()
        {
            Console.Clear();

            Console.WriteLine("Clube do Livro");
            Console.WriteLine();

            Console.WriteLine("Digite 1 para inserir um novo Empréstimo");
            Console.WriteLine("Digite 2 para visualizar Empréstimos");
            Console.WriteLine("Digite 3 para visualizar Revistas Cadastradas");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        public static void InserirNovoEmprestimo()
        {
            MostrarCabecalho("Cadastro de Emprestimo", "Registrando uma nova revista:");

            IdEmprestimo++;

            GravarEmprestimo(0);

            ApresentarMensagem("Emprestimo cadastrado com sucesso", ConsoleColor.Green);
        }
        public static void GravarEmprestimo(int IdEmprestimoSelecionada)
        {
            string amigoemp = ObterTipoColecaoEmprestimo();

            double revistaemp = ObterNumeroEdicaoEmprestimo();

            DateTime dataemp = ObterDataEmprestimo();

            DateTime datadev = ObterDataDevolucao();

            int posicao;

            if (IdEmprestimoSelecionada == 0)
            {
                posicao = ObterPosicaoVagaParaEmprestimo();
                idsEmprestimo[posicao] = IdEmprestimo;
            }
            else
                posicao = ObterPosicaoOcupadaParaRevistas(IdEmprestimoSelecionada);

            amigoemprestado[posicao] = amigoemp;
            revistaemprestada[posicao] = revistaemp;
            dataemprestimo[posicao] = dataemp;
            datadevolução[posicao] = datadev;

        }
        public static int VisualizarEmprestimo(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho("Clube do Livro", "Visualizando Emprestimos:");

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-45} | {2,-35} | {3,-25}", "Id", "Revista Emprestada", "Data Emprestada" , "Data Devolução");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            int numeroEmprestimoCadastrados = 0;

            for (int i = 0; i < idsEmprestimo.Length; i++)
            {
                if (idsEmprestimo[i] > 0)
                {
                    Console.Write("{0,-10} | {1,-45} | {2,-35} | {3,-25}", idsEmprestimo[i], revistaemprestada[i], dataemprestimo[i], datadevolução[i]);

                    Console.WriteLine();

                    numeroEmprestimoCadastrados++;
                }
            }

            if (numeroEmprestimoCadastrados == 0)
                ApresentarMensagem("Nenhum Emprestimo cadastrado!", ConsoleColor.DarkYellow);
            else
                Console.ReadLine();

            return numeroEmprestimoCadastrados;
        }
        public static int ObterPosicaoVagaParaEmprestimo()
        {
            int posicao = 0;

            for (int i = 0; i < idsEmprestimo.Length; i++)
            {
                if (idsEmprestimo[i] == 0)
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
        public static int ObterPosicaoOcupadaParaEmprestimo(int idEmprestimoSelecionado)
        {
            int posicao = 0;

            for (int i = 0; i < idsEmprestimo.Length; i++)
            {
                if (idEmprestimoSelecionado == idsEmprestimo[i])
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
        public static bool ExisteEmprestimo(int idSelecionado)
        {
            for (int i = 0; i < idsEmprestimo.Length; i++)
            {
                if (idsEmprestimo[i] == idSelecionado)
                    return true;
            }

            return false;
        } //NÃO UTILIZADO ATÉ O MOMENTO, PARA VERIFICAR SE EXISTE DADOS NO ID DA REVISTA

        #region Validações de Cadastro de Revistas

        private static string ObterTipoColecaoEmprestimo()
        {
            string amigoemp;

            bool amigoempInvalida;
            do
            {
                amigoempInvalida = false;
                Console.Write("Digite o nome do Amigo que foi emprestado a Revista: ");
                amigoemp = Console.ReadLine();

                if (amigoemp.Length < 3)
                {
                    amigoempInvalida = true;
                    ApresentarMensagem("Nome inválido. No mínimo 2 caracteres", ConsoleColor.Red);
                }

            } while (amigoempInvalida);

            return amigoemp;
        }
        private static double ObterNumeroEdicaoEmprestimo()
        {
            double revistaemp;

            bool revistaempValido;
            do
            {
                Console.Write("Digite o numero da Revista Emprestada: ");
                revistaempValido = Double.TryParse(Console.ReadLine(), out revistaemp);

                if (PrecoEstaInvalidoEmprestimo(revistaemp, revistaempValido))
                    ApresentarMensagem("Revista Emprestada inválida. Por favor digite um valor numérico positivo.", ConsoleColor.Red);

            } while (!revistaempValido);

            return revistaemp;
        }
        private static bool PrecoEstaInvalidoEmprestimo(double revistaemp, bool revistaempValido)
        {
            return !revistaempValido || revistaemp <= 0;
        }
        private static DateTime ObterDataEmprestimo()
        {
            DateTime dataemp;
            bool dataempValida;
            do
            {
                Console.Write("Digite a data que foi Emprestado a Revista: ");
                dataempValida = DateTime.TryParse(Console.ReadLine(), out dataemp);

                if (DataExcedeEmprestado(dataemp))
                {
                    dataempValida = false;
                    ApresentarMensagem("Data do ano da Revista não pode ser maior que hoje.", ConsoleColor.Red);
                }

                if (!dataempValida)
                    ApresentarMensagem("Data inválida. Digite uma data válida no formato 'dd/MM/aaaa'.", ConsoleColor.Red);

            } while (!dataempValida);

            return dataemp;
        }
        private static bool DataExcedeEmprestado(DateTime dataemp)
        {
            return dataemp > DateTime.Today;
        }
        private static DateTime ObterDataDevolucao()
        {
            DateTime datadev;
            bool datadevValida;
            do
            {
                Console.Write("Digite a data que foi Devolvida a Revista: ");
                datadevValida = DateTime.TryParse(Console.ReadLine(), out datadev);

                if (DataExcedeDevolucao(datadev))
                {
                    datadevValida = false;
                    ApresentarMensagem("Data do ano da Revista não pode ser maior que hoje.", ConsoleColor.Red);
                }

                if (!datadevValida)
                    ApresentarMensagem("Data inválida. Digite uma data válida no formato 'dd/MM/aaaa'.", ConsoleColor.Red);

            } while (!datadevValida);

            return datadev;
        }
        private static bool DataExcedeDevolucao(DateTime anorevista)
        {
            return anorevista > DateTime.Today;
        }
        #endregion

        #endregion

        #region Cadastro de Amigos

        public static string ApresentarMenuCadastroAmigos()
        {
            Console.Clear();

            Console.WriteLine("Clube do Livro");
            Console.WriteLine();

            Console.WriteLine("Digite 1 para inserir um novo Amigo");
            Console.WriteLine("Digite 2 para visualizar Amigos");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public static void InserirNovoAmigos()
        {
            MostrarCabecalho("Cadastro de Amigos", "Registrando um novo amigo:");

            IdAmigos++;

            GravarAmigos(0);

            ApresentarMensagem("Amigo cadastrado com sucesso", ConsoleColor.Green);
        }

        public static void GravarAmigos(int IdAmigosSelecionada)
        {
            string namigos = ObterNomeAmigo();

            string nresponsavel = ObterNomeResponsavel();

            string telefoneamigo = ObterTelefoneAmigo();

            string enderecoamigo = ObterEnderecoAmigo();

            int posicao;

            if (IdAmigosSelecionada == 0)
            {
                posicao = ObterPosicaoVagaParaEmprestimo();
                idsAmigos[posicao] = IdAmigos;
            }
            else
                posicao = ObterPosicaoOcupadaParaAmigos(IdAmigosSelecionada);

            nomeAmigos[posicao] = namigos;
            nomeResponsavel[posicao] = nresponsavel;
            telefoneAmigos[posicao] = telefoneamigo;
            enderecoAmigos[posicao] = enderecoamigo;

        }

        public static int VisualizarAmigos(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho("Clube do Livro", "Visualizando Amigos:");

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-45} | {2,-35} | {3,-25}", "Id", "Nome Amigo", "Telefone Amigo", "Endereço Amigo");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            int numeroAmigosCadastrados = 0;

            for (int i = 0; i < idsAmigos.Length; i++)
            {
                if (idsAmigos[i] > 0)
                {
                    Console.Write("{0,-10} | {1,-55} | {2,-45} | {3,-35}", idsAmigos[i], nomeAmigos[i], nomeResponsavel[i], telefoneAmigos[i]);

                    Console.WriteLine();

                    numeroAmigosCadastrados++;
                }
            }

            if (numeroAmigosCadastrados == 0)
                ApresentarMensagem("Nenhum Amigo cadastrado!", ConsoleColor.DarkYellow);
            else
                Console.ReadLine();

            return numeroAmigosCadastrados;
        }

        public static int ObterPosicaoVagaParaAmigos()
        {
            int posicao = 0;

            for (int i = 0; i < idsAmigos.Length; i++)
            {
                if (idsAmigos[i] == 0)
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }

        public static int ObterPosicaoOcupadaParaAmigos(int idAmigosSelecionado)
        {
            int posicao = 0;

            for (int i = 0; i < idsAmigos.Length; i++)
            {
                if (idAmigosSelecionado == idsAmigos[i])
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }

        public static bool ExisteAmigos(int idAmigos)
        {
            for (int i = 0; i < idsAmigos.Length; i++)
            {
                if (idsAmigos[i] == idAmigos)
                    return true;
            }

            return false;
        } //NÃO UTILIZADO ATÉ O MOMENTO, PARA VERIFICAR SE EXISTE DADOS NO ID DA REVISTA

        #region Validações de Cadastro de Amigos

        public static string ObterNomeAmigo()
        {
            string namigos;

            bool namigosInvalida;
            do
            {
                namigosInvalida = false;
                Console.Write("Digite o nome do Amigo que foi emprestado a Revista: ");
                    namigos = Console.ReadLine();

                if (namigos.Length < 3)
                {
                    namigosInvalida = true;
                    ApresentarMensagem("Nome inválido. No mínimo 3 caracteres", ConsoleColor.Red);
                }

            } while (namigosInvalida);

            return namigos;
        }

        public static string ObterNomeResponsavel()
        {
            string nresponsavel;

            bool nresponsavelInvalida;
            do
            {
                nresponsavelInvalida = false;
                Console.Write("Digite o nome do Responsavel do Amigo que foi emprestado a Revista: ");
                nresponsavel = Console.ReadLine();

                if (nresponsavel.Length < 3)
                {
                    nresponsavelInvalida = true;
                    ApresentarMensagem("Nome Responsavel inválido. No mínimo 3 caracteres", ConsoleColor.Red);
                }

            } while (nresponsavelInvalida);

            return nresponsavel;
        }

        public static string ObterTelefoneAmigo()
        {
            string telefoneamigo;

            bool telefoneamigoInvalida;
            do
            {
                telefoneamigoInvalida = false;
                Console.Write("Digite o Telefone do Amigo que foi emprestado a Revista: ");
                telefoneamigo = Console.ReadLine();

                if (telefoneamigo.Length < 3)
                {
                    telefoneamigoInvalida = true;
                    ApresentarMensagem("Telefone inválido. No mínimo 3 caracteres", ConsoleColor.Red);
                }

            } while (telefoneamigoInvalida);

            return telefoneamigo;
        }

        public static string ObterEnderecoAmigo()
        {
            string enderecoamigo;

            bool enderecoamigoInvalida;
            do
            {
                enderecoamigoInvalida = false;
                Console.Write("Digite o Endereço do Amigo que foi emprestado a Revista: ");
                enderecoamigo = Console.ReadLine();

                if (enderecoamigo.Length < 5)
                {
                    enderecoamigoInvalida = true;
                    ApresentarMensagem("Endereço inválido. No mínimo 5 caracteres", ConsoleColor.Red);
                }

            } while (enderecoamigoInvalida);

            return enderecoamigo;
        }

        #endregion

        #endregion

        #region Métodos de uso geral

        public static void MostrarCabecalho(string titulo, string subtitulo)
        {
            Console.Clear();
            Console.WriteLine(titulo);
            Console.WriteLine();
            Console.WriteLine(subtitulo);
            Console.WriteLine();
        }
        public static string ApresentarMenuPrincipal()
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
        public static void ApresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();

            Console.ReadLine();
        }

        #endregion
    }
}
