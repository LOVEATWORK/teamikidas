using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StarCollectorGameManager : MonoBehaviour {

	public Transform starTransform;
	public int maxStars;
	public int maxWidth;
	public int maxHeight;
	public float gameDuration;

	public GUIText starsCollectedCounter;
	public GUIText xpCounter;
	public GUIText timesUpText;
	public GUIText timerText;
	public GUIText successText;

	private static StarCollectorGameManager _instance;
	private StarBehaviour _star;
	private int _currentlyChasing;
	private int _collectedStars;
	private float _timeLeft;
	private bool _success;
	private bool _fail;

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
		_instance = this;
		// Make sure to pause the game on start
		GameState.Instance.gameIsPaused = true;
		_collectedStars = 0;
		timesUpText.text = "";
		successText.text = "";
		UpdateStarsCollectedCounter();

		for (int i = 0; i < maxStars; i++) {
			Vector3 randomPos = new Vector3(Random.Range(-maxWidth, maxWidth), Random.Range(-maxHeight, maxHeight), 0);
			Instantiate(starTransform, randomPos, Quaternion.identity);
		}

	}

	private string GetCollectedStarsCount()
	{
		return _collectedStars + " of " + maxStars + " stars collected";
	}

	void Update() {
		UpdateXpCounter();
		UpdateTimer();
		if (!GameState.Instance.gameIsPaused && TimeLeft() < 0 && !_success)
		{
			timesUpText.text = "Time's up!!!";
			_fail = true;
		}
	}

	public float TimeLeft(){
		return gameDuration - (Time.time - GameState.Instance.StartTime);
	}

	public int currentlyChasing {
		get {
			return _currentlyChasing;
		}
		set {
			_currentlyChasing = value;
		}
	}

	public void IncrementStarsCollected()
	{
		_collectedStars += 1;
		UpdateStarsCollectedCounter();
	}

	private void UpdateStarsCollectedCounter()
	{
		if (starsCollectedCounter != null) 
		{
			starsCollectedCounter.text = GetCollectedStarsCount();
			if (_collectedStars == maxStars && !_fail)
			{
				//Success!!! all stars collected
				_success = true;
				successText.text = "You have collected all the stars!";
			}
		}
	}

	private void UpdateXpCounter()
	{
		if (xpCounter != null)
		{
			xpCounter.text = "XP: " + GameState.Instance.experience;
		}
	}

	private void UpdateTimer()
	{
		if (!_fail && !_success)
		{
			if (!GameState.Instance.gameIsPaused)
			{
				timerText.text = "Time: " + TimeLeft().ToString("N1") + "s";
			}
			else
			{
				timerText.text = "";
			}
		}
	}
}
