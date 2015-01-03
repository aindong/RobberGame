using UnityEngine;
using System.Collections;

public class TimeAttackHud : MonoBehaviour {
	public GUISkin skin;

	public AudioClip gameOverBGM;
	public int level;
	public float timeNeeded;

	private float levelCountDown = 0f;
	private bool gameOverBGMPlaying = false;

	// Use this for initialization
	void Start () {
		levelCountDown = timeNeeded + GameManager.instance.playerTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(levelCountDown >= 0) {
			levelCountDown = levelCountDown + Time.deltaTime;
		} else {
			GameManager.instance.setHighScoreTime(GameManager.instance.playerTime);
			GameManager.instance.isGameOver = true;
		}

		LevelUpgrade();
	}

	void LevelUpgrade() {
		switch(level) {
			case 1:
				if(GameManager.instance.robberToKill <= 0) {
					GameManager.instance.robberToKill = 15;
					GameManager.instance.playerTime = levelCountDown;
					Application.LoadLevel("scene_timeattack2");
				}
				break;
			case 2:
				if(GameManager.instance.robberToKill <= 0) {
					GameManager.instance.robberToKill = 20;
					GameManager.instance.playerTime = levelCountDown;
					Application.LoadLevel("scene_timeattack3");
				}
				break;
			case 3:
				if(GameManager.instance.robberToKill <= 0) {
					GameManager.instance.robberToKill = 25;
					GameManager.instance.playerTime = levelCountDown;
					Application.LoadLevel("scene_timeattack4");
				}
				break;
			case 4:
				if(GameManager.instance.robberToKill <= 0) {
					GameManager.instance.robberToKill = 30;
					GameManager.instance.playerTime = levelCountDown;
					Application.LoadLevel("scene_timeattack5");
				}
				break;
			case 5:
				if(GameManager.instance.robberToKill <= 0) {
					GameManager.instance.robberToKill = 35;
					GameManager.instance.playerTime = levelCountDown;
					Application.LoadLevel("scene_timeattack6");
				}
				break;
			case 6:
				if(GameManager.instance.robberToKill <= 0) {
					GameManager.instance.robberToKill = 40;
					GameManager.instance.playerTime = levelCountDown;
					Application.LoadLevel("scene_timeattack7");
				}
				break;
			case 7:
				if(GameManager.instance.robberToKill <= 0) {
					GameManager.instance.robberToKill = 40;
					GameManager.instance.playerTime = levelCountDown;
					Application.LoadLevel("scene_timeattack8");
				}
				break;
			case 8:
				if(GameManager.instance.robberToKill <= 0) {
					GameManager.instance.setHighScoreTime(GameManager.instance.playerTime);
					GameManager.instance.isGameOver = true;
				}
				break;
		}
	}

	void OnGUI() {
		GUI.skin = skin;
		GUI.Label (new Rect (0f, 0f, 200f, 50f), "ROBBER LEFT: " + GameManager.instance.robberToKill);
		GUI.Label (new Rect (Screen.width/2f - 50f, 0f, 200f, 50f), "LEVEL: " + level);
		GUI.Label (new Rect (Screen.width - 150f, 0f, 200f, 50f), "TIME: " + levelCountDown);
		
		if(GameManager.instance.isGameOver) {
			if(gameOverBGMPlaying == false) {
				audio.clip = gameOverBGM;
				audio.Play();
				gameOverBGMPlaying = true;
			}
			
			GUI.Label(new Rect(Screen.width/2f - 100f, Screen.height/2f - 25f, 200f, 50f), "TIME ATTACK FINISHED", skin.customStyles[0]);

			if(GUI.Button(new Rect(Screen.width/2f - 150f, Screen.height/2f + 30f, 100f, 40f), "MAIN MENU")) {
				// Reset Game Manager Value
				GameManager.instance.resetValues();
				levelCountDown = GameManager.instance.playerTime;
				Application.LoadLevel("scene_mainmenu");
			}
			
			if(GUI.Button(new Rect(Screen.width/2f + 50f, Screen.height/2f + 30f, 100f, 40f), "TRY AGAIN")) {
				// Reset Game Manager Value
				GameManager.instance.resetValues();
				levelCountDown = GameManager.instance.playerTime;
				Application.LoadLevel("scene_timeattack1");
			}
		}
	}
}
