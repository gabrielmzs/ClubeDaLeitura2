using ClubeDaLeitura2.Compartilhado;
using ClubeDaLeitura2.ModuloRevista;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura2.ModuloCaixa {
    public class TelaCaixa : Tela {

        RepositorioCaixa repositorioCaixa;
        RepositorioRevista repositorioRevista;

        public TelaCaixa(RepositorioCaixa repositorioCaixa, RepositorioRevista repositorioRevista) {
            this.repositorioCaixa = repositorioCaixa;
            this.repositorioRevista = repositorioRevista;

        }

        public string ApresentarMenu() {
            Console.Clear();
            Console.WriteLine("1 - Inserir Caixa");
            Console.WriteLine("2 - Visualizar Caixas");
            Console.WriteLine("3 - Editar Caixas");
            Console.WriteLine("4 - Deletar Caixa");
            Console.WriteLine("0 - Voltar");

            string opcao = Console.ReadLine();
            return opcao;
        }
        public void Inserir() {

            MostrarCabecalho("Cadastro de Caixas: ", "Inserindo uma nova caixa...");
            Caixa caixa = ObterCaixa();
            repositorioCaixa.Inserir(caixa);
            MostrarMensagem("Caixa inserida com sucesso!", ConsoleColor.Green);

        }
        public void Deletar() {
            MostrarCabecalho("Cadastro de Caixas: ", "Deletando uma caixa...");
            Visualizar();
            Console.Write("\nDigite o ID da caixa a ser deletada: ");
            int id = int.Parse(Console.ReadLine());

            if (repositorioRevista.TemRevista(id)) {
                MostrarMensagem("A caixa contém uma revista dentro. Não é possível excluir.", ConsoleColor.DarkYellow);
                return;
            } 
            else {
                repositorioCaixa.Excluir(id);
                MostrarMensagem("Caixa deletada com sucesso!", ConsoleColor.Green);
            }
        }
        public void Editar() {
            MostrarCabecalho("Cadastro de Caixas: ", "Editando uma caixa...");
            Visualizar();
            Console.Write("\nDigite o ID da caixa a ser editada: ");
            int id = int.Parse(Console.ReadLine());

            Caixa caixaAtualizada = ObterCaixa();

            repositorioCaixa.Editar(id, caixaAtualizada);
            MostrarMensagem("Caixa editada com sucesso!", ConsoleColor.Green);

        }
        public void Visualizar() {
            Console.WriteLine("Caixas Cadastradas: \n");
            ArrayList listaCaixas = repositorioCaixa.SelecionarTodos();
            if (listaCaixas.Count == 0) {
                MostrarMensagem("Não há caixas cadastradas!", ConsoleColor.DarkYellow);
                return;
            }
            MostrarTabela(listaCaixas);
        }
        private void MostrarTabela(ArrayList listaCaixas) {
            Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|", "ID", "Cor", "Etiqueta");
            Console.WriteLine("--------------------------------------------------");
            foreach (Caixa c in listaCaixas) {
                Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|", c.id, c.cor, c.etiqueta);
                Console.WriteLine("--------------------------------------------------");
            }
            Console.ReadLine();
        }
        private Caixa ObterCaixa() {
            Console.Write("Digite a cor da caixa: ");
            string cor = Console.ReadLine();
            Console.Write("Digite a etiqueta da caixa: ");
            string etiqueta = Console.ReadLine();

            Caixa caixa = new Caixa(cor, etiqueta);

            return caixa;
        }

    }


}
