using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Personagens
{
    class Fantasma
    {
        private GameObject ghostObject;
        private Movimentos movimentos;
        public Fantasma(GameObject ghostObject)
        {
            movimentos = new Movimentos(ghostObject);
            this.ghostObject = ghostObject;
            this.ghostObject.transform.position = movimentos.Posicao();
        }
    }
}
