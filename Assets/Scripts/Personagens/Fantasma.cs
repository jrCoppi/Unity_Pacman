using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Personagens
{
    class Fantasma
    {
        public GameObject GhostObject { get; private set; }

        private Movimentos movimentos;
        public Fantasma(GameObject ghostObject)
        {
            movimentos = new Movimentos(ghostObject);
            this.GhostObject = ghostObject;
            this.GhostObject.transform.position = movimentos.Posicao();
        }
        public Fantasma(GameObject ghostObject, int linha, int coluna)
        {
            movimentos = new Movimentos(ghostObject, linha, coluna);
            this.GhostObject = ghostObject;
            this.GhostObject.transform.position = movimentos.Posicao();
        }
    }
}
