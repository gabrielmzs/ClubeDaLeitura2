using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura2.ModuloAmigo
{
    public class Amigo
    {
        public string nome;
        public string nomeResponsavel;
        public int id;
        public string endereco;
        public string telefone;

        public Amigo(string nome, string nomeResponsavel, string endereco, string telefone) {
            this.nome = nome;
            this.nomeResponsavel = nomeResponsavel;
            this.endereco = endereco;
            this.telefone = telefone;
        }
    }

    
}
