using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private PlayerCarController currentPlayer;

	private float roundSeconds = 0f;
	private bool begin = false;

	public void StartTimer(){
		begin = true;
	}

	public void StopTimer(){
		begin = false;
	}

	public void Restart(){
		SceneManager.LoadScene("Game");
	}

	// Use this for initialization
	void Start () {
		currentPlayer = FindObjectOfType<PlayerCarController> () ;
	}
	
	// Update is called once per frame
	void Update () {
		if(begin){
			roundSeconds = Time.time;	
		}		
	}

	void LateUpdate(){
		if(!currentPlayer){
			//macchina distrutta, game over
			SceneManager.LoadScene("GameOver");
		}
	}
}
