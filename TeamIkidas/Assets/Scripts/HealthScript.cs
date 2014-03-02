using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	void Start() {

	}

	void OnTriggerEnter2D(Collider2D collider){

		if (collider.gameObject.tag == "Player") {
			return;
		}
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
	
	public void Kill() {
		
		//var deathTransform = Instantiate(deathPrefab) as Transform;
		//deathTransform.position = transform.position;
		//deathTransform.rotation = transform.rotation;


		if (StarCollectorGameManager.Instance.TimeLeft () > 0) {
			Application.LoadLevel(Application.loadedLevel);
		}
		else {
			//Debug.Log("Player died because time was up");
			var playerObject = GameObject.FindWithTag("Player");
			SpecialEffectsHelper.Instance.Splosion(playerObject.gameObject.transform.position);
			Destroy(playerObject.gameObject);
		}

		Destroy(gameObject);
	}
}
