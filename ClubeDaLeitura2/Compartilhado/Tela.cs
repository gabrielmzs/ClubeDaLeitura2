using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura2.Compartilhado {
    public class Tela {
        public void MostrarCabecalho(string titulo, string subtitulo) {

            Console.Clear();
            Console.WriteLine(titulo);
            Console.WriteLine(subtitulo);
            Console.WriteLine();
        }
        public void MostrarMensagem(string mensagem, ConsoleColor cor) {
            Console.ForegroundColor = cor;
            Console.WriteLine();
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
