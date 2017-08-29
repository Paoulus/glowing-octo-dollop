using System.Collections.Generic;
using UnityEngine;

public class Cronometro : MonoBehaviour {
  
  private List<float>  loopTimes;
  private float _elapsedTime = 0f;

  public float elapsedTime {
    get {
      return _elapsedTime;
    }
    private set {
      _elapsedTime = value;
    }
  }

  private bool isTimeAdvancing;

  private float currentTime = 0f;

	void  OnTriggerEnter2D(){
       StartTimer();
	}

  // Use this for initialization
  void Start () {
    isTimeAdvancing = false;
    loopTimes = new List<float>();
  }

  // Update is called once per frame
  void Update () {
    if (isTimeAdvancing) {
      elapsedTime = Time.time - currentTime;
    }
  }

  public void StartTimer () {
    if (isTimeAdvancing) {
        loopTimes.Add(elapsedTime);
        loopTimes.Sort((x, y) => { if (x < y) return -1; if (x > y) return 1; return 0; }); //il comparator è specificato tramite l'espressione lambda
    }
    else
    {
      isTimeAdvancing = true;   
    }
    currentTime = Time.time;
  }

  public void StopTimer () {
    isTimeAdvancing = false;
  }
 
  public float BestTime(){
    if (loopTimes.Count > 0)
    {
        return loopTimes[0];
    }
    else
    {
        return 0; //nessun tempo presente (e.g: il cronometro non è ancora stato avviato o il giocatore non ha ancora fatto un giro completo)
    }
  }
}