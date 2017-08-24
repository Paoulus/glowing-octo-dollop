using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (ParticleSystem))]
public class PlayerCarController : MonoBehaviour {

  public float accelleration = 0.5f;
  public float maximumSpeed = 10f;
  public float health = 100f;
  public float minimumSpeed = -7f;
  public float turningRadius = 0.5f;
  public float driftQuantity = 1.4f;

  public ParticleSystem explosionEffect;

  private ParticleSystem smokeTrails;

  void OnCollisionEnter2D (Collision2D coll) {
    health -= 20f;
    if (health <= 0) {
      explosionEffect.transform.position = coll.contacts[0].point;
      explosionEffect.Play ();
      Destroy (this.gameObject);
    }
  }

  // Use this for initialization
  void Start () {
    smokeTrails = GetComponent<ParticleSystem> ();
  }

  // Update is called once per frame
  void Update () {
    Vector2 accellerationVector = transform.up * accelleration;
    Rigidbody2D shipBody = this.GetComponent<Rigidbody2D> ();

    //utilizza transform.right dato che la trasformata ha rotazione iniziale di 0,0,90

    if (Input.GetKey (KeyCode.W)) {
      shipBody.AddForce (accellerationVector);
    }
    if (Input.GetKey (KeyCode.S)) {
      shipBody.AddForce (-accellerationVector);
    }

    if (Input.GetKey (KeyCode.A)) {
      if (Input.GetKey (KeyCode.LeftShift)) {
        shipBody.AddTorque (turningRadius * driftQuantity);
      } else {
        shipBody.AddTorque (turningRadius);
      }
    }
    if (Input.GetKey (KeyCode.D)) {
      if (Input.GetKey (KeyCode.LeftShift)) {
        shipBody.AddTorque (-turningRadius * driftQuantity);
      } else {
        shipBody.AddTorque (-turningRadius);
      }
    }

    if ((Input.GetKey (KeyCode.A) || (Input.GetKey (KeyCode.S))) && Input.GetKey (KeyCode.LeftShift)) {
      if (!smokeTrails.isPlaying) {
        smokeTrails.Play ();
      }
    } else {
      if (smokeTrails.isPlaying)
        smokeTrails.Stop ();
    }
  }
}