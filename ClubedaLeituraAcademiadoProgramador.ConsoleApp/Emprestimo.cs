using System;

namespace ClubedaLeituraAcademiadoProgramador.ConsoleApp
{
    public partial class Program
    {
        public class Emprestimo
        {

            public string ApresentarMenuCadastroEmprestimo()
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
            public void InserirNovoEmprestimo()
            {
                Notificar notificar = new Notificar();

                notificar.MostrarCabecalho("Cadastro de Emprestimo", "Registrando uma nova revista:");

                IdEmprestimo++;

                GravarEmprestimo(0);

                notificar.ApresentarMensagem("Emprestimo cadastrado com sucesso", ConsoleColor.Green);
            }
            public void GravarEmprestimo(int IdEmprestimoSelecionada)
            {
                string amigoemp = ObterTipoColecaoEmprestimo();

                double revistaemp = ObterNumeroEdicaoEmprestimo();

                DateTime dataemp = ObterDataEmprestimo();

                DateTime datadev = ObterDataDevolucao();

                int posicao;

                Revista revista = new Revista();

                if (IdEmprestimoSelecionada == 0)
                {
                    posicao = ObterPosicaoVagaParaEmprestimo();
                    idsEmprestimo[posicao] = IdEmprestimo;
                }
                else
                    posicao = revista.ObterPosicaoOcupadaParaRevistas(IdEmprestimoSelecionada);

                amigoemprestado[posicao] = amigoemp;
                revistaemprestada[posicao] = revistaemp;
                dataemprestimo[posicao] = dataemp;
                datadevolução[posicao] = datadev;

            }
            public int VisualizarEmprestimo(bool mostrarCabecalho)
            {
                Notificar notificar = new Notificar();

                if (mostrarCabecalho)
                    notificar.MostrarCabecalho("Clube do Livro", "Visualizando Emprestimos:");

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("{0,-10} | {1,-45} | {2,-35} | {3,-25}", "Id", "Revista Emprestada", "Data Emprestada", "Data Devolução");

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
                    notificar.ApresentarMensagem("Nenhum Emprestimo cadastrado!", ConsoleColor.DarkYellow);
                else
                    Console.ReadLine();

                return numeroEmprestimoCadastrados;
            }
            public int ObterPosicaoVagaParaEmprestimo()
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
            public int ObterPosicaoOcupadaParaEmprestimo(int idEmprestimoSelecionado)
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
            public bool ExisteEmprestimo(int idSelecionado)
            {
                for (int i = 0; i < idsEmprestimo.Length; i++)
                {
                    if (idsEmprestimo[i] == idSelecionado)
                        return true;
                }

                return false;
            } //NÃO UTILIZADO ATÉ O MOMENTO, PARA VERIFICAR SE EXISTE DADOS NO ID DA REVISTA

            #region Validações de Cadastro de Emprestimo

            private string ObterTipoColecaoEmprestimo()
            {
                Notificar notificar = new Notificar();

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
                        notificar.ApresentarMensagem("Nome inválido. No mínimo 2 caracteres", ConsoleColor.Red);
                    }

                } while (amigoempInvalida);

                return amigoemp;
            }
            private double ObterNumeroEdicaoEmprestimo()
            {
                double revistaemp;

                bool revistaempValido;
                do
                {
                    Notificar notificar = new Notificar();

                    Console.Write("Digite o numero da Revista Emprestada: ");
                    revistaempValido = Double.TryParse(Console.ReadLine(), out revistaemp);

                    if (PrecoEstaInvalidoEmprestimo(revistaemp, revistaempValido))
                        notificar.ApresentarMensagem("Revista Emprestada inválida. Por favor digite um valor numérico positivo.", ConsoleColor.Red);

                } while (!revistaempValido);

                return revistaemp;
            }
            private bool PrecoEstaInvalidoEmprestimo(double revistaemp, bool revistaempValido)
            {
                return !revistaempValido || revistaemp <= 0;
            }
            private DateTime ObterDataEmprestimo()
            {
                Notificar notificar = new Notificar();

                DateTime dataemp;
                bool dataempValida;
                do
                {
                    Console.Write("Digite a data que foi Emprestado a Revista: ");
                    dataempValida = DateTime.TryParse(Console.ReadLine(), out dataemp);

                    if (DataExcedeEmprestado(dataemp))
                    {
                        dataempValida = false;
                        notificar.ApresentarMensagem("Data do ano da Revista não pode ser maior que hoje.", ConsoleColor.Red);
                    }

                    if (!dataempValida)
                        notificar.ApresentarMensagem("Data inválida. Digite uma data válida no formato 'dd/MM/aaaa'.", ConsoleColor.Red);

                } while (!dataempValida);

                return dataemp;
            }
            private bool DataExcedeEmprestado(DateTime dataemp)
            {
                return dataemp > DateTime.Today;
            }
            private DateTime ObterDataDevolucao()
            {
                Notificar notificar = new Notificar();

                DateTime datadev;
                bool datadevValida;
                do
                {
                    Console.Write("Digite a data que foi Devolvida a Revista: ");
                    datadevValida = DateTime.TryParse(Console.ReadLine(), out datadev);

                    if (DataExcedeDevolucao(datadev))
                    {
                        datadevValida = false;
                        notificar.ApresentarMensagem("Data do ano da Revista não pode ser maior que hoje.", ConsoleColor.Red);
                    }

                    if (!datadevValida)
                        notificar.ApresentarMensagem("Data inválida. Digite uma data válida no formato 'dd/MM/aaaa'.", ConsoleColor.Red);

                } while (!datadevValida);

                return datadev;
            }
            private bool DataExcedeDevolucao(DateTime anorevista)
            {
                return anorevista > DateTime.Today;
            }

            #endregion

        }

    }
}
