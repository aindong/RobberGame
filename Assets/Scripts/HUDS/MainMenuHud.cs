using UnityEngine;
using System.Collections;

public class MainMenuHud : MonoBehaviour {
	public GUISkin skin;

	void OnGUI() {
		GUI.skin = skin;
		GUI.Label(new Rect(0f, 0f, 200f, 30f), "COINS: " + GameManager.instance.coins);
		GUI.Label(new Rect(0f, 23f, 200f, 30f), "LIFE: " + GameManager.instance.lifePowerupLevel + "/99");
		GUI.Label(new Rect(120f, 23f, 200f, 30f), "TARGET: " + GameManager.instance.targetPowerupLevel + "/4");
		GUI.Label(new Rect(280f, 23f, 200f, 30f), "FREEZE: " + GameManager.instance.freezePowerupLevel + "/5");
	}
}
