using UnityEngine;
using System.Collections;

public class ButtonNext : MonoBehaviour {

	public string nextScene = "";

	void OnMouseDown() 
	{
		SoundEffects.instance.PlayButtonClick();
		//GameManager.instance.saveCoins();
		GameManager.instance.resetValues();
		Application.LoadLevel (nextScene);
	}
}
