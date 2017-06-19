using UnityEngine;

namespace Assets.Scripts.Personagens
{
    class Pacman
    {
        private GameObject pacmanObject;
        private Movimentos movimentos;
        private int linhaInicial;
        private int colunaInicial;

        public Pacman(GameObject pacmanObject, int linhaInicial, int colunaInicial)
        {
            movimentos = new Movimentos(pacmanObject, linhaInicial, colunaInicial);
            this.linhaInicial = linhaInicial;
            this.colunaInicial = colunaInicial;
            this.pacmanObject = pacmanObject;
            this.pacmanObject.transform.position = movimentos.Posicao();
        }
    }
}
