using ClubeDaLeitura2.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura2.ModuloAmigo {
    public class TelaAmigo:Tela {
        RepositorioAmigo repositorioAmigo;

        public TelaAmigo(RepositorioAmigo repositorioAmigo) {
            this.repositorioAmigo = repositorioAmigo;
        }

        public string ApresentarMenu() {
            Console.Clear();
            Console.WriteLine("1 - Inserir Amigo");
            Console.WriteLine("2 - Visualizar Amigos");
            Console.WriteLine("3 - Editar Amigo");
            Console.WriteLine("4 - Deletar Amigo");
            Console.WriteLine("0 - Voltar");
            string opcao = Console.ReadLine();
            return opcao;
        }

        public void Deletar() {
            MostrarCabecalho("Cadastro de Amigos: ", "Deletando um amigo...");
            Visualizar();
            Console.Write("\nDigite o ID do amigo a ser deletado: ");
            int id = int.Parse(Console.ReadLine());

            repositorioAmigo.Excluir(id);
            MostrarMensagem("Amigo deletado com sucesso!", ConsoleColor.Green);
        }

        public void Editar() {
            MostrarCabecalho("Cadastro de Amigos: ", "Editando um amigo...");
            Visualizar();
            Console.Write("\nDigite o ID do amigo a ser editado: ");
            int id = int.Parse(Console.ReadLine());

            Amigo amigoAtualizado = ObterAmigo();

            repositorioAmigo.Editar(id, amigoAtualizado);
            MostrarMensagem("Amigo editado com sucesso!", ConsoleColor.Green);
        }

        public void Inserir() {
            MostrarCabecalho("Cadastro de Amigos: ", "Inserindo um novo amigo...");
            Amigo amigo = ObterAmigo();
            repositorioAmigo.Inserir(amigo);
            MostrarMensagem("Amigo cadastrado com sucesso!", ConsoleColor.Green);
        }
        public void Visualizar() {
            Console.WriteLine("Amigos Cadastrados: \n");

            ArrayList listaAmigos = repositorioAmigo.SelecionarTodos();
            if (listaAmigos.Count == 0) {
                MostrarMensagem("Não há amigos cadastrados!", ConsoleColor.DarkYellow);
                return;
            }
            MostrarTabela(listaAmigos);
        }

        private void MostrarTabela(ArrayList listaAmigos) {
            Console.WriteLine("{0,-5}|{1,-15}|{2,-15}|{3,-15}|{4,-30}|", "ID", "Amigo", "Responsável", "Telefone", "Endereço");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            foreach (Amigo a in listaAmigos) {
                Console.WriteLine("{0,-5}|{1,-15}|{2,-15}|{3,-15}|{4,-30}|", a.id, a.nome, a.nomeResponsavel, a.telefone, a.endereco);
                Console.WriteLine("-------------------------------------------------------------------------------------");
            }
            Console.ReadLine();
        }

        private Amigo ObterAmigo() {

            Console.Write("Informe o nome do amigo: ");
            string nome = Console.ReadLine();
            Console.Write("Informe o nome do responsável pelo amigo: ");
            string nomeResponsavel = Console.ReadLine();
            Console.Write("Informe o endereço do amigo: ");
            string endereco = Console.ReadLine();
            Console.Write("Informe o telefone do amigo: ");
            string telefone = Console.ReadLine();

            Amigo amigo = new Amigo(nome, nomeResponsavel, endereco, telefone);

            return amigo;

        }

    }
}


