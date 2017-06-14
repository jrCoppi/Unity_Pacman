using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acelerometro : MonoBehaviour {

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

	// Update is called once per frame
	public void atualiza () {
		
	}
}
