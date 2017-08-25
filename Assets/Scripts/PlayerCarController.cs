using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (ParticleSystem))]
public class PlayerCarController : MonoBehaviour {

  public float accelleration = 0.5f;
  public float maximumSpeed = 10f;
  public float totalHealth = 100f;
  public float minimumSpeed = -7f;
  public float turningRadius = 0.5f;
  public float driftQuantity = 1.4f;

	private Cronometro cr;

  public Slider healthBarSlider;
	public Text timeText;
	public Text loopsText;

	public KeyCode accelerate;
	public KeyCode brake;
	public KeyCode left;
	public KeyCode right;
	public KeyCode drift;

	private LevelManager mainLevelManager;

  private ParticleSystem smokeTrails;
	public ParticleSystem explosionEffect;
	private Rigidbody2D shipBody;
	public int loopsDone;
	int _loopsDone{
		get{
			return loopsDone;
		}
		set{
			loopsDone = value;
		}
	}
	private float lapTime;
	float _lapTime{
		get{
			return lapTime;
		}
		set{
			lapTime = value;
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		GetComponent<Cronometro> ().StartTimer();
		loopsDone += 1;
	}

	  void OnCollisionEnter2D (Collision2D coll) {
			totalHealth -= 20f;
	  }

	  // Use this for initialization
	  void Start () {
	    smokeTrails = GetComponent<ParticleSystem> ();
		shipBody = GetComponent<Rigidbody2D> ();
		cr = GetComponent<Cronometro> ();
		mainLevelManager = FindObjectOfType<LevelManager> ();
		if(healthBarSlider){
				healthBarSlider.minValue = 0f;
				healthBarSlider.maxValue = totalHealth;
			}
	  }

	  // Update is called once per frame
	  void Update () {
		Vector2 accellerationVector = transform.up * accelleration;
		if (Input.GetKey (accelerate)) {
		shipBody.AddForce (accellerationVector);
	    }
			if (Input.GetKey (brake)) {
	      shipBody.AddForce (-accellerationVector);
	    }

			if (shipBody.velocity.magnitude >= 0.3f) {
				if (Input.GetKey (left)) {
					if (Input.GetKey (drift)) {
						shipBody.AddTorque (turningRadius * driftQuantity);
				} else {
						shipBody.AddTorque (turningRadius);
				}
			}
			if (Input.GetKey (right)) {
					if (Input.GetKey (drift)) {
						shipBody.AddTorque (-turningRadius * driftQuantity);
				} else {
						shipBody.AddTorque (-turningRadius);
				}
			}
		}

		if ((Input.GetKey (right) || (Input.GetKey (left))) && Input.GetKey (drift)) {
	      if (!smokeTrails.isPlaying) {
	        smokeTrails.Play ();
	      }
	    } else {
	      if (smokeTrails.isPlaying)
	        smokeTrails.Stop ();
	    }
		healthBarSlider.value = totalHealth;
		loopsText.text = loopsDone.ToString();
		timeText.text = cr.elapsedTime.ToString ();

		controllaSalute ();
	}

	void controllaSalute(){
		if (totalHealth <= 0 && !explosionEffect.isPlaying) {
			explosionEffect.transform.position = transform.position;
			explosionEffect.Play ();
			Invoke ("GameOver", 2.1f);
		}
	}

	void GameOver(){
		mainLevelManager.EndGame ();
	}
}