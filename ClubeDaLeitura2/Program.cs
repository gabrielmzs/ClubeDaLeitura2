using ClubeDaLeitura2.ModuloAmigo;
using ClubeDaLeitura2.ModuloCaixa;
using ClubeDaLeitura2.ModuloRevista;
using ClubeDaLeitura2.ModuloEmprestimo;
using System.Collections;

namespace ClubeDaLeitura2 {
    internal class Program {
        static void Main(string[] args) {

            RepositorioCaixa repositorioCaixa = new RepositorioCaixa(new ArrayList());
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo(new ArrayList());
            RepositorioRevista repositorioRevista = new RepositorioRevista(new ArrayList());
            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo(new ArrayList());

            CadastrarAutomatico();

            TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa,repositorioRevista);
            TelaAmigo telaAmigo = new TelaAmigo(repositorioAmigo);
            TelaRevista telaRevista = new TelaRevista(repositorioRevista, telaCaixa, repositorioCaixa);
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo, repositorioRevista, repositorioAmigo, telaRevista, telaAmigo);

            while (true) {
                Console.Clear();
                Console.WriteLine("CLUBE DA LEITURA 1.0");
                Console.WriteLine("1 - Cadastro Caixas");
                Console.WriteLine("2 - Cadastro Amigos");
                Console.WriteLine("3 - Cadastro Revistas");
                Console.WriteLine("4 - Cadastro Empréstimo");
                Console.WriteLine("0 - Encerrar");

                string opcao = Console.ReadLine();

                if (opcao == "0") {
                    break;
                } else if (opcao == "1") {

                    string opcaoCaixa = telaCaixa.ApresentarMenu();

                    if (opcaoCaixa == "1") {
                        telaCaixa.Inserir();
                    } else if (opcaoCaixa == "2") {
                        telaCaixa.Visualizar();
                    } else if (opcaoCaixa == "3") {
                        telaCaixa.Editar();
                    } else if (opcaoCaixa == "4") {
                        telaCaixa.Deletar();
                    }
                    continue;

                } else if (opcao == "2") {


                    string opcaoAmigo = telaAmigo.ApresentarMenu();

                    if (opcaoAmigo == "1") {
                        telaAmigo.Inserir();
                    } else if (opcaoAmigo == "2") {
                        telaAmigo.Visualizar();
                    } else if (opcaoAmigo == "3") {
                        telaAmigo.Editar();
                    } else if (opcaoAmigo == "4") {
                        telaAmigo.Deletar();
                    }
                    continue;

                } else if (opcao == "3") {

                    string opcaoRevista = telaRevista.ApresentarMenu();

                    if (opcaoRevista == "1") {
                        telaRevista.Inserir();
                    } else if (opcaoRevista == "2") {
                        telaRevista.Visualizar();
                    } else if (opcaoRevista == "3") {
                        telaRevista.Editar();
                    } else if (opcaoRevista == "4") {
                        telaRevista.Deletar();
                    }
                    continue;
                } else if (opcao == "4") {

                    string opcaoEmprestimo = telaEmprestimo.ApresentarMenu();
                    if (opcaoEmprestimo == "1") {
                        telaEmprestimo.Inserir();
                    } else if (opcaoEmprestimo == "2") {
                        telaEmprestimo.Visualizar();
                    } else if (opcaoEmprestimo == "3") {
                        telaEmprestimo.Editar();
                    } else if (opcaoEmprestimo == "4") {
                        telaEmprestimo.Deletar();
                    } else if (opcaoEmprestimo == "5") {
                        telaEmprestimo.MostrarAbertos();
                    } else if (opcaoEmprestimo == "6") {
                        telaEmprestimo.MostrarEmprestimosMes();
                    } else if (opcaoEmprestimo == "7") {
                        telaEmprestimo.EncerrarEmprestimo();
                    }
                    continue;


                }
            }
             void CadastrarAutomatico() {

                Caixa caixa = new Caixa("Verde", "abc-123");
                repositorioCaixa.Inserir(caixa);
                Caixa caixa2 = new Caixa("Azul", "GHJ-678");
                repositorioCaixa.Inserir(caixa2);
                Revista revista = new Revista("Batman", 244, 1990, caixa);
                repositorioRevista.Inserir(revista);
                Revista revista2 = new Revista("Miranha", 111, 1966, caixa);
                repositorioRevista.Inserir(revista2);
                Amigo amigo = new Amigo("João", "Pai do João", "Rua do João", "89999");
                repositorioAmigo.Inserir(amigo);
                Amigo amigo2 = new Amigo("Fernando", "Serginho", "Rua da rua", "234634");
                repositorioAmigo.Inserir(amigo2);
                Emprestimo emprestimo = new Emprestimo(new DateTime(2022,04,15), revista, amigo);
                repositorioEmprestimo.Inserir(emprestimo);
                Emprestimo emprestimo2 = new Emprestimo(new DateTime(2023, 04, 22), revista2, amigo2);
                repositorioEmprestimo.Inserir(emprestimo2);
                Emprestimo emprestimo3 = new Emprestimo(new DateTime(2023, 04, 03), revista, amigo2);
                repositorioEmprestimo.Inserir(emprestimo3);
            }


        }

        
    }
}