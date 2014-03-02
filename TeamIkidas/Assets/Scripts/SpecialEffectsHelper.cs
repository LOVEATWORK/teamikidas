using UnityEngine;
using System.Collections;

public class SpecialEffectsHelper : MonoBehaviour {
	
	public static SpecialEffectsHelper Instance;
	public ParticleSystem forwardMovementEffect;
	public ParticleSystem starCollectedEffect;
	public LineRenderer stardustStream;

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

	public void StarCollected(Vector3 position) {
		instantiate (starCollectedEffect, position);
	}

	public void StardustStream(Vector3 from, Vector3 to)
	{
		var stream = Instantiate(stardustStream, from, Quaternion.identity) as LineRenderer;
		stream.SetPosition(0, from);
		stream.SetPosition(1, to);
		Destroy(stream, 0.1f);
	}
	
	private ParticleSystem instantiate (ParticleSystem prefab, Vector3 position)
	{
		ParticleSystem newParticleSystem = Instantiate (prefab, position, Quaternion.identity) as ParticleSystem;
		Destroy (newParticleSystem.gameObject, newParticleSystem.startLifetime);
		currentParticleSystem = newParticleSystem;
		return newParticleSystem;
	}

	public void Destroy() {
		Destroy (currentParticleSystem.gameObject);
		currentParticleSystem = null;
	}
}
