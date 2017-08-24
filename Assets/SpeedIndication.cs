using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedIndication : MonoBehaviour {

	public ParticleSystem explosionEffect;

	void OnCollisionEnter2D(Collision2D coll){
		explosionEffect.transform.position = coll.collider.transform.position;
		explosionEffect.Play ();
	}

	// Use this for initialization
	void Start () {
		
	}

	

	// Update is called once per frame
	void Update () {

	}
}
