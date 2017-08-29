using UnityEngine;

public class DirectionChecker : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D collider){
		LoopsComponent l = collider.gameObject.GetComponent<LoopsComponent>();
		if(l){
			l.rightDirection = true;
		}
	}
}
