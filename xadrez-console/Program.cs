using System;
using Tabuleiros;
using xadrez_console.Tabuleiros;
using Xadrez;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            PosicaoXadrez pos = new PosicaoXadrez('a', 1);
            Console.WriteLine(pos);
            Console.WriteLine(pos.ToPosicao());
            /*try {
                Tabuleiro tab = new Tabuleiro(8, 8);
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
                tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(2, 4));
                Tela.ImprimirTabuleiro(tab);
                Console.WriteLine();
            }
            catch(TabuleiroException e) {
                Console.WriteLine(e);
            }*/
        }
    }
}
