using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

static public class EventManager
{
	static UnityAction<int> hudListener;
    static UnityAction<int> damageFalconListener;
	static UnityAction gameOverlistener;
	static List<Laser> laserInvokers  = new List<Laser>();
	static List<TieFighter> tieInvokers = new List<TieFighter> ();
    static Falcon falconInvoker;

    static public void AddFalconInvoker(Falcon falcon) {
        falconInvoker = falcon;
        if (gameOverlistener != null)
        {
            falconInvoker.AddGameOverEventListner(gameOverlistener);
        }
    }

    static public void AddLaserInvoker(Laser invoker){
		laserInvokers.Add (invoker);
        Debug.Log("New laser invoker");
        if (hudListener != null) {

			invoker.AddHudListener (hudListener);
		}
		//if (gameOverlistener != null) {
		//	invoker.AddGameOverListener (gameOverlistener);
		//}
        if (damageFalconListener != null)
        {
            Debug.Log("damageFalconListener != null");
            invoker.AddDamageFalconListener(damageFalconListener);
        } else
        {
            Debug.Log("damageFalconListener == null");
        }
	}

	static public void AddTieInvoker(TieFighter invoker){
		tieInvokers.Add (invoker);
		if (damageFalconListener != null) {
			invoker.AddDamageFalconEventListener (damageFalconListener);
		}
	}

	static public void AddHudListener(UnityAction<int> listener){
        hudListener = listener;
		foreach (Laser invoker in laserInvokers) {
			invoker.AddHudListener (listener);
		}
	}

    static public void AddDamageFalconListener(UnityAction<int> listener)
    {

        damageFalconListener = listener;
        Debug.Log(laserInvokers.Count);
        foreach (Laser invoker in laserInvokers)
        {
            Debug.Log("AddaDamageFalconListener");
            invoker.AddDamageFalconListener(listener);
        }
        foreach (TieFighter invoker in tieInvokers)
        {
            invoker.AddDamageFalconEventListener(listener);

        }
    }

    static public void AddGameOverListener(UnityAction listener){
        gameOverlistener = listener;
        if (falconInvoker != null)
        {
            falconInvoker.AddGameOverEventListner(listener);
        }
	}
}

