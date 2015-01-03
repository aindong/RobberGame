using UnityEngine;
using System.Collections;

public class StoryModeHud : MonoBehaviour {
	public GUISkin skin;

	public AudioClip gameOverBGM;
	public int level;

	private bool gameOverBGMPlaying = false;
	private int toComplete;

	// Use this for initialization
	void Start () {
		if(level == 1) {
			GameManager.instance.playerLife += GameManager.instance.lifePowerupLevel;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.instance.playerLife <= 0) {
			GameManager.instance.isGameOver = true;
			GameManager.instance.setHighScore(GameManager.instance.playerScore);
			GameManager.instance.saveCoins();
		}

		LevelUpgrade();
	}

	void LevelUpgrade() {
		switch(level) {
			case 1:
				toComplete = 900;
				if(GameManager.instance.playerScore >= 900) {
					Application.LoadLevel("scene_storylevel2");
					
				}
				break;
			case 2:
				toComplete = 2300;
				if(GameManager.instance.playerScore >= 2300) {
					Application.LoadLevel("scene_storylevel3");
					
				}
				break;
			case 3:
				toComplete = 3500;
				if(GameManager.instance.playerScore >= 3500) {
					Application.LoadLevel("scene_storylevel4");
					
				}
				break;
			case 4:
				toComplete = 5000;
				if(GameManager.instance.playerScore >= 5000) {
					Application.LoadLevel("scene_storyend");
					
				}
				break;
		}
	}

	void OnGUI() {
		GUI.skin = skin;
		GUI.Label (new Rect (0f, 0f, 200f, 50f), "SCORE: " + GameManager.instance.playerScore);
		GUI.Label (new Rect (150f, 0f, 400f, 100f), "SCORE TO COMPLETE: " + toComplete);
		GUI.Label (new Rect (Screen.width - 150f, 0f, 200f, 50f), "LIVES: " + GameManager.instance.playerLife);
	
		if(GameManager.instance.isGameOver) {
			if(gameOverBGMPlaying == false) {
				audio.clip = gameOverBGM;
				audio.Play();
				gameOverBGMPlaying = true;
			}

			GUI.Label(new Rect(Screen.width/2f - 100f, Screen.height/2f - 25f, 200f, 50f), "GAME OVER", skin.customStyles[0]);
			if(GUI.Button(new Rect(Screen.width/2f - 150f, Screen.height/2f + 30f, 100f, 40f), "MAIN MENU")) {
				// Reset Game Manager Value
				GameManager.instance.resetValues();
				Application.LoadLevel("scene_mainmenu");
			}
			
			if(GUI.Button(new Rect(Screen.width/2f + 50f, Screen.height/2f + 30f, 100f, 40f), "TRY AGAIN")) {
				// Reset Game Manager Value
				GameManager.instance.resetValues();
				Application.LoadLevel("scene_storylevel1");
			}
		}
	}
}
