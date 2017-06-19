using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Personagens
{
    class Comida
    {
        private GameObject foodObject;
        private Movimentos movimentos;
        public Comida(GameObject foodObject)
        {
            movimentos = new Movimentos(foodObject);
            this.foodObject = foodObject;
            this.foodObject.transform.position = movimentos.Posicao();
        }
    }
}
