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

	private static StarCollectorGameManager _instance;
	private StarBehaviour _star;
	private int _currentlyChasing;
	private int _collectedStars;

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
		UpdateStarsCollectedCounter();

		for (int i = 0; i < maxStars; i++) {
			Vector3 randomPos = new Vector3(Random.Range(2, maxWidth), Random.Range(2, maxHeight), 0);
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
		if (!GameState.Instance.gameIsPaused && Time.time - GameState.Instance.StartTime > gameDuration)
		{
			timesUpText.text = "Time's up!!!";
		}
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
		if (!GameState.Instance.gameIsPaused)
		{
			timerText.text = "Time: " + (gameDuration - (Time.time - GameState.Instance.StartTime)).ToString("N1") + "s";
		}
		else
		{
			timerText.text = "";
		}
	}
}
