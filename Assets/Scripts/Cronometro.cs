using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cronometro : MonoBehaviour {

	private float currentTime = 0f;
	public float elapsedTime = 0f;
	float _elapsedTime{
		get{
			return elapsedTime;
		}
	}

	private bool countTime;

	// Use this for initialization
	void Start () {
		countTime = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(countTime){
			elapsedTime = Time.time - currentTime;
		}
	}

	public void StartTimer(){
		if (!countTime) {
			currentTime = Time.time;
			countTime = true;
		}else{
			RestartTime ();
		}
	}

	public void RestartTime(){
		currentTime = Time.time;
	}

	public void StopTimer(){
		countTime = false;
	}

	public bool isCounting(){
		return countTime;
	}
}
