using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	private static GameState _instance;

	// Persistant variables
	private string _currentScene;
	private int _experience;
	private int _hp;
	private string _playerName;
	private string _previousScene;

	public static GameState Instance {
		get {

			if (_instance == null) {
				_instance = new GameObject("GameState").AddComponent<GameState>();
			}

			return _instance;
		}
	}

	public void OnApplicationQuit () {
		_instance = null;
	}

	public void StartState() {

		_currentScene = "Overworld";
		_experience = 0;
		_hp = 100;
		_playerName = "My player name";

		Application.LoadLevel ("Overworld");

	}

	// Set scene
	public string currentScene {
		get {
			return _currentScene;
		}
	}

	public string previousScene {
		get {
			return _previousScene;
		}
	}

	// Set experience points
	public void AddExperience(int points) {
		_experience += points;
	}

	// Get experience
	public int experience {
		get {
			return _experience;
		}
	}	

	// Get player name
	public string playerName {
		get {
			return _playerName;
		}
	}

	public void LoadLevel(string scene) {

		// Save previous scene to be able to return back
		_previousScene = _currentScene;

		// Update current scene
		_currentScene = scene;
		// Load current scene
		Application.LoadLevel (_currentScene);
	}
}
