using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StarCollectorGameManager : MonoBehaviour {

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
