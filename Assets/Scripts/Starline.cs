using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starline : MonoBehaviour {


	private GameManager manager;

	// Use this for initialization
	void Start () {
		manager = FindObjectOfType<GameManager> () ;
	}

	void OnTriggerEnter2D(Collider2D coll){
		manager.PassingStartLine ();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
