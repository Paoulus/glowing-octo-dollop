using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManagerComponent : MonoBehaviour {

    public ParticleSystem explosionEffect;
    public ParticleSystem driftingEffect;
    
    private bool explosionCreated = false;

    public void EnableDriftEffect()
    {
        if(!driftingEffect.isPlaying)
            driftingEffect.Play();
    }
    public void DisableDriftEffect()
    {
        driftingEffect.Stop();
    }

    public void CreateExplosion()
    {
        if (!explosionCreated)
        {
            explosionCreated = true;
            Instantiate(explosionEffect, transform.position, transform.rotation).Play();
        }
    }
}
