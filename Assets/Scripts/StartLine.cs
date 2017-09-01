using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLine : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D collider){
		LoopsComponent l = collider.gameObject.GetComponent<LoopsComponent>();
		Cronometro c = collider.gameObject.GetComponent<Cronometro>();
		if(l){
			l.IncreaseLoops();
		}
	}
}
