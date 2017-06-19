using UnityEngine;

namespace Assets.Scripts.Personagens
{
    class Pacman
    {
        public GameObject PacmanObject { get; private set; }
        public int Pontuacao { get; internal set; }

        private Movimentos movimentos;
        private int linhaInicial;
        private int colunaInicial;

        public Pacman(GameObject pacmanObject, int linhaInicial, int colunaInicial)
        {
            movimentos = new Movimentos(pacmanObject, linhaInicial, colunaInicial);
            this.linhaInicial = linhaInicial;
            this.colunaInicial = colunaInicial;
            PacmanObject = pacmanObject;
            PacmanObject.transform.position = movimentos.Posicao();
        }

        public void MoverEsquerda()
        {
            PacmanObject.transform.position = movimentos.Esquerda();
        }
        public void MoverDireita()
        {
            PacmanObject.transform.position = movimentos.Direita();
        }

    }
}
