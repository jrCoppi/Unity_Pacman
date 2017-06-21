using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Scripts;
using Assets.Scripts.Personagens;
using System.Threading;

public class Jogo : MonoBehaviour
{
    //private DetectLocation GPS;
    //private Acelerometro Acelerometro;

    // Use this for initialization

    private Pacman pacman;
    private Fantasma fantasma;
    private Comida comida;
    public static bool Pressed { get; set; }

    void Start()
    {
        Pressed = false;
        GameObject pacmanObject = FindObjectsOfType<GameObject>().First(x => x.name == "PacMan_1");
        GameObject fantasmaObject = FindObjectsOfType<GameObject>().First(x => x.name == "Fantasma");
        GameObject comidaObject = FindObjectsOfType<GameObject>().First(x => x.name == "comida");
        pacman = new Pacman(pacmanObject, 1, 3);
        fantasma = new Fantasma(fantasmaObject,3,2);
        comida= new Comida(comidaObject, 3, 4);
        
        //StartCoroutine(TesteMovimento());
    }

    public IEnumerator TesteMovimento()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(2);
            pacman.MoverEsquerda();
            yield return new WaitForSeconds(2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        DetectLocation.Instance.atualiza();
        float distancia = DetectLocation.Instance.distance;
        var direcao = Acelerometro.Instance.getDirecao();
        //Debug.Log(distancia);

        if (distancia > 0.00001f || Pressed)
        {
            fantasma.MoverBaixo();
            comida.MoverBaixo();
            Thread.Sleep(0500);
            Pressed = false;
        }
        else
        {
            switch (direcao)
            {
                case 1:
                    pacman.MoverEsquerda();
                    Thread.Sleep(100);
                    break;
                case 2:
                    pacman.MoverDireita();
                    Thread.Sleep(100);
                    break;
                default:
                    break;
            }
        }

        if (pacman.PacmanObject.IsColided(fantasma.GhostObject))
        {
            fantasma = new Fantasma(fantasma.GhostObject);
            pacman.Pontuacao += +5;
        }
        if (pacman.PacmanObject.IsColided(comida.FoodObject))
        {
            comida = new Comida(comida.FoodObject);
            pacman.Pontuacao -= 10;
        }
    }
}
