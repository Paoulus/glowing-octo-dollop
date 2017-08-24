using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour {

	public float accelleration = 0.5f;
	public float maximumSpeed = 10f;
	public float health = 100f;
	public float minimumSpeed = -7f;

	private ParticleSystem smokeTrails;

	// Use this for initialization
	void Start () {
		smokeTrails = GetComponent<ParticleSystem> ();
		smokeTrails.Stop ();
	}

	// Update is called once per frame
	void Update () {
		float a = accelleration * Time.deltaTime;
		Rigidbody2D shipBody = this.GetComponent<Rigidbody2D> ();

		//utilizza transform.right dato che la trasformata ha rotazione iniziale di 0,0,90

		if(Input.GetKey(KeyCode.W)){
			shipBody.velocity += new Vector2(transform.right.x,transform.right.y) * a;
		}else{
			shipBody.velocity -= new Vector2 (transform.right.x, transform.right.y) * (0.3f * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.S)){
			shipBody.velocity -= new Vector2(transform.right.x,transform.right.y) * a;
		}
		if(Input.GetKey(KeyCode.A)){
			if (Input.GetKey (KeyCode.LeftShift)) {
				//smokeTrails.Play ();
				shipBody.rotation += speedTurningRadius(shipBody.velocity.magnitude) + 1.5f;
			}else{
				shipBody.rotation += speedTurningRadius(shipBody.velocity.magnitude);
			}
		}
		if(Input.GetKey(KeyCode.D)){
			if (Input.GetKey (KeyCode.LeftShift)) {
				//smokeTrails.Play ();
				shipBody.rotation -= speedTurningRadius(shipBody.velocity.magnitude) + 1.5f;
			}else{
				shipBody.rotation -= speedTurningRadius(shipBody.velocity.magnitude);
			}
		}
		shipBody.velocity = transform.right * Mathf.Clamp (shipBody.velocity.magnitude, minimumSpeed, maximumSpeed);

		Camera.main.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, -10f);
	}

	float speedTurningRadius(float speed){
		Debug.Log (8f * (1f / Mathf.Clamp (speed, 1.0f, maximumSpeed))); 
		return 8f * 1f / Mathf.Clamp(speed, 1.0f,maximumSpeed);
	}
}
