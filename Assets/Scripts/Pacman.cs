using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman : MonoBehaviour {
	//private DetectLocation GPS;
	//private Acelerometro Acelerometro;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		DetectLocation.Instance.atualiza();
		float distancia = DetectLocation.Instance.distance;
		//Acelerometro.Instance.atualiza();
		transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);
	}
}
