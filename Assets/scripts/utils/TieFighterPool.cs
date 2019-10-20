using UnityEngine;
using System.Collections;
using System.Collections.Generic;

static public class TieFighterPool
{
	static GameObject prefabTieFighter;
	static List<GameObject> pool;
	const int poolsize = 10;

	public static void Initialize(){
		prefabTieFighter = Resources.Load<GameObject> ("prefabs/tie");
		pool = new List<GameObject> (poolsize);
		for (int i = 0; i < pool.Capacity; i++) {
			pool.Add (GetNewTieFighter ());
		}
	}


	static public GameObject GetTieFighter(){
		if (pool.Count > 0) {
			GameObject tieFighter = pool [pool.Count - 1];
			pool.RemoveAt (pool.Count - 1);
			return tieFighter;
		} else {
			Debug.Log ("Increasing Tie Fighter pool capacity");
			pool.Capacity++;
			return GetNewTieFighter ();
		}
	}

	static public void ReturnToThePool(GameObject tieFighter){
		tieFighter.SetActive (false);
		tieFighter.GetComponent<TieFighter> ().StopMoving ();
		pool.Add (tieFighter);
	}

	static public GameObject GetNewTieFighter(){
		GameObject tieFighter = GameObject.Instantiate (prefabTieFighter);
		tieFighter.GetComponent<TieFighter> ().Initialize ();
		tieFighter.SetActive (false);
		GameObject.DontDestroyOnLoad (tieFighter);
		return tieFighter;
	}
}

