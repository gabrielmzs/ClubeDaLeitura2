using ClubeDaLeitura2.ModuloRevista;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura2.ModuloEmprestimo {
    public class RepositorioEmprestimo {

        private ArrayList listaEmprestimos;

        public RepositorioEmprestimo(ArrayList listaEmprestimos) {
            this.listaEmprestimos = listaEmprestimos;
        }

        int contadorEmprestimos;
        public void Inserir(Emprestimo emprestimo) {
            contadorEmprestimos++;
            emprestimo.id = contadorEmprestimos;
            emprestimo.status = "Em Aberto";
            listaEmprestimos.Add(emprestimo);
        }

        public ArrayList SelecionarTodos() {
            return listaEmprestimos;
        }

        internal void Editar(int id, Emprestimo emprestimoAtualizado) {
            Emprestimo emprestimoSelecionado = SelecionarPorId(id);

            emprestimoSelecionado.amigo = emprestimoAtualizado.amigo;
            emprestimoSelecionado.revista = emprestimoAtualizado.revista;
            emprestimoSelecionado.dataSaida = emprestimoAtualizado.dataSaida;

        }

        public ArrayList SelecionarAbertos() {
            ArrayList listaAbertos = new ArrayList();
            foreach (Emprestimo e in listaEmprestimos) {
                if (e.status == "Em Aberto") {
                    listaAbertos.Add(e);
                    
                }
            }
            return listaAbertos;
        }

        public Emprestimo SelecionarPorId(int id) {
            Emprestimo emprestimoSelecionado = null;
            foreach (Emprestimo  e in listaEmprestimos) {
                if (e.id == id) {
                    emprestimoSelecionado = e;
                    break;
                }
            }
            return emprestimoSelecionado;
        }

        internal void Excluir(int id) {

            Emprestimo emprestimoSelecionado = SelecionarPorId(id);
            listaEmprestimos.Remove(emprestimoSelecionado);

        }
        internal void Encerrar(int id) {
            Emprestimo emprestimoSelecionado = SelecionarPorId(id);

            emprestimoSelecionado.status = "Encerrado";

        }

        public ArrayList SelecionarEmprestimosMes(int mes, int ano) {
            ArrayList listaEmprestimosMes = new ArrayList();
            foreach (Emprestimo e in listaEmprestimos) {
                if (mes == e.dataSaida.Month && ano == e.dataSaida.Year ) {
                    listaEmprestimosMes.Add(e);
                }
            }
            return listaEmprestimosMes;
        }
    }
}
