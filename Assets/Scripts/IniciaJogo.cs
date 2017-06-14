using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IniciaJogo : MonoBehaviour {

	public void NovoJogo()
	{
		Scene[] cenas = SceneManager.GetAllScenes();


		foreach (Scene cena in cenas)
		{
			if (cena.name == "cena_geral")
			{
				SceneManager.UnloadSceneAsync(cena);
			}
		}
		SceneManager.LoadSceneAsync("pacman");
	}
}
