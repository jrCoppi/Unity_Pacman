using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acelerometro : MonoBehaviour {

	private double valorMarcador = 0.30;

	private static Acelerometro acelerometroInicial;
	public static Acelerometro Instance
	{
		get
		{
			if (acelerometroInicial == null)
				acelerometroInicial = new Acelerometro();
			return (acelerometroInicial);
		}
	}

	private Acelerometro()
	{

	}

	//Retorna a direção atual
	public int getDirecao () {
		int direcao = 0;
		float aceleracao = Input.acceleration.x;

		if (aceleracao > 0.30)
		{
			//Esquerda
			direcao = 1;
		}

		if (aceleracao < -0.30)
		{
			//Direita
			direcao = 2;
		}

		return direcao;
	}
}
