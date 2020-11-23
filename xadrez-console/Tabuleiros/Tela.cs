using System;
using System.Collections.Generic;
using Tabuleiros;
using Xadrez;
namespace xadrez_console.Tabuleiros {
    class Tela {
        public static void ImprimirPartida(PartidaDeXadrez partida) {
            ImprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine($"Turno {partida.Turno}");
            if (!partida.Terminada) {
                if(partida.JogadorAtual == Cor.Preta) {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Aguardando jogada: {partida.JogadorAtual}");
                    Console.ForegroundColor = aux;
                }
                else {
                    Console.WriteLine($"Aguardando jogada: {partida.JogadorAtual}");
                }
                if (partida.Xeque) {
                    Console.WriteLine("XEQUE!");
                }
            }
            else {
                Console.WriteLine();
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine($"Vencedor: {partida.JogadorAtual}");
            }
        }
        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida) {
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=================");
            Console.WriteLine("Peças capturadas:");
            Console.ForegroundColor = aux;
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Pretas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=================");
            Console.ForegroundColor = aux;
        }
        public static void ImprimirConjunto(HashSet<Peca> conjunto) {
            Console.Write("[");
            foreach(Peca x in conjunto) {
                Console.Write($"{x} ");
            }
            Console.WriteLine("]");
        }
        public static void ImprimirTabuleiro(Tabuleiro tab) {
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=================");
            Console.WriteLine("    TABULEIRO");
            Console.ForegroundColor = aux;
            Console.WriteLine();
            for (int i= 0;i< tab.Linhas; i++){
                aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{8 - i} ");
                Console.ForegroundColor = aux;
                for (int j = 0; j < tab.Colunas; j++) {
                    ImprimirPeca(tab.Peca(i, j));
                }
                Console.WriteLine();
            }
            aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  a b c d e f g h");
            Console.ForegroundColor = aux;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("=================");
            Console.ForegroundColor = aux;
        }
        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis) {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            for (int i = 0; i < tab.Linhas; i++) {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < tab.Colunas; j++) {
                    if(posicoesPossiveis[i, j]) {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPeca(tab.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }
        public static PosicaoXadrez LerPosicaoXadrez(int determina) {
            char coluna = ' ';
            int linha = 0;
            while (true){
                string s = Console.ReadLine();
                if (s.Length != 2 || (!s[1].Equals('1') && !s[1].Equals('2') && !s[1].Equals('3') && !s[1].Equals('4') && !s[1].Equals('5') && !s[1].Equals('6') && !s[1].Equals('7') && !s[1].Equals('8'))){
                    Console.WriteLine("Movimento inválido");
                    Console.WriteLine();
                    if (determina == 0){
                        Console.Write("Origem: ");
                    }
                    else{
                        Console.Write("Destino: ");
                    }
                    continue;
                }
                coluna = s[0];
                linha = int.Parse(s[1].ToString());
                if ((coluna.Equals('a')||coluna.Equals('b')||coluna.Equals('c')||coluna.Equals('d')||coluna.Equals('e')||coluna.Equals('f')||coluna.Equals('g')||coluna.Equals('h')) && (linha>=1 && linha<=8)){
                    break;
                }
                else{
                    Console.WriteLine("Movimento inválido");
                    Console.WriteLine();
                    if (determina == 0){
                        Console.Write("Origem: ");
                    }
                    else{
                        Console.Write("Destino: ");
                    }
                }
            }
            return new PosicaoXadrez(coluna, linha);
        }
        public static void ImprimirPeca(Peca peca) {
            if (peca == null) {
                Console.Write("-");
            }
            else {
                if (peca.Cor == Cor.Branca) {
                    Console.Write(peca);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
            }
            Console.Write(" ");
        }
    }
}
