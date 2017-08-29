using UnityEngine;

public class CameraController : MonoBehaviour {

  public GameObject characterToFollow;

    public bool shouldCameraRotateWithCharacter;

  void LateUpdate () {
		//il personaggio può essere distrutto
		if (characterToFollow) {
			transform.position = new Vector3 (characterToFollow.transform.position.x, characterToFollow.transform.position.y, -10f);
            if (shouldCameraRotateWithCharacter)
            {
                transform.rotation = characterToFollow.transform.rotation;
            }
        }
	}
}