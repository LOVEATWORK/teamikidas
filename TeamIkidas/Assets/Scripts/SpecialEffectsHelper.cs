using UnityEngine;
using System.Collections;

public class SpecialEffectsHelper : MonoBehaviour {
	
	public static SpecialEffectsHelper Instance;
	public ParticleSystem forwardMovementEffect;

	private ParticleSystem currentParticleSystem;

	float particleZPosition = -10f;
	
	void Awake() {
		
		// Register the singleton
		
		if (Instance != null) {
			Debug.LogError("Multiple instances of SpecialEffectsHelper!");
		}
		
		Instance = this;
		
	}

	public void MoveForward(Vector3 position) {
		Debug.Log (position);
		instantiate (forwardMovementEffect, position);
	}
	
	private ParticleSystem instantiate (ParticleSystem prefab, Vector3 position)
	{
		ParticleSystem newParticleSystem = Instantiate (prefab, position, Quaternion.identity) as ParticleSystem;
		// Destroy (newParticleSystem.gameObject, newParticleSystem.startLifetime);
		currentParticleSystem = newParticleSystem;
		return newParticleSystem;
	}

	public void Destroy() {
		Destroy (currentParticleSystem.gameObject);
		currentParticleSystem = null;
	}
}
