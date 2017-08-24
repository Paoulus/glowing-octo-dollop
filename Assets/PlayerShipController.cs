using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour {

	//la velocità di rotazione è inversamente proporzionale alla veloctià

	public float accelleration = 0.5f;
	public float maximumSpeed = 10f;
	public float health = 100f;
	public float minimumSpeed = -7f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		float a = accelleration * Time.deltaTime;
		Rigidbody2D shipBody = this.GetComponent<Rigidbody2D> ();

	
		if(Input.GetKey(KeyCode.W)){
			shipBody.velocity += new Vector2(transform.up.x,transform.up.y) * a;
		}else{
			shipBody.velocity -= new Vector2 (transform.up.x, transform.up.y) * (0.3f * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.S)){
			shipBody.velocity -= new Vector2(transform.up.x,transform.up.y) * a;
		}
		if(Input.GetKey(KeyCode.A)){
			if (Input.GetKey (KeyCode.LeftShift)) {
				shipBody.rotation += 2.3f;
			}else{
				shipBody.rotation += speedTurningRadius(shipBody.velocity.magnitude);
			}
		}
		if(Input.GetKey(KeyCode.D)){
			if (Input.GetKey (KeyCode.LeftShift)) {
				shipBody.rotation -= 2.3f;
			}else{
				shipBody.rotation -= speedTurningRadius(shipBody.velocity.magnitude);
			}
		}
		shipBody.velocity = transform.up * Mathf.Clamp (shipBody.velocity.magnitude, minimumSpeed, maximumSpeed);

		Camera.main.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, -10f);
	}

	float speedTurningRadius(float speed){
		Debug.Log (8f * (1f / Mathf.Clamp (speed, 0.4f, maximumSpeed))); 
		return 8f * 1f / Mathf.Clamp(speed, 1.0f,maximumSpeed);
	}
}
