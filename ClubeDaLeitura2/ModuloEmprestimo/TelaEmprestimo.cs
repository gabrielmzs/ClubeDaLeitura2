using ClubeDaLeitura2.Compartilhado;
using ClubeDaLeitura2.ModuloAmigo;
using ClubeDaLeitura2.ModuloCaixa;
using ClubeDaLeitura2.ModuloRevista;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura2.ModuloEmprestimo {
    public class TelaEmprestimo:Tela {

        RepositorioEmprestimo repositorioEmprestimo;
        RepositorioRevista repositorioRevista;
        RepositorioAmigo repositorioAmigo;

        TelaRevista telaRevista;
        TelaAmigo telaAmigo;

        public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, RepositorioRevista repositorioRevista, RepositorioAmigo repositorioAmigo, TelaRevista telaRevista, TelaAmigo telaAmigo) {
            this.repositorioEmprestimo = repositorioEmprestimo;
            this.repositorioRevista = repositorioRevista;
            this.repositorioAmigo = repositorioAmigo;
            this.telaRevista = telaRevista;
            this.telaAmigo = telaAmigo;
        }

        internal string ApresentarMenu() {
            Console.Clear();
            Console.WriteLine("1 - Inserir Emprésitmo");
            Console.WriteLine("2 - Visualizar Empréstimos");
            Console.WriteLine("3 - Editar Empréstimo");
            Console.WriteLine("4 - Deletar Empréstimos");
            Console.WriteLine("5 - Mostrar Empréstimos Abertos");
            Console.WriteLine("6 - Mostrar Empréstimos Abertos No Mês");
            Console.WriteLine("7 - Encerrar Um Empréstimo");
            Console.WriteLine("0 - Voltar");
            string opcao = Console.ReadLine();
            return opcao;
        }

        internal void Inserir() {
            MostrarCabecalho("Cadastro de Empréstimos: ", "Abrindo um novo empréstimo...");
            Emprestimo emprestimo = ObterEmprestimo();

            repositorioEmprestimo.Inserir(emprestimo);
            MostrarMensagem("Empréstimo aberto com sucesso!", ConsoleColor.Green);
        }
        

        public void Visualizar() {
            Console.WriteLine("Empréstimos Cadastrados:\n ");
            ArrayList listaEmprestimos = repositorioEmprestimo.SelecionarTodos();
            if (listaEmprestimos.Count == 0) {
                MostrarMensagem("Não há empréstimos cadastradas!", ConsoleColor.DarkYellow);
                return;
            }
            MostrarTabela(listaEmprestimos);
        }

        private void MostrarTabela(ArrayList listaEmprestimos) {
            Console.WriteLine("{0,-5} |{1,-20} |{2,-20} |{3,-20} |{4,-15} |", "ID", "Amigo", "Revista","Status","Saída");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            foreach (Emprestimo e in listaEmprestimos) {
                var data = string.Format("{0:dd/MM/yyyy}", e.dataSaida);
                Console.WriteLine("{0,-5} |{1,-20} |{2,-20} |{3,-20} |{4,-15} |", e.id, e.amigo.nome, e.revista.colecao, e.status, data);
                Console.WriteLine("------------------------------------------------------------------------------------------");
            }
            Console.ReadLine();
        }

        public void Editar() {
            MostrarCabecalho("Cadastro de Empréstimos: ", "Editando um empréstimo...");
            Visualizar();
            Console.Write("\nDigite o ID da empréstimo a ser editado: ");
            int id = int.Parse(Console.ReadLine());

            Emprestimo emprestimoAtualizado = ObterEmprestimo();

            repositorioEmprestimo.Editar(id, emprestimoAtualizado);
            MostrarMensagem("Empréstimo editado com sucesso!", ConsoleColor.Green);
        }

        public void Deletar() {
            MostrarCabecalho("Cadastro de Empréstimos: ", "Editando um empréstimo...");
            Visualizar();
            Console.Write("\nDigite o ID da empréstimo a ser editado: ");
            int id = int.Parse(Console.ReadLine());

            repositorioEmprestimo.Excluir(id);
            MostrarMensagem("Empréstimo excluído com sucesso!", ConsoleColor.Green);
        }
        public void MostrarAbertos() {
            ArrayList listaAbertos = repositorioEmprestimo.SelecionarAbertos();
            if(listaAbertos.Count == 0) {
                MostrarMensagem("Não há empréstimos em aberto!", ConsoleColor.DarkYellow);
                return;
            }
            MostrarTabela(listaAbertos);
        }
        


        public void MostrarEmprestimosMes() {
            Console.WriteLine("Informe o mês e o ano (MM/YYYY): ");
            string[] data = Console.ReadLine().Split("/");

            int mes = Convert.ToInt32(data[0]);
            int ano = Convert.ToInt32(data[1]);

            ArrayList listaAbertos = repositorioEmprestimo.SelecionarEmprestimosMes(mes, ano);
            if (listaAbertos.Count == 0) {
                MostrarMensagem("Nenhum empréstimo foi aberto no mês pesquisado!", ConsoleColor.DarkYellow);
                return;
            }
            MostrarTabela(listaAbertos);
        }

        private Emprestimo ObterEmprestimo() {
            telaRevista.Visualizar();
            Console.Write("\nDigite o ID da revista: ");
            int id = int.Parse(Console.ReadLine());
            Revista revista = repositorioRevista.SelecionarPorId(id);
            telaAmigo.Visualizar();
            Console.Write("\nDigite o ID do amigo: ");
            int id2 = int.Parse(Console.ReadLine());
            Amigo amigo = repositorioAmigo.SelecionarPorId(id2);
            Console.Write("Informa a data de saída (DD/MM/YYYY): ");
            DateTime dataSaida = Convert.ToDateTime(Console.ReadLine());

            Emprestimo emprestimo = new Emprestimo(dataSaida, revista, amigo);

            return emprestimo;
        }

        internal void EncerrarEmprestimo() {

            MostrarCabecalho("Cadastro de Empréstimos: ", "Encerrando um empréstimo...");
            Visualizar();
            Console.Write("\nDigite o ID da empréstimo a ser encerrado: ");
            int id = int.Parse(Console.ReadLine());

            repositorioEmprestimo.Encerrar(id);

            MostrarMensagem("Empréstimo encerrado com sucesso!", ConsoleColor.Green);
        }
    }
}
