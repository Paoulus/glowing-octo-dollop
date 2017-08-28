using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cronometro : MonoBehaviour {
  
  private List<float>  _loopTimes;
  private float _elapsedTime = 0f;

  public float elapsedTime {
    get {
      return _elapsedTime;
    }
    private set {
      _elapsedTime = value;
    }
  }

  private bool _isTimeAdvancing;

  public bool isTimeAdvancing {
    get {
      return _isTimeAdvancing;
    }
    private set {
      _isTimeAdvancing = value;
    }
  }

  private float currentTime = 0f;

	void  OnTriggerEnter2D(){
		StartTimer();
	}

  // Use this for initialization
  void Start () {
    isTimeAdvancing = false;
  }

  // Update is called once per frame
  void Update () {
    if (isTimeAdvancing) {
      elapsedTime = Time.time - currentTime;
    }
  }

  public void StartTimer () {
    RestartTime ();
    if (!isTimeAdvancing) {
      isTimeAdvancing = true;
    }
  }

  //riavvia il cronometro senza fermarlo
  public void RestartTime () {
    currentTime = Time.time;
  }

  public void StopTimer () {
    isTimeAdvancing = false;
  }
 
  public float BestTime(){
		return 0.0f;
  }
}