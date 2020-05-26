using System;
using Tabuleiros;
using xadrez_console.Tabuleiros;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            Tabuleiro tab = new Tabuleiro(8, 8);
            Tela.ImprimirTabuleiro(tab);
            Console.WriteLine();
        }
    }
}
