using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour {

	private bool collidedOnce = false;

	void OnCollisionEnter2D(Collision2D coll){
		if (!collidedOnce) {
			PlayerShipController p = coll.gameObject.GetComponent<PlayerShipController> ();
			p.health -= 20f;
			collidedOnce = true;
		}
	}

	void OnCollisionExit2D(Collision2D coll){
		collidedOnce = false;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
