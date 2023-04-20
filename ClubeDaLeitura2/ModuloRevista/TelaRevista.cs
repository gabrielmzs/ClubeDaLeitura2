using ClubeDaLeitura2.Compartilhado;
using ClubeDaLeitura2.ModuloAmigo;
using ClubeDaLeitura2.ModuloCaixa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura2.ModuloRevista
{
    public class TelaRevista:Tela {

        RepositorioRevista repositorioRevista;
        RepositorioCaixa repositorioCaixa;
        TelaCaixa telaCaixa;

        public TelaRevista(RepositorioRevista repositorioRevista, TelaCaixa telaCaixa, RepositorioCaixa repositorioCaixa) {
            this.repositorioRevista = repositorioRevista;
            this.telaCaixa = telaCaixa;
            this.repositorioCaixa = repositorioCaixa;
        }

        public string ApresentarMenu() {
            Console.Clear();
            Console.WriteLine("1 - Inserir Revista");
            Console.WriteLine("2 - Visualizar Revistas");
            Console.WriteLine("3 - Editar Revista");
            Console.WriteLine("4 - Deletar Revista");
            Console.WriteLine("0 - Voltar");
            string opcao = Console.ReadLine();

            return opcao;
        }

        public void Inserir() {
            MostrarCabecalho("Cadastro de Revistas: ", "Inserindo uma nova revista...");
            Revista revista = ObterRevista();
            
            repositorioRevista.Inserir(revista);
            MostrarMensagem("Revista cadastrada com sucesso!", ConsoleColor.Green);
        }

        public void Visualizar() {
            Console.WriteLine("Revistas Cadastradas:\n ");
            ArrayList listaRevistas = repositorioRevista.SelecionarTodos();
            if (listaRevistas.Count == 0) {
                MostrarMensagem("Não há revistas cadastradas!", ConsoleColor.DarkYellow);
                return;
            }
            MostrarTabela(listaRevistas);
        }

        private void MostrarTabela(ArrayList listaRevistas) {
            Console.WriteLine("{0,-5} |{1,-20} |{2,-5} |{3,-10} |{4,-20}|", "ID", "Coleção", "Ano","Edição","Caixa");
            Console.WriteLine("---------------------------------------------------------------------");
            foreach (Revista r in listaRevistas) {
                Console.WriteLine("{0,-5} |{1,-20} |{2,-5} |{3,-10} |{4,-20}|", r.id, r.colecao, r.ano, r.edicao, r.caixa.etiqueta);
                Console.WriteLine("---------------------------------------------------------------------");
            }
            Console.ReadLine();
        }

        public void Editar() {
            MostrarCabecalho("Cadastro de Revistas: ", "Editando uma revista...");
            Visualizar();
            Console.Write("\nDigite o ID da revista a ser editada: ");
            int id = int.Parse(Console.ReadLine());

            Revista revistaAtualizada = ObterRevista();
            

            repositorioRevista.Editar(id, revistaAtualizada);
            MostrarMensagem("Revista editada com sucesso!", ConsoleColor.Green);
        }
        public void Deletar() {
            MostrarCabecalho("Cadastro de Revistas: ", "Deletando uma revista...");
            Visualizar();
            Console.Write("\nDigite o ID da revista a ser deletada: ");
            int id = int.Parse(Console.ReadLine());

            repositorioRevista.Excluir(id);
            MostrarMensagem("Revista deletada com sucesso!", ConsoleColor.Green);
        }

        private Revista ObterRevista() {
            telaCaixa.Visualizar();
            Console.Write("\nDigite o ID da caixa em que a revista será guardada: ");
            int id = int.Parse(Console.ReadLine());
            Caixa caixa = repositorioCaixa.SelecionarPorId(id);
            Console.Write("Informe a coleção da revista: ");
            string colecao = Console.ReadLine();
            Console.Write("Informe a edição da revista: ");
            int edicao = int.Parse(Console.ReadLine());
            Console.Write("Informe o ano da revista: ");
            int ano = int.Parse(Console.ReadLine());

            Revista revista = new Revista(colecao, edicao, ano, caixa);

            return revista;

        }




    }
}
