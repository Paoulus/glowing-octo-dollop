using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (EffectsManagerComponent))]
[RequireComponent (typeof (Cronometro))]
[RequireComponent (typeof (HealthComponent))]
[RequireComponent (typeof (CarUIComponent))]
public class PlayerCarController : MonoBehaviour {
  private LevelManager mainLevelManager;

  private SpriteRenderer spriteRendered;
  private LoopsComponent loopsComponent;
  private HealthComponent healthComponent;
  private EffectsManagerComponent effectsManager;
  private PlayerMovementComponent movement;

  // Use this for initialization
  void Start () {
    loopsComponent = GetComponent<LoopsComponent> ();
    mainLevelManager = FindObjectOfType<LevelManager> ();
	spriteRendered = GetComponent<SpriteRenderer> ();
	healthComponent = GetComponent<HealthComponent> ();
    effectsManager = GetComponent<EffectsManagerComponent>();
    movement = GetComponent<PlayerMovementComponent>();
}

  // Update is called once per frame
  void Update () {
    if (healthComponent.currentHealth <= 0)
    {
        effectsManager.CreateExplosion();
        spriteRendered.color = new Color(0f, 0f, 0f, 0f);
        Invoke("GameOver", 0.5f);
    }
    if(loopsComponent.loopsDone > loopsComponent.maximumLoops)
        {
            movement.shouldMove = false;
            Invoke("GameOver", 2.1f);
        }
  }


  void GameOver () {
    mainLevelManager.EndGame ();
  }
}