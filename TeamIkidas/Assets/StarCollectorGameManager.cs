using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StarCollectorGameManager : MonoBehaviour {

	public Transform starTransform;
	public int maxStars;
	public int maxWidth;
	public int maxHeight;

	private static StarCollectorGameManager _instance;
	private StarBehaviour _star;
	private int _currentlyChasing;
	// Persistent variables


	public static StarCollectorGameManager Instance {
		get {
			
			if (_instance == null) {
				_instance = new GameObject("StarCollectorGameManager").AddComponent<StarCollectorGameManager>();
			}
			
			return _instance;
		}
	}

	void Start() {
		// Make sure to pause the game on start
		GameState.Instance.gameIsPaused = true;

		for (int i = 0; i < maxStars; i++) {
			Vector3 randomPos = new Vector3(Random.Range(2, maxWidth), Random.Range(2, maxHeight), 0);
			Instantiate(starTransform, randomPos, Quaternion.identity);
		}

	}

	void OnGUI() {
		GUI.Label (new Rect (10, 10, 200, 30), "XP: " + GameState.Instance.experience); 
	}

	void Update() {
		Debug.Log (currentlyChasing);
	}

	public int currentlyChasing {
		get {
			return _currentlyChasing;
		}
		set {
			_currentlyChasing = value;
		}
	}
}
