using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falcon : Ship {


	// movement support
	const float speed = 10.0f;

	// Use this for initialization
	void Start () {
		base.Initialize ();

		laserCD.Duration = 0.1f;
	}

	// vertical motion and clamp to screen
	void FixedUpdate(){
		float vAxis = Input.GetAxis("Vertical");
		if (vAxis != 0)
		{
			Vector3 velocity = new Vector3(0, Mathf.Sign(vAxis) * speed, 0);
			Vector3 position = new Vector3();
			position = transform.position + velocity * Time.deltaTime;
			position.y = CalculateClampedY(position.y);
			rb2d.MovePosition(position);
		}
	}


	// Update is called once per frame
	void Update () {
		// Fire!
		if (Input.GetKeyDown ("space") && !laserCD.Running) {
			GameObject laser = ObjectPools.GetLaser ();
			laser.SetActive (true);
			laser.transform.position = transform.position + new Vector3(2*radius, 0,0);
			laser.GetComponent<Laser> ().StartMoving (20f);
			laserCD.Run();
		}
	}
	
}
