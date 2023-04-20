using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura2.ModuloCaixa {
    public class RepositorioCaixa {

        
        ArrayList listaCaixas;


        public RepositorioCaixa(ArrayList listaCaixas) {
            this.listaCaixas = listaCaixas;
        }

        int contadorCaixas = 0;
        public void Inserir(Caixa caixa) {

            contadorCaixas++;
            caixa.id = contadorCaixas;
            listaCaixas.Add(caixa);
        }

        public ArrayList SelecionarTodos() {
            return listaCaixas;
        }

        internal void Editar(int id, Caixa caixaAtualizada) {

            Caixa caixaSelecionada = SelecionarPorId(id);
            caixaSelecionada.cor = caixaAtualizada.cor;
            caixaSelecionada.etiqueta = caixaAtualizada.etiqueta;
        }

        internal void Excluir(int id) {

            Caixa caixaSelecionada = SelecionarPorId(id);
            listaCaixas.Remove(caixaSelecionada);
        }

        public Caixa SelecionarPorId(int id) {
            Caixa caixaSelecionada = null;
            foreach (Caixa c in listaCaixas) {
                if (c.id == id) {
                    caixaSelecionada = c;
                    break;
                }
            }

            return caixaSelecionada;
        }

        
    }
}
