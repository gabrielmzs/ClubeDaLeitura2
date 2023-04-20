using ClubeDaLeitura2.ModuloCaixa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura2.ModuloAmigo
{
    public class RepositorioAmigo
    {
        private ArrayList listaAmigos;

        public RepositorioAmigo(ArrayList listaAmigos) {
            this.listaAmigos = listaAmigos;
        }

        int contadorAmigos = 0;
        public void Inserir(Amigo amigo) {

            contadorAmigos++;
            amigo.id = contadorAmigos;
            listaAmigos.Add(amigo);
        }

        public ArrayList SelecionarTodos() {
            return listaAmigos;
        }

        internal void Editar(int id, Amigo amigoAtualizado) {
            Amigo amigoSelecionado = SelecionarPorId(id);

            amigoSelecionado.nome= amigoAtualizado.nome;
            amigoSelecionado.nomeResponsavel = amigoAtualizado.nomeResponsavel;
            amigoSelecionado.telefone = amigoAtualizado.telefone;
            amigoSelecionado.endereco = amigoAtualizado.endereco;

        }

        public Amigo SelecionarPorId(int id) {
            Amigo amigoSelecionado = null;
            foreach (Amigo a in listaAmigos) {
                if (a.id == id) {
                    amigoSelecionado = a;
                    break;
                }
            }
            return amigoSelecionado;
        }

        internal void Excluir(int id) {

            Amigo amigoSelecionado = SelecionarPorId(id);
            listaAmigos.Remove(amigoSelecionado);

        }
    }
}
