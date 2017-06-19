using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class Movimentos
    {
        private const int columnNumbers = 5;
        private const int rowNumbers = 4;
        private const int minimumX = -4;
        private const int maximumX = 4;
        private const int minimumY = -3;
        private const int maximumY = 3;
        private static int colunaAtual;
        private static int linhaAtual;
        private Vector3 personagemPosicao;//;
        private int linhaInicial;
        private int colunaInicial;

        public Movimentos(GameObject personagem, int linhaInicial, int colunaInicial)
        {
            personagemPosicao = personagem.transform.position;
            this.linhaInicial = linhaInicial;
            this.colunaInicial = colunaInicial;
            LinhaAtual = linhaInicial;
            ColunaAtual = colunaInicial;
        }

        public Movimentos(GameObject personagem) : this(personagem, PosicaoAleatoria(false), PosicaoAleatoria(true))
        {

        }

        private static int PosicaoAleatoria(bool isColuna)
        {
            int validNumber;
            if (isColuna)
                return new System.Random().Next(0, columnNumbers + 1);
            return new System.Random().Next(0, rowNumbers + 1);
        }
        //private static bool ValidatePosition(bool iscoluna, int validNumber)
        //{
        //    if (iscoluna)
        //        return validNumber % DeslocamentoColuna == 0;
        //    return validNumber % DeslocamentoLinha == 0;
        //}

        private static double DeslocamentoColuna
        {
            get
            {
                float intervalo = ((minimumX * -1) + maximumX + 2);
                double posicao = Math.Round(((double)intervalo / columnNumbers), 2); // +1 para contar o 0 }
                return posicao;
            }
        }
        private static double DeslocamentoLinha
        {
            get
            {
                float intervalo = ((minimumY * -1) + maximumY + 2);
                double posicao = Math.Round(((double)intervalo / rowNumbers), 2); // +1 para contar o 0 }
                return posicao;
            }
        }

        private int LinhaAtual
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
                personagemPosicao.y = (float)_deslocamentoLinha;
                linhaAtual = value;
            }
        }
        private int ColunaAtual
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
                personagemPosicao.x = (float)_deslocamentoColuna;
                colunaAtual = value;
            }
        }
        public Vector3 Subir()
        {
            if (LinhaAtual < rowNumbers)
                LinhaAtual++;
            return Posicao();

        }
        public Vector3 Descer()
        {
            if (LinhaAtual > 1)
                LinhaAtual--;
            return Posicao();
        }
        public Vector3 Direita()
        {
            if (ColunaAtual < columnNumbers)
                ColunaAtual++;
            return Posicao();
        }
        public Vector3 Esquerda()
        {
            if (ColunaAtual > 1)
                ColunaAtual--;
            return Posicao();
        }

        public Vector3 Posicao()
        {
            return personagemPosicao;
        }
    }
}
