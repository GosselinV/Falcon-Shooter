using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TieFighter : Ship {

	//move support
	Timer yMoveTimer;
	float xSpeed = 5f;
	GameOverEvent gameOverEvent;


	// Use this for initialization
	public void Initialize () {
		
		base.Initialize ();

		// Event system
		gameOverEvent = new GameOverEvent ();
		EventManager.AddTieInvoker (this);

		//attack
		laserCD.Duration = 0.1f;
		laserCD.AddTimerFinishedListener(LaserFire);
	}

	//attack Timer Finished Event
	// Fire laser + reset timer duration
	void LaserFire(){
		GameObject laser = ObjectPools.GetLaser ();
		laser.SetActive (true);
		laser.transform.position = transform.position - new Vector3(2*radius, 0,0);
		laser.GetComponent<Laser> ().StartMoving (-20f);
		laserCD.Duration = Random.Range (0.1f, 0.5f);
		laserCD.Run ();
	}

	/// <summary>
	/// Adds the game over event listener.
	/// </summary>
	/// <param name="listener">Listener.</param>
	public void AddGameOverEventListener(UnityAction listener){
		gameOverEvent.AddListener (listener);
	}

	/// <summary>
	/// Return to object pool
	/// </summary>
	void OnBecameInvisible(){
		ObjectPools.ReturnTieToThePool(this.gameObject);
	}

	/// <summary>
	/// Stops motion.
	/// </summary>
	public void StopMoving(){
		rb2d.velocity = Vector2.zero;
	}

	/// <summary>
	/// Set pos.
	/// Reset velocity to zero (occasional bug with object pool).
	/// Start firing.
	/// </summary>
	public void StartMoving(){
		// Initial pos
		gameObject.transform.position = new Vector3(
			ScreenUtils.ScreenRight - radius, 
			Random.Range(ScreenUtils.ScreenBottom + radius, ScreenUtils.ScreenTop - radius),
			0);

		// xmotion
		rb2d.velocity = Vector2.zero;
		xSpeed = Random.Range(5f,10f);
		gameObject.GetComponent<TieFighter>().rb2d.AddForce(new Vector2(-1,0) * xSpeed, ForceMode2D.Impulse);

		//Fire
		laserCD.Run();
	}

	/// <summary>
	/// Collision with player
	/// </summary>
	/// <param name="col">Col.</param>
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "falcon") {
			Destroy (col.gameObject);
			gameOverEvent.Invoke ();
		}
	}
}
