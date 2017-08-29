using UnityEngine;
using UnityEngine.UI;

// Mancano i require component
public class CarUIComponent : MonoBehaviour {

	public Slider healthBarSlider;

	public Text timeText;
	public Text loopsText;
	public Text bestTimeText;

	private HealthComponent healthComponent;
	private Cronometro cronometro;
    private LoopsComponent loopsComponent;

	void Start(){
		healthComponent = GetComponent<HealthComponent> ();
		cronometro = GetComponent<Cronometro> ();
        healthBarSlider.maxValue = healthComponent.maximumHealth;
        healthBarSlider.minValue = 0f;
        loopsComponent = GetComponent<LoopsComponent>();
	}

	// Update is called once per frame
	void Update () {
		timeText.text = cronometro.elapsedTime.ToString();
        loopsText.text = loopsComponent.loopsDone.ToString() + " / " + loopsComponent.maximumLoops.ToString();
		bestTimeText.text = cronometro.BestTime ().ToString();
		healthBarSlider.value = healthComponent.currentHealth;
	}
}
