using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public static class ExtensionMethods
    {
        public static bool IsColided(this GameObject gameObjectA, GameObject gameObjectB)
        {
            return gameObjectA.transform.position.x == gameObjectB.transform.position.x &&
                   gameObjectA.transform.position.y == gameObjectB.transform.position.y;
        }
    }
}
