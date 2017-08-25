using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cronometro : MonoBehaviour {
	public float elapsedTime = 0f;
	float _elapsedTime{
		get{
			return elapsedTime;
		}
	}

	public bool isTimeAdvancing;
	bool _isTimeAdvancing{
		get{
			return isTimeAdvancing;
		}
	}

	private float currentTime = 0f;

	// Use this for initialization
	void Start () {
		isTimeAdvancing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(isTimeAdvancing){
			elapsedTime = Time.time - currentTime;
		}
	}

	public void StartTimer(){
		if (!isTimeAdvancing) {
			currentTime = Time.time;
			isTimeAdvancing = true;
		}else{
			RestartTime ();
		}
	}

	//riavvia il cronometro senza fermarlo
	public void RestartTime(){
		currentTime = Time.time;
	}

	public void StopTimer(){
		isTimeAdvancing = false;
	}
}
