using UnityEngine;
using System.Collections;

public class StarCollectorScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {

		StarBehaviour star = other.GetComponent<StarBehaviour>();
		GameState.Instance.AddExperience(star.experiencePoints * StarCollectorGameManager.Instance.currentlyChasing);
		Debug.Log("Experience points: " + GameState.Instance.experience);
		// Debug.Log ("Multiplier: " + StarCollectorGameManager.Instance.currentlyChasing);

		SpecialEffectsHelper.Instance.StarCollected(other.gameObject.transform.position);

		Destroy (other.gameObject);
		// Decrease the number of chasing instances
		StarCollectorGameManager.Instance.currentlyChasing -= 1;
		StarCollectorGameManager.Instance.IncrementStarsCollected();
	}
}
