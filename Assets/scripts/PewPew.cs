using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PewPew : MonoBehaviour {
	Timer tieFighterSpawnTimer;
	// Use this for initialization
	void Awake(){
		ScreenUtils.Initialize ();
		ObjectPools.Initialize ();
		//LoadScene ();
		//HUD.Initialize ();

		EventManager.AddGameOverListener (HandleEndGame);
		tieFighterSpawnTimer = gameObject.AddComponent<Timer> ();
		tieFighterSpawnTimer.Duration = 1f;
		tieFighterSpawnTimer.AddTimerFinishedListener (SpawnTieFighter);
		tieFighterSpawnTimer.Run ();
	}

	void SpawnTieFighter(){
		GameObject tieFighter = ObjectPools.GetTieFighter ();
		tieFighter.SetActive(true);
		tieFighter.GetComponent<TieFighter> ().StartMoving ();
		tieFighterSpawnTimer.Duration = Random.Range (0.5f, 2f);
		tieFighterSpawnTimer.Run ();
	}

	void HandleEndGame(){
		
		foreach (GameObject tie in GameObject.FindGameObjectsWithTag ("tie")) {
			ObjectPools.ReturnTieToThePool (tie);
		}
		foreach (GameObject laser in GameObject.FindGameObjectsWithTag ("laser")) {
			ObjectPools.ReturnLaserToThePool (laser);
		};

		Destroy (GameObject.FindGameObjectWithTag ("hud"));
		foreach (GameObject laser in ObjectPools.laserPool) {
			Destroy (laser);
		}
		foreach (GameObject tieFighter in ObjectPools.tiePool) {
			Destroy (tieFighter);
		}
		ObjectPools.laserPool.Clear ();
		ObjectPools.tiePool.Clear ();
		Time.timeScale = 0;

		GameObject restartMenu = (GameObject)Instantiate (Resources.Load ("prefabs/Restart"));
		GameObject.FindGameObjectWithTag ("score").GetComponent<Text> ().text = "score = "+HUD.score.ToString();
	}

	
}
