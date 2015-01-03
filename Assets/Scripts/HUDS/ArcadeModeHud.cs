using UnityEngine;
using System.Collections;

public class ArcadeModeHud : MonoBehaviour {
	public float timeLevel = 60f;
	public GUISkin skin;

	private float countdown = 0f;

	private float powerupCountdownMultiplier = 6f;
	private float powerupCountdownFreeze = 6f;

	// Use this for initialization
	void Start () {
		countdown = timeLevel;
		powerupCountdownFreeze = powerupCountdownFreeze + (GameManager.instance.freezePowerupLevel / 2f);
	}
	
	// Update is called once per frame
	void Update () {
		// call the multiplier powerup and check if the powerup is on
		MultiplierUp();
		// call the freeze powerup and check if it's active
		FreezeUp();

		if(countdown > 0) {
			countdown = countdown - Time.deltaTime;
		} else {
			GameManager.instance.setHighScoreArcade(GameManager.instance.playerScore);
			GameManager.instance.isGameOver = true;
		}
	}

	void FreezeUp() {
		if(GameManager.instance.powerFlagFreeze == 1) {
			if(powerupCountdownFreeze > 0) {
				powerupCountdownFreeze = powerupCountdownFreeze - Time.deltaTime;
				GameManager.instance.powerup2 = ((powerupCountdownFreeze / 6) * 100);
			} else {
				GameManager.instance.powerFlagFreeze = 0;
				powerupCountdownFreeze = 6f;
			}
		}
	}

	void MultiplierUp() {
		// check if the powerup is active
		if(GameManager.instance.powerFlagTarget == 1) {
			// powerup cooldown
			if(powerupCountdownMultiplier > 0) {
				GameManager.instance.multiplier = GameManager.instance.targetPowerupLevel == 0 ? 2 : 1 + GameManager.instance.targetPowerupLevel;
				powerupCountdownMultiplier = powerupCountdownMultiplier - Time.deltaTime;
				GameManager.instance.powerup1 = ((powerupCountdownMultiplier / 6) * 100);
				Debug.Log((powerupCountdownMultiplier / 6) * 100);
			} else {
				GameManager.instance.powerFlagTarget = 0;
				GameManager.instance.multiplier = 1;
				powerupCountdownMultiplier = 6f;
			}
		}
	}

	void OnGUI() {
		GUI.skin = skin;
		GUI.Label (new Rect (0f, 0f, 200f, 50f), "Time: " + (int)countdown + "s");
		GUI.Label (new Rect (200f, 0f, 200f, 50f), "Score: " + GameManager.instance.playerScore);
		GUI.Label (new Rect (400f, 0f, 200f, 50f), "Combo: " + GameManager.instance.multiplier + "X");

		if(GameManager.instance.isGameOver) {
			GUI.Label(new Rect(Screen.width/2f - 100f, Screen.height/2f - 25f, 200f, 50f), "ARCADE MODE FINISHED", skin.customStyles[0]);
			if(GUI.Button(new Rect(Screen.width/2f - 150f, Screen.height/2f + 30f, 100f, 40f), "MAIN MENU")) {
				// Reset Game Manager Value
				GameManager.instance.resetValues();
				countdown = timeLevel;
				Application.LoadLevel("scene_mainmenu");
			}

			if(GUI.Button(new Rect(Screen.width/2f + 50f, Screen.height/2f + 30f, 100f, 40f), "TRY AGAIN")) {
				// Reset Game Manager Value
				GameManager.instance.resetValues();
				countdown = timeLevel;
				Application.LoadLevel("scene_arcade");
			}
		}

		GUI.backgroundColor = Color.red;
		if(GUI.Button(new Rect(0f, Screen.height - 25f, GameManager.instance.powerup1, 20f), "")) {
			if(GameManager.instance.powerup1 == 100f) {
				GameManager.instance.powerFlagTarget = 1;
			}
		}

		GUI.backgroundColor = Color.blue;
		if(GUI.Button(new Rect(100f, Screen.height - 25f, GameManager.instance.powerup2, 20f), "")) {
			if(GameManager.instance.powerup2 == 100f) {
				GameManager.instance.powerFlagFreeze = 1;
			}
		}
	}
}
