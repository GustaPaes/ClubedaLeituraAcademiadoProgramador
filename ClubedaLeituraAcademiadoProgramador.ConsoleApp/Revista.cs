using System;

namespace ClubedaLeituraAcademiadoProgramador.ConsoleApp
{
    public partial class Program
    {

        public class Revista
        {

            public string ApresentarMenuCadastroRevista()
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
            public void InserirNovaRevista()
            {
                Notificar notificar = new Notificar();

                notificar.MostrarCabecalho("Cadastro de Revistas", "Registrando uma nova revista:");

                IdRevista++;

                GravarRevista(0);

                notificar.ApresentarMensagem("Revista cadastrada com sucesso", ConsoleColor.Green);
            }
            public void GravarRevista(int IdRevistaSelecionada)
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
            public int VisualizarRevistas(bool mostrarCabecalho)
            {
                Notificar notificar = new Notificar();

                if (mostrarCabecalho)
                    notificar.MostrarCabecalho("Cadastro de Revista", "Visualizando revista:");

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
                    notificar.ApresentarMensagem("Nenhuma Revista cadastrada!", ConsoleColor.DarkYellow);
                else
                    Console.ReadLine();

                return numeroRevistasCadastrados;
            }
            public int ObterPosicaoVagaParaRevistas()
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
            public int ObterPosicaoOcupadaParaRevistas(int idRevistaSelecionado)
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
            public bool ExisteRevista(int idSelecionado)
            {
                for (int i = 0; i < idsRevista.Length; i++)
                {
                    if (idsRevista[i] == idSelecionado)
                        return true;
                }

                return false;
            } //NÃO UTILIZADO ATÉ O MOMENTO, PARA VERIFICAR SE EXISTE DADOS NO ID DA REVISTA

            #region Validações de Cadastro de Revistas

            public string ObterTipoColecao()
            {
                Notificar notificar = new Notificar();

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
                        notificar.ApresentarMensagem("Nome inválido. No mínimo 2 caracteres", ConsoleColor.Red);
                    }

                } while (revistaInvalida);

                return revista;
            }
            public double ObterNumeroEdicao()
            {
                Notificar notificar = new Notificar();

                double numedicao;

                bool numedicaoValido;
                do
                {
                    Console.Write("Digite o numero da Edição: ");
                    numedicaoValido = Double.TryParse(Console.ReadLine(), out numedicao);

                    if (PrecoEstaInvalido(numedicao, numedicaoValido))
                        notificar.ApresentarMensagem("Numero de Edição inválido. Por favor digite um valor numérico positivo.", ConsoleColor.Red);

                } while (!numedicaoValido);

                return numedicao;
            }
            public bool PrecoEstaInvalido(double numedicao, bool numedicaoValido)
            {
                return !numedicaoValido || numedicao <= 0;
            }
            public DateTime ObterAnoRevista()
            {
                Notificar notificar = new Notificar();

                DateTime anorevista;
                bool anorevistaValida;
                do
                {
                    Console.Write("Digite o ano da Revista: ");
                    anorevistaValida = DateTime.TryParse(Console.ReadLine(), out anorevista);

                    if (AnoRevistaExcedeDiaDeHoje(anorevista))
                    {
                        anorevistaValida = false;
                        notificar.ApresentarMensagem("Data do ano da Revista não pode ser maior que hoje.", ConsoleColor.Red);
                    }

                    if (!anorevistaValida)
                        notificar.ApresentarMensagem("Data inválida. Digite uma data válida no formato 'dd/MM/aaaa'.", ConsoleColor.Red);

                } while (!anorevistaValida);

                return anorevista;
            }
            public bool AnoRevistaExcedeDiaDeHoje(DateTime anorevista)
            {
                return anorevista > DateTime.Today;
            }
            public string ObterCaixadaRevista()
            {
                Notificar notificar = new Notificar();

                string caixaguardada;

                bool caixaguardadaInvalido;
                do
                {
                    caixaguardadaInvalido = false;
                    Console.Write("Digite a Caixa onde está guardada: ");
                    caixaguardada = Console.ReadLine();

                    if (TamanhoFabricanteEstaInvalido(caixaguardada))
                    {
                        notificar.ApresentarMensagem("Caixa inválida. Por favor insira uma caixa.", ConsoleColor.Red);

                        caixaguardadaInvalido = true;
                    }

                } while (caixaguardadaInvalido);

                return caixaguardada;
            }
            public bool TamanhoFabricanteEstaInvalido(string caixaguardada)
            {
                return caixaguardada.Length == 0;
            }

            #endregion


        }
    }
}
