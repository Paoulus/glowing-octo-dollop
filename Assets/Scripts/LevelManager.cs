using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

  public void RestartGame () {
    SceneManager.LoadScene ("Game");
  }

  public void EndGame () {
    SceneManager.LoadScene ("GameOver");
  }
}