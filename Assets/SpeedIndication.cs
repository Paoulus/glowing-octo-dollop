using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedIndication : MonoBehaviour {

	public GameObject playerShip;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playerShip.GetComponent<Rigidbody2D>()){
			GetComponent<Text>().text = playerShip.GetComponent<Rigidbody2D> ().velocity.magnitude.ToString();
		}
	}
}
