using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	private LevelManager mainLevelManager;

	public ParticleSystem explosionEffect;

	public Text indicatoreGiri;

	public PlayerCarController[] players;

	public int maximumLoops = 3;
	private int loops = 0;

	private Cronometro timer;

	int _loops {
		get{
			return loops;
		}
	}

	// Use this for initialization
	void Start () {
		mainLevelManager = FindObjectOfType<LevelManager> ();
		timer = FindObjectOfType<Cronometro> ();
	}
	
	// Update is called once per frame
	void Update () {
		foreach (PlayerCarController currentPlayer in players) {
			if (currentPlayer.totalHealth <= 0 && currentPlayer && !explosionEffect.isPlaying) {
				Destroy (currentPlayer.gameObject);
				explosionEffect.transform.position = currentPlayer.transform.position;
				explosionEffect.Play ();
				Invoke ("GameOver", 2.1f);
			}
			indicatoreGiri.text = loops.ToString () + " / " + maximumLoops.ToString ();
		}
	}

	public void PassingStartLine(){
		if(!timer.isCounting()){
			timer.StartTimer ();
		}
		IncreaseLoops ();
	}

	void IncreaseLoops(){
		loops += 1;
		if(loops > maximumLoops){
			timer.StopTimer ();
			GameOver ();
		}
	}

	void ResetLoops(){
		loops = 0;
	}

	void GameOver(){
		mainLevelManager.EndGame ();
	}
}

