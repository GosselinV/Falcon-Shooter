using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

static public class EventManager
{
	static UnityAction<int> intListener;
	static UnityAction listener;
	static List<Laser> laserInvokers  = new List<Laser>();
	static List<TieFighter> tieInvokers = new List<TieFighter> ();

	static public void AddLaserInvoker(Laser invoker){
		laserInvokers.Add (invoker);
		if (intListener != null) {
			invoker.AddHudListener (intListener);
		}
		if (listener != null) {
			invoker.AddGameOverListener (listener);
		}
	}

	static public void AddTieInvoker(TieFighter invoker){
		tieInvokers.Add (invoker);
		if (listener != null) {
			invoker.AddGameOverEventListener (listener);
		}
	}

	static public void AddIntListener(UnityAction<int> listener){
		foreach (Laser invoker in laserInvokers) {
			invoker.AddHudListener (listener);
		}
	}

	static public void AddListener(UnityAction listener){
		foreach (Laser invoker in laserInvokers) {
			invoker.AddGameOverListener (listener);
		}
		foreach (TieFighter invoker in tieInvokers) {
			invoker.AddGameOverEventListener (listener);
		}
	}
}

