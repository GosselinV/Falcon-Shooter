using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class LaserPool {

	static GameObject prefabLaser;
	static List<GameObject> laserPool;
	static List<GameObject> tiePool;
	const int poolsize = 10;

	public static void Initialize(){
		prefabLaser = Resources.Load<GameObject> ("prefabs/laser");
		laserPool = new List<GameObject> (poolsize);
		for (int i = 0; i < laserPool.Capacity; i++) {
			laserPool.Add (GetNewLaser ());
		}
	}


	static public GameObject GetLaser(){
		if (laserPool.Count > 0) {
			GameObject laser = laserPool [laserPool.Count - 1];
			laserPool.RemoveAt (laserPool.Count - 1);
			return laser;
		} else {
			Debug.Log ("Increasing Laser pool capacity");
			laserPool.Capacity++;
			return GetNewLaser ();
		}
	}

	static public void ReturnToThePool(GameObject laser){
		laser.SetActive (false);
		laser.GetComponent<Laser> ().StopMoving ();
		laserPool.Add (laser);
	}

	static public GameObject GetNewLaser(){
		GameObject laser = GameObject.Instantiate (prefabLaser);
		laser.GetComponent<Laser> ().Initialize ();
		laser.SetActive (false);
		GameObject.DontDestroyOnLoad (laser);
		return laser;
	}
}
