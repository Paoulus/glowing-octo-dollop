using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour {

	public float accelleration = 0.5f;
	public float maximumSpeed = 10f;
	public float health = 100f;
	public float minimumSpeed = -7f;
	public float turningRadius = 0.5f;

	private ParticleSystem smokeTrails;

	// Use this for initialization
	void Start () {
		smokeTrails = GetComponent<ParticleSystem> ();
		smokeTrails.Stop ();
	}

	// Update is called once per frame
	void Update () {
		Vector2 accellerationVector = transform.right * accelleration;
		Rigidbody2D shipBody = this.GetComponent<Rigidbody2D> ();

		//utilizza transform.right dato che la trasformata ha rotazione iniziale di 0,0,90

		if(Input.GetKey(KeyCode.W)){
			shipBody.AddForce (accellerationVector);
		}
		if(Input.GetKey(KeyCode.S)){
			shipBody.AddForce (-accellerationVector);
		}
		if(Input.GetKey(KeyCode.A)){
			if (Input.GetKey (KeyCode.LeftShift)) {
				//smokeTrails.Play ();
				shipBody.AddTorque(turningRadius);
			}else{
				shipBody.AddTorque(turningRadius);
			}
		}
		if(Input.GetKey(KeyCode.D)){
			if (Input.GetKey (KeyCode.LeftShift)) {
				//smokeTrails.Play ();
				shipBody.AddTorque(-turningRadius);
			}else{
				shipBody.AddTorque(-turningRadius);
			}
		}
		shipBody.velocity = transform.right * Mathf.Clamp (shipBody.velocity.magnitude, minimumSpeed, maximumSpeed);

		Camera.main.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, -10f);
	}
}
