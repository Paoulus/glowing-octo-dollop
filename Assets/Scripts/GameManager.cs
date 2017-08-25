using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	private LevelManager mainLevelManager;

	public ParticleSystem explosionEffect;

	public PlayerCarController[] players;

	public int maximumLoops = 3;
	private int loops = 0;

	int _loops {
		get{
			return loops;
		}
	}

	// Use this for initialization
	void Start () {
		mainLevelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		foreach(PlayerCarController car in players){
			if(car.loopsDone > maximumLoops){
				mainLevelManager.EndGame ();
			}
		}
	}
}

