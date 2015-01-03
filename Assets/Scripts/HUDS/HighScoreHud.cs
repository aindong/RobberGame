using UnityEngine;
using System.Collections;

public class HighScoreHud : MonoBehaviour {
	public GUISkin skin;

	void OnGUI() {
		GUI.skin = skin;



		GUI.BeginGroup(new Rect(0f, 50f, 500f, 200f));
		GUI.Box(new Rect(0f, 0f, 500f, 200f), "");
		GUI.Label(new Rect(30, 0, 500f, 200f),"HIGHSCORES", skin.customStyles[2]);
		GUI.Label(new Rect(30, 55f, 500f, 200f),"STORY MODE: " + GameManager.instance.highScore1.ToString(), skin.customStyles[1]);
		GUI.Label(new Rect(30, 85f, 500f, 200f),"ARCADE MODE: " + GameManager.instance.highScoreArcade.ToString(), skin.customStyles[1]);
		GUI.Label(new Rect(30, 115f, 500f, 200f),"TIMEATTACK MODE: " + GameManager.instance.highScoreTime.ToString(), skin.customStyles[1]);
		GUI.EndGroup ();

	}
}
