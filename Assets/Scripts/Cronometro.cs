using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour {

	public Text text;

	private float currentTime = 0f;
	private float elapsedTime = 0f;

	private bool countTime;

	// Use this for initialization
	void Start () {
		countTime = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(countTime){
			elapsedTime = Time.time - currentTime;
			text.text = elapsedTime.ToString();
		}
	}

	public void StartTimer(){
		currentTime = Time.time;
		countTime = true;
	}

	public void StopTimer(){
		countTime = false;
	}

	public float GetTime(){
		return elapsedTime;
	}

	public bool isCounting(){
		return countTime;
	}
}
