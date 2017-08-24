using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

  public GameObject characterToFollow;

  void LateUpdate () {
		//il personaggio può essere distrutto
		if (characterToFollow) {
			transform.position = new Vector3 (characterToFollow.transform.position.x, characterToFollow.transform.position.y, -10f);
		}
	}
}