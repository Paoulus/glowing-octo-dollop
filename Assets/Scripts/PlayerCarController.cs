using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (ParticleSystem))]
[RequireComponent (typeof (Cronometro))]
[RequireComponent (typeof (HealthComponent))]
[RequireComponent (typeof (CarUIComponent))]
public class PlayerCarController : MonoBehaviour {

  public float accelleration = 0.5f;
  public float turningTorque = 0.5f;
  public float driftQuantity = 1.4f;

  public float minimumTurningSpeed = 0.41f;
  public float driftAngularDragReduction = 2.5f;
 
  private LevelManager mainLevelManager;

  private bool alive = true;

  private ParticleSystem smokeTrails;
  public ParticleSystem explosionEffect;
  private Rigidbody2D carRigidBody2D;
  private SpriteRenderer spriteRendered;
  private LoopsComponent loopsComponent;
  private HealthComponent healthComponent; 

  private float originalAngularDrag;

  public int loopsDone;
  public int playerNumber;
  
  private string horizontalAxisString;
  private string verticalAxisString ;
	private string driftButtonString;

  void OnTriggerEnter2D (Collider2D coll) {
    loopsDone += 1;
  }

  // Use this for initialization
  void Start () {
    smokeTrails = GetComponent<ParticleSystem> ();
    carRigidBody2D = GetComponent<Rigidbody2D> ();
    loopsComponent = GetComponent<LoopsComponent> ();
    mainLevelManager = FindObjectOfType<LevelManager> ();
	spriteRendered = GetComponent<SpriteRenderer> ();
	healthComponent = GetComponent<HealthComponent> ();

    originalAngularDrag = carRigidBody2D.angularDrag;
	  
	horizontalAxisString = "Horizontal Player " + playerNumber;
	verticalAxisString = "Vertical Player " + playerNumber;
	driftButtonString = "Drift Player " + playerNumber;
}

  // Update is called once per frame
  void Update () {
    if (alive) {
		Vector2 accellerationVector = transform.up * accelleration;
		carRigidBody2D.AddForce (accellerationVector * Input.GetAxis (verticalAxisString));
            if (carRigidBody2D.velocity.magnitude >= minimumTurningSpeed)
                if (Input.GetAxis(driftButtonString) == 1)
                {
                    carRigidBody2D.angularDrag = originalAngularDrag - driftAngularDragReduction;
                    smokeTrails.Play();
                }
                else
                {
                    smokeTrails.Stop();
                }
    }
 
    controllaSalute ();
  }

  void controllaSalute () {
	if (healthComponent.currentHealth <= 0 && !explosionEffect.isPlaying) {
      explosionEffect.transform.position = transform.position;
      explosionEffect.Play ();
      Invoke ("GameOver", 2.1f);
	  spriteRendered.color = new Color (0f, 0f, 0f, 0f);
      alive = false;
    }
  }

  void GameOver () {
    mainLevelManager.EndGame ();
  }
}