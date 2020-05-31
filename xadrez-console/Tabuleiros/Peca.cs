﻿namespace Tabuleiros {
     abstract class Peca {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QntMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor) {
            Posicao = null;
            Cor = cor;
            Tab = tab;
            QntMovimentos = 0;
        }

        public void IncrementarQntMovimentos() {
            QntMovimentos++;
        }
        public abstract bool[,] MovimentosPossiveis() {

        }
    }
}
