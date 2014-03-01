using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	void Start() {

	}

	void OnTriggerEnter2D(Collider2D collider){
		
		// Is this a shot?
		StarBehaviour star = collider.gameObject.GetComponent<StarBehaviour> ();
		
		if (star != null) {
			
			// Avoid friendly fire
			GameState.Instance.HP -= star.damage;

			if (GameState.Instance.HP <= 0) {
				Kill();
			}

		}
	}
	
	void Kill() {
		
		//var deathTransform = Instantiate(deathPrefab) as Transform;
		//deathTransform.position = transform.position;
		//deathTransform.rotation = transform.rotation;
		Destroy(gameObject);
	}
}
