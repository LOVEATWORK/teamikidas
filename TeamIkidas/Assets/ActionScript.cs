using UnityEngine;
using System.Collections;

public class ActionScript : MonoBehaviour {

	public string SceneToLoadForward;
	public string SceneToLoadBackward;
	private bool isCollision = false;
	private float verticalDirection;

	// Use this for initialization
	void Start () {
		Debug.Log (SceneToLoadForward);
		Debug.Log (SceneToLoadBackward);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (isCollision) {
			verticalDirection = Input.GetAxis("Vertical");



			// Vertical up
			if (SceneToLoadForward.Length > 0 && verticalDirection > 0) {


				// Load scene forward
				Debug.Log("Moving forward to scene: " + SceneToLoadForward);
			
			
			} else if (SceneToLoadBackward.Length > 0 && verticalDirection < 0) {

				// Load scene backwards
				Debug.Log("Moving backward to scene: " + SceneToLoadBackward);
			}

				
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		SpecialEffectsHelper.Instance.MoveForward(transform.position);
		isCollision = true;
	}

	void OnTriggerExit2D(Collider2D other) {
		isCollision = false;
		SpecialEffectsHelper.Instance.Destroy ();
	}
}
