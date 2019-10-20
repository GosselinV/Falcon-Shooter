using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

	// Use this for initialization

	public void HandleRestartButton(){
		Time.timeScale = 1;
		SceneManager.LoadScene ("scene0");
//        GameObject.FindGameObjectWithTag("startButton").GetComponent<StartButton>().HandleStartButton();
//		Destroy (gameObject);

    }

}
