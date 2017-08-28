using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
  public ParticleSystem explosionEffect;

  public PlayerCarController[] players;

  public int maximumLoops = 3;

  private LevelManager mainLevelManager;

  // Use this for initialization
  void Start () {
    mainLevelManager = FindObjectOfType<LevelManager> ();
  }

  // Update is called once per frame
  void Update () {
    foreach (PlayerCarController car in players) {
      if (car.loopsDone > maximumLoops) {
        mainLevelManager.EndGame ();
      }
    }
  }
}