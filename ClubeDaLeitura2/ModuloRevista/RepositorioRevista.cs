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
    public class RepositorioRevista
    {
        private ArrayList listaRevistas;

        public RepositorioRevista(ArrayList listaRevistas) {
            this.listaRevistas = listaRevistas;
        }

        int contadorRevista;
        public void Inserir(Revista revista) {
            contadorRevista++;
            revista.id = contadorRevista;
            listaRevistas.Add(revista);
        }

        public ArrayList SelecionarTodos() {
            return listaRevistas;
        }

        internal void Editar(int id, Revista revistaAtualizada) {

            Revista revistaSeleciona = SelecionarPorId(id);

            revistaSeleciona.colecao = revistaAtualizada.colecao;
            revistaSeleciona.ano = revistaAtualizada.ano;
            revistaSeleciona.edicao = revistaAtualizada.edicao;
            revistaSeleciona.caixa = revistaAtualizada.caixa;
        }

        public Revista SelecionarPorId(int id) {
            Revista revistaSelecionada = null;
            foreach (Revista r in listaRevistas) {
                if (r.id == id) {
                    revistaSelecionada = r;
                    break;
                }
            }

            return revistaSelecionada;
        }

        internal void Excluir(int id) {

            Revista revistaSelecionada = SelecionarPorId(id);
            listaRevistas.Remove(revistaSelecionada);

        }

        internal bool TemRevista(int id) {
            foreach (Revista r in listaRevistas) {
                if (r.caixa.id == id) {
                    return true;
                    break;
                }
            }
            return false;
        }
    }
}
