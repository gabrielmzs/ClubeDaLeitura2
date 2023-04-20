using ClubeDaLeitura2.ModuloAmigo;
using ClubeDaLeitura2.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura2.ModuloEmprestimo
{
    public class Emprestimo
    {
        public DateTime dataSaida;
        public string dataDevolucao;
        public Revista revista;
        public Amigo amigo;
        public int id;
        public string status;

        public Emprestimo(DateTime dataSaida, Revista revista, Amigo amigo) {
            this.dataSaida = dataSaida;
            this.revista = revista;
            this.amigo = amigo;
        }
    }
}
