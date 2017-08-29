using UnityEngine;

public class LoopsComponent : MonoBehaviour {

  	public int maximumLoops = 3;
	public int loopsDone;

	public bool rightDirection = false;

	public void IncreaseLoops(){
		if(rightDirection){
			loopsDone += 1;
			rightDirection = false;
		}
	}
}
