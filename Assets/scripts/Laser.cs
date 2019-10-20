using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Laser : MonoBehaviour {

	CapsuleCollider2D capCol2d;
	Rigidbody2D rb2d;
	Vector2 direction;
	LaserFireEvent laserFireEvent;
    DamageEvent damageFalconEvent;
	//GameOverEvent gameOverEvent;

	// Use this for initialization
	public void Initialize () {
		capCol2d = GetComponent<CapsuleCollider2D> ();
		rb2d = GetComponent<Rigidbody2D> ();
		direction = new Vector2 (1,0);
		laserFireEvent = new LaserFireEvent ();
        damageFalconEvent = new DamageEvent();
        //gameOverEvent = new GameOverEvent ();
        EventManager.AddLaserInvoker(this);
	}

	public void StopMoving(){
		rb2d.velocity = Vector2.zero;
	}
	

	public void StartMoving(float speed){
		rb2d.velocity = Vector2.zero;
		rb2d.AddForce (direction * speed, ForceMode2D.Impulse);
	}

	public void AddHudListener(UnityAction<int> listener){
		laserFireEvent.AddListener (listener);
	}

    public void AddDamageFalconListener(UnityAction<int> listener)
    {
        Debug.Log("lase reduce health");
        damageFalconEvent.AddListener(listener);
    }

//	public void AddGameOverListener(UnityAction listener){
//		gameOverEvent.AddListener (listener);
//	}

	void OnBecameInvisible(){
		ObjectPools.ReturnLaserToThePool (this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "tie") {
			ObjectPools.ReturnTieToThePool (col.gameObject);
			laserFireEvent.Invoke (10);
		} else if (col.gameObject.tag == "falcon") {
            Debug.Log("hi falcon");
            //Destroy (col.gameObject);
            damageFalconEvent.Invoke(1);
            //gameOverEvent.Invoke ();
		}
		ObjectPools.ReturnLaserToThePool (this.gameObject);
	}
}
