using UnityEngine;
using System.Collections;

public class OptionsUI : MonoBehaviour {
	public GUISkin skin;
	private float hSliderValue = 100f;
	private float sfxSlider = 100f;
	private bool mute = false;

	void OnGUI() {
		GUI.skin = skin;

		GUI.Label(new Rect(Screen.width/2f - 100f, 10f, 200f, 50f), "GAME OPTIONS");
		GUI.Label(new Rect(Screen.width/2f - 100f, Screen.height/2f - 65f, 200f, 50f), "Background Volume");
		hSliderValue = GUI.HorizontalSlider (new Rect (Screen.width / 2f - 100f, Screen.height / 2f - 35f, 200f, 30f), hSliderValue, 0f, 100f);

		GUI.Label(new Rect(Screen.width/2f - 100f, Screen.height/2f - (10f), 220f, 50f), "Effects Volume");
		sfxSlider = GUI.HorizontalSlider (new Rect (Screen.width/2f - 100f, Screen.height/2f - (-20f), 200f, 50f), sfxSlider, 0f, 100f);
	}

	void Update() {
		AudioListener.volume = hSliderValue/100f;

		if (mute == true) {
			AudioListener.volume = 0f;
		} else {
			AudioListener.volume = hSliderValue/100f;
		}

		SoundEffects.instance.sfxVolume = sfxSlider / 100f;
	}
}
