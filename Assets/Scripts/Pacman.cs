using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Scripts;

public class Pacman : MonoBehaviour
{
    //private DetectLocation GPS;
    //private Acelerometro Acelerometro;

    // Use this for initialization


    void Start()
    {
        GameObject pacman = FindObjectsOfType<GameObject>().First(x => x.name == "PacMan_1");
        var l = Screen.width / 4; //256
        var sx = Screen.height / 4;//192
        var teste = new Vector3(0, -3);
        pacman.transform.position = teste;
        Movimentos.Descer();
        Movimentos.Descer();
        Movimentos.Descer();
        Movimentos.Descer();
        pacman.transform.position = Movimentos.PosicaoPacman();
        //StartCoroutine(CalibrarMovimentos());
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
