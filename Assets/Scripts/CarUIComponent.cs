﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarUIComponent : MonoBehaviour {

	public Slider healthBarSlider;

	public Text timeText;
	public Text loopsText;
	public Text bestTimeText;

	private HealthComponent healthComponent;
	private Cronometro cronometro;

	void Start(){
		healthComponent = GetComponent<HealthComponent> ();
		cronometro = GetComponent<Cronometro> ();
        healthBarSlider.maxValue = healthComponent.maximumHealth;
        healthBarSlider.minValue = 0f;
	}

	// Update is called once per frame
	void Update () {
		timeText.text = cronometro.elapsedTime.ToString();
        loopsText.text = cronometro.BestTime().ToString();
		bestTimeText.text = cronometro.BestTime ().ToString();
		healthBarSlider.value = healthComponent.currentHealth;
	}
}
