using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Scripts;
using Assets.Scripts.Personagens;

public class Jogo : MonoBehaviour
{
    //private DetectLocation GPS;
    //private Acelerometro Acelerometro;

    // Use this for initialization

    private Pacman pacman;
    private Fantasma fantasma;

    void Start()
    {
        GameObject pacmanObject = FindObjectsOfType<GameObject>().First(x => x.name == "PacMan_1");
        GameObject fantasmaObject = FindObjectsOfType<GameObject>().First(x => x.name == "Fantasma");
        pacman = new Pacman(pacmanObject, 1, 3);
        fantasma = new Fantasma(fantasmaObject);
    }

    // Update is called once per frame
    void Update()
    {
        DetectLocation.Instance.atualiza();
        float distancia = DetectLocation.Instance.distance;
        Acelerometro.Instance.atualiza();
        transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);
    }
}
