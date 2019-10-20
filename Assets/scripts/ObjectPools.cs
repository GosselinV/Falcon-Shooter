using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

static public class ObjectPools 
{

	static GameObject prefabLaser;
	static GameObject prefabTieFighter;
	static public List<GameObject> laserPool;
	static public List<GameObject> tiePool;
	const int laserPoolSize = 20;
	const int tiePoolsize = 10;

	/// <summary>
	/// Initialize this instance.
	/// </summary>
	public static void Initialize(){
		prefabLaser = Resources.Load<GameObject> ("prefabs/laser");
		prefabTieFighter = Resources.Load<GameObject> ("prefabs/tie");

		laserPool = new List<GameObject> (laserPoolSize);
		for (int i = 0; i < laserPool.Capacity; i++) {
			laserPool.Add (GetNewLaser ());
		}
		tiePool = new List<GameObject> (tiePoolsize);
		for (int i = 0; i < tiePool.Capacity; i++) {
			tiePool.Add (GetNewTieFighter ());
		}
	}
		
	/// <summary>
	/// Gets the laser.
	/// </summary>
	/// <returns>The laser.</returns>
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

	/// <summary>
	/// Returns the laser to the pool.
	/// </summary>
	/// <param name="laser">Laser.</param>
	static public void ReturnLaserToThePool(GameObject laser){
		laser.GetComponent<Laser> ().StopMoving ();
		laser.SetActive (false);
		laserPool.Add (laser);
	}

	/// <summary>
	/// Gets the new laser.
	/// </summary>
	/// <returns>The new laser.</returns>
	static public GameObject GetNewLaser(){
		GameObject laser = GameObject.Instantiate (prefabLaser);
		laser.GetComponent<Laser> ().Initialize ();
		laser.SetActive (false);
		GameObject.DontDestroyOnLoad (laser);
		return laser;
	}

	/// <summary>
	/// Gets the tie fighter.
	/// </summary>
	/// <returns>The tie fighter.</returns>
	static public GameObject GetTieFighter(){
		if (tiePool.Count > 0) {
			GameObject tieFighter = tiePool [tiePool.Count - 1];
			tiePool.RemoveAt (tiePool.Count - 1);
			return tieFighter;
		} else {
			Debug.Log ("Increasing Tie Fighter pool capacity");
			tiePool.Capacity++;
			return GetNewTieFighter ();
		}
	}

	/// <summary>
	/// Returns the tie to the pool.
	/// </summary>
	/// <param name="tieFighter">Tie fighter.</param>
	static public void ReturnTieToThePool(GameObject tieFighter){
		tieFighter.GetComponent<TieFighter> ().StopMoving ();
		tieFighter.SetActive (false);
		tiePool.Add (tieFighter);
	}

	/// <summary>
	/// Gets the new tie fighter.
	/// </summary>
	/// <returns>The new tie fighter.</returns>
	static public GameObject GetNewTieFighter(){
		GameObject tieFighter = GameObject.Instantiate (prefabTieFighter);
		tieFighter.GetComponent<TieFighter> ().Initialize ();
		tieFighter.SetActive (false);
		GameObject.DontDestroyOnLoad (tieFighter);
		return tieFighter;
	}

}
