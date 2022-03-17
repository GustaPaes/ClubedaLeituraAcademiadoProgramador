using System;

namespace ClubedaLeituraAcademiadoProgramador.ConsoleApp
{
    public partial class Program
    {
        public class Amigos
        {

            public string ApresentarMenuCadastroAmigos()
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
            public void InserirNovoAmigos()
            {
                Notificar notificar = new Notificar();

                notificar.MostrarCabecalho("Cadastro de Amigos", "Registrando um novo amigo:");

                IdAmigos++;

                GravarAmigos(0);

                notificar.ApresentarMensagem("Amigo cadastrado com sucesso", ConsoleColor.Green);
            }
            public void GravarAmigos(int IdAmigosSelecionada)
            {
                string namigos = ObterNomeAmigo();

                string nresponsavel = ObterNomeResponsavel();

                string telefoneamigo = ObterTelefoneAmigo();

                string enderecoamigo = ObterEnderecoAmigo();

                int posicao;

                Emprestimo emprestimo = new Emprestimo();

                if (IdAmigosSelecionada == 0)
                {
                    posicao = emprestimo.ObterPosicaoVagaParaEmprestimo();
                    idsAmigos[posicao] = IdAmigos;
                }
                else
                    posicao = ObterPosicaoOcupadaParaAmigos(IdAmigosSelecionada);

                nomeAmigos[posicao] = namigos;
                nomeResponsavel[posicao] = nresponsavel;
                telefoneAmigos[posicao] = telefoneamigo;
                enderecoAmigos[posicao] = enderecoamigo;

            }
            public int VisualizarAmigos(bool mostrarCabecalho)
            {
                Notificar notificar = new Notificar();

                if (mostrarCabecalho)
                    notificar.MostrarCabecalho("Clube do Livro", "Visualizando Amigos:");

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
                    notificar.ApresentarMensagem("Nenhum Amigo cadastrado!", ConsoleColor.DarkYellow);
                else
                    Console.ReadLine();

                return numeroAmigosCadastrados;
            }
            public int ObterPosicaoVagaParaAmigos()
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
            public int ObterPosicaoOcupadaParaAmigos(int idAmigosSelecionado)
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
            public bool ExisteAmigos(int idAmigos)
            {
                for (int i = 0; i < idsAmigos.Length; i++)
                {
                    if (idsAmigos[i] == idAmigos)
                        return true;
                }

                return false;
            } //NÃO UTILIZADO ATÉ O MOMENTO, PARA VERIFICAR SE EXISTE DADOS NO ID DA REVISTA

            #region Validações de Cadastro de Amigos

            public string ObterNomeAmigo()
            {
                string namigos;

                bool namigosInvalida;
                do
                {
                    Notificar notificar = new Notificar();

                    namigosInvalida = false;
                    Console.Write("Digite o nome do Amigo que foi emprestado a Revista: ");
                    namigos = Console.ReadLine();

                    if (namigos.Length < 3)
                    {
                        namigosInvalida = true;
                        notificar.ApresentarMensagem("Nome inválido. No mínimo 3 caracteres", ConsoleColor.Red);
                    }

                } while (namigosInvalida);

                return namigos;
            }
            public string ObterNomeResponsavel()
            {
                string nresponsavel;

                bool nresponsavelInvalida;
                do
                {
                    Notificar notificar = new Notificar();

                    nresponsavelInvalida = false;
                    Console.Write("Digite o nome do Responsavel do Amigo que foi emprestado a Revista: ");
                    nresponsavel = Console.ReadLine();

                    if (nresponsavel.Length < 3)
                    {
                        nresponsavelInvalida = true;
                        notificar.ApresentarMensagem("Nome Responsavel inválido. No mínimo 3 caracteres", ConsoleColor.Red);
                    }

                } while (nresponsavelInvalida);

                return nresponsavel;
            }
            public string ObterTelefoneAmigo()
            {
                string telefoneamigo;

                bool telefoneamigoInvalida;
                do
                {
                    Notificar notificar = new Notificar();

                    telefoneamigoInvalida = false;
                    Console.Write("Digite o Telefone do Amigo que foi emprestado a Revista: ");
                    telefoneamigo = Console.ReadLine();

                    if (telefoneamigo.Length < 3)
                    {
                        telefoneamigoInvalida = true;
                        notificar.ApresentarMensagem("Telefone inválido. No mínimo 3 caracteres", ConsoleColor.Red);
                    }

                } while (telefoneamigoInvalida);

                return telefoneamigo;
            }
            public string ObterEnderecoAmigo()
            {
                string enderecoamigo;

                bool enderecoamigoInvalida;
                do
                {
                    Notificar notificar = new Notificar();

                    enderecoamigoInvalida = false;
                    Console.Write("Digite o Endereço do Amigo que foi emprestado a Revista: ");
                    enderecoamigo = Console.ReadLine();

                    if (enderecoamigo.Length < 5)
                    {
                        enderecoamigoInvalida = true;
                        notificar.ApresentarMensagem("Endereço inválido. No mínimo 5 caracteres", ConsoleColor.Red);
                    }

                } while (enderecoamigoInvalida);

                return enderecoamigo;
            }

            #endregion

        }

    }
}
