using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Ship : MonoBehaviour
{
	// Physics support
	protected Rigidbody2D rb2d;
	protected CircleCollider2D ccol2d;
	protected float radius;
	protected LaserFireEvent laserFireEvent;

	// 
	protected Timer laserCD;

	// Use this for initialization
	protected void Initialize ()
	{
		laserFireEvent = new LaserFireEvent ();
		rb2d = GetComponent<Rigidbody2D> ();
		ccol2d = GetComponent<CircleCollider2D> ();
		radius = ccol2d.radius* transform.localScale.x;
		laserCD = gameObject.AddComponent<Timer> ();

	}

	// clamp to screen
	protected float CalculateClampedY(float y)
	{
		if (y + radius >= ScreenUtils.ScreenTop)
		{
			return ScreenUtils.ScreenTop - radius;
		}
		else if (y - radius <= ScreenUtils.ScreenBottom)
		{
			return ScreenUtils.ScreenBottom+ radius;
		}
		else
		{
			return y;
		}
	}

}

