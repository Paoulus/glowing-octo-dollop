using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private PlayerCarController currentPlayer;
	private LevelManager mainLevelManager;

	public ParticleSystem explosionEffect;

	private float roundSeconds = 0f;
	private bool begin = false;

	public void StartTimer(){
		begin = true;
	}

	public void StopTimer(){
		begin = false;
	}

	// Use this for initialization
	void Start () {
		currentPlayer = FindObjectOfType<PlayerCarController> () ;
		mainLevelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(begin){
			roundSeconds = Time.time;	
		}
		if(currentPlayer.totalHealth <= 0 && currentPlayer && !explosionEffect.isPlaying){
			Destroy (currentPlayer.gameObject);
			explosionEffect.transform.position = currentPlayer.transform.position;
			explosionEffect.Play ();
			Invoke ("GameOver", 2.8f);
		}
	}

	void GameOver(){
		mainLevelManager.EndGame ();
	}
}

