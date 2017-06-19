using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Personagens
{
    class Comida
    {
        public GameObject FoodObject { get; private set; }
        private Movimentos movimentos;
        public Comida(GameObject foodObject)
        {
            movimentos = new Movimentos(foodObject);
            FoodObject = foodObject;
            FoodObject.transform.position = movimentos.Posicao();
        }

        public Comida(GameObject foodObject, int linha, int coluna)
        {
            movimentos = new Movimentos(foodObject, linha, coluna);
            this.FoodObject = foodObject;
            this.FoodObject.transform.position = movimentos.Posicao();
        }
    }
}
