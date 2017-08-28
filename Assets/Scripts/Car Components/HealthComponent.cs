using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour {

	public float maximumHealth = 100f;
	public float crushDamage = 10f;

	public bool isInvulnerable = false;

	private float _currentHealth;
	public float currentHealth{
		get{
			return _currentHealth;
		}
		private set{
			_currentHealth = value;
		}
	}

	void OnCollisionEnter2D (Collision2D coll) {
		InflictDamage (crushDamage);
	}

    void InflictDamage(float d){
		if(d >= 0 && !isInvulnerable)
			currentHealth -= d;
	}

	// Use this for initialization
	void Start () {
		currentHealth = maximumHealth;
	}
}
