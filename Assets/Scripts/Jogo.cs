﻿using System.Collections;
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
    private Comida comida;

    void Start()
    {
        GameObject pacmanObject = FindObjectsOfType<GameObject>().First(x => x.name == "PacMan_1");
        GameObject fantasmaObject = FindObjectsOfType<GameObject>().First(x => x.name == "Fantasma");
        GameObject comidaObject = FindObjectsOfType<GameObject>().First(x => x.name == "comida");
        pacman = new Pacman(pacmanObject, 1, 3);
        fantasma = new Fantasma(fantasmaObject, 1, 1);
        comida = new Comida(comidaObject, 1, 5);
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
        //DetectLocation.Instance.atualiza();
        //float distancia = DetectLocation.Instance.distance;
        var direcao = Acelerometro.Instance.getDirecao();
        if (direcao == 1)
            pacman.MoverEsquerda();
        else if (direcao == 2)
            pacman.MoverDireita();
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
