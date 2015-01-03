using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	// shop powerups
	public int lifePowerupLevel = 0;
	public int targetPowerupLevel = 0;
	public int freezePowerupLevel = 0;

	public int playerScore = 0;
	public int playerLife = 1;
	public float playerTime = 0f;
	public int robberToKill = 10;

	public int coins;

	public bool isPuase = false;
	
	public bool isGameOver = false;

	public float powerup1 = 100f;
	public float powerup2 = 100f;
	public int powerFlagTarget = 0;
	public int powerFlagFreeze = 0;

	public int multiplier = 1;

	// highscore for the story mode
	public int highScore1 = 0;

	// highscore for the arcade mode
	public int highScoreArcade = 0;

	// highscore for the timeattack
	public float highScoreTime = 0;

	private static GameManager _instance;

	public void loadPowerups() {
		if(PlayerPrefs.HasKey("lifePowerupLevel")) {
			instance.lifePowerupLevel = PlayerPrefs.GetInt("lifePowerupLevel");
		} else {
			PlayerPrefs.SetInt("lifePowerupLevel", lifePowerupLevel);
		}

		if(PlayerPrefs.HasKey("targetPowerupLevel")) {
			instance.targetPowerupLevel = PlayerPrefs.GetInt("targetPowerupLevel");
		} else {
			PlayerPrefs.SetInt("targetPowerupLevel", targetPowerupLevel);
		}

		if(PlayerPrefs.HasKey("freezePowerupLevel")) {
			instance.freezePowerupLevel = PlayerPrefs.GetInt("freezePowerupLevel");
		} else {
			PlayerPrefs.SetInt("freezePowerupLevel", freezePowerupLevel);
		}
	}

	public void savePowerups() {
		PlayerPrefs.SetInt("lifePowerupLevel", lifePowerupLevel);
		PlayerPrefs.SetInt("targetPowerupLevel", targetPowerupLevel);
		PlayerPrefs.SetInt("freezePowerupLevel", freezePowerupLevel);
	}

	public void loadCoins() {
		if(PlayerPrefs.HasKey("coins")) {
			coins = PlayerPrefs.GetInt("coins");
		} else {
			PlayerPrefs.SetInt("coins", instance.coins);
		}
	}

	public void saveCoins() {
		PlayerPrefs.SetInt ("coins", instance.coins);
	}

	public void loadHighScore() {
		// load highscore values
		if(PlayerPrefs.HasKey("highScore1")) {
			highScore1 = PlayerPrefs.GetInt("highScore1");
		} else {
			PlayerPrefs.SetInt("highScore1", highScore1);
		}

		// load highscore values
		if(PlayerPrefs.HasKey("highScoreArcade")) {
			highScoreArcade = PlayerPrefs.GetInt("highScoreArcade");
		} else {
			PlayerPrefs.SetInt("highScoreArcade", highScoreArcade);
		}

		// load highscore values
		if(PlayerPrefs.HasKey("highScoreTime")) {
			highScoreTime = PlayerPrefs.GetFloat("highScoreTime");
		} else {
			PlayerPrefs.SetFloat("highScoreTime", highScoreTime);
		}

		PlayerPrefs.Save();
	}

	public void setHighScore(int newScore) {
		if(newScore > highScore1) {
			PlayerPrefs.SetInt("highScore1", newScore);
			PlayerPrefs.Save();
			loadHighScore();
			return;
		}
	}

	public void setHighScoreArcade(int newScore) {
		if(newScore > highScoreArcade) {
			PlayerPrefs.SetInt("highScoreArcade", newScore);
			PlayerPrefs.Save();
			loadHighScore();
			return;
		}
	}

	public void setHighScoreTime(float newScore) {
		if(newScore > highScoreTime) {
			PlayerPrefs.SetFloat("highScoreTime", newScore);
			PlayerPrefs.Save();
			loadHighScore();
			return;
		}
	}

	public void resetValues() {
		instance.playerScore = 0;
		instance.playerLife = 1;
		instance.playerTime = 0f;
		instance.robberToKill = 10;
		instance.powerup1 = 100f;
		instance.powerup2 = 100f;
		instance.isGameOver = false;
		instance.isPuase = false;
		Time.timeScale = 1f;
	}

	// Persistent singleton
	public static GameManager instance { 
		get {
			if(_instance == null) {
				_instance = GameObject.FindObjectOfType<GameManager>();
				// never destroy this gameobject
				DontDestroyOnLoad(_instance.gameObject);
			}

			return _instance;
		}
	}
	
	// Use this for initialization
	void Awake() {
		if(_instance == null) {
			_instance = this;
			DontDestroyOnLoad(this);
		} else {
			if(this != _instance) {
				// if the instance already exists
				// destroy the current instance
				Destroy(this.gameObject);
			}
		}
	}

	void Start() {
		loadHighScore();
		loadCoins();
		loadPowerups();
	}
}
