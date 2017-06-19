using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    static class Movimentos
    {
        private const int columnNumbers = 5;
        private const int rowNumbers = 4;
        private const int minimumX = -4;
        private const int maximumX = 4;
        private const int minimumY = -3;
        private const int maximumY = 3;
        private static int colunaAtual = 3;
        private static int linhaAtual = 1;
        private static Vector3 pacmanPosition = new Vector3(0,minimumY);
        private static Vector3 ghostPosition = new Vector3(0, minimumY);
        public static double DeslocamentoColuna
        {
            get
            {
                float intervalo = ((minimumX * -1) + maximumX + 2);
                double posicao = Math.Round(((double)intervalo / columnNumbers), 2); // +1 para contar o 0 }
                return posicao;
            }
        }
        public static double DeslocamentoLinha
        {
            get
            {
                float intervalo = ((minimumY * -1) + maximumY + 2);
                double posicao = Math.Round(((double)intervalo / rowNumbers), 2); // +1 para contar o 0 }
                return posicao;
            }
        }

        private static int LinhaAtual
        {
            get { return linhaAtual; }
            set
            {
                var linha = 1;
                double _deslocamentoLinha = minimumY;
                while (linha < value)
                {
                    _deslocamentoLinha += DeslocamentoLinha;
                    linha++;
                }
                pacmanPosition.y = (float)_deslocamentoLinha;
                linhaAtual = value;
            }
        }
        private static int ColunaAtual
        {
            get { return colunaAtual; }
            set
            {
                var coluna = 1;
                double _deslocamentoColuna = minimumX;
                while (coluna < value)
                {
                    _deslocamentoColuna += DeslocamentoColuna;
                    coluna++;
                }
                pacmanPosition.x = (float)_deslocamentoColuna;
                colunaAtual = value;
            }
        }
        public static Vector3 Subir()
        {
            if (LinhaAtual < rowNumbers)
                LinhaAtual++;
            return PosicaoPacman();

        }
        public static Vector3 Descer()
        {
            if (LinhaAtual > 1)
                LinhaAtual--;
            return PosicaoPacman();
        }
        public static Vector3 Direita()
        {
            if (ColunaAtual < columnNumbers)
                ColunaAtual++;
            return PosicaoPacman();
        }
        public static Vector3 Esquerda()
        {
            if (ColunaAtual > 1)
                ColunaAtual--;
            return PosicaoPacman();
        }

        public static Vector3 PosicaoPacman()
        {
            return pacmanPosition;
        }
    }
}
