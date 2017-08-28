using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopsComponent : MonoBehaviour {

    public int maximumLoops = 3;

	private int _loopsDone = 0;
	public int loopsDone {
		get{ 
			return _loopsDone;
		}
		private set { 
			_loopsDone = value;
		}
	}

	void OnTriggerEnter2D (Collider2D coll) {
		loopsDone += 1;
	}
}
