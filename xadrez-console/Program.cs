using System;
using Tabuleiros;
using xadrez_console.Tabuleiros;
using Xadrez;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            try {
                PartidaDeXadrez partida = new PartidaDeXadrez();
                Tela.ImprimirTabuleiro(partida.Tab);
                Console.WriteLine();
            }
            catch(TabuleiroException e) {
                Console.WriteLine(e);
            }
        }
    }
}
