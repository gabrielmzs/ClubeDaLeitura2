using ClubeDaLeitura2.ModuloCaixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura2.ModuloRevista
{
    public class Revista
    {
        public string colecao;
        public int edicao;
        public int ano;
        public int id;
        public Caixa caixa;

        public Revista(string colecao, int edicao, int ano, Caixa caixa) {
            this.colecao = colecao;
            this.edicao = edicao;
            this.ano = ano;
            this.caixa = caixa;
        }
    }
}
