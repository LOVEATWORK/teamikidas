using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	private static GameState _instance;

	// Persistant variables
	private string _currentScene;
	private int _experience;
	private int _hp;
	private string _playerName;

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

		_currentScene = "";
		_experience = 0;
		_hp = 100;
		_playerName = "My player name";

	}

	// Set scene
	public string CurrentScene {
		get {
			return _currentScene;
		}
		set {
			_currentScene = value;
		}
	}

	// Set experience points
	public void AddExperience(int points) {
		_experience += points;
	}

	// Get experience
	public int Experience {
		get {
			return _experience;
		}
	}	

	// Get player name
	public string PlayerName {
		get {
			return _playerName;
		}
	}
}
