using UnityEngine;
using System.Collections;

public class LifeButton : MonoBehaviour {
	public AudioClip purchaseSfx;
	public AudioClip failedSfx;

	void OnMouseDown() {
		if(GameManager.instance.coins >= 100 && GameManager.instance.lifePowerupLevel < 99) {
			audio.clip = purchaseSfx;
			audio.Play();
			GameManager.instance.coins -= 100;
			GameManager.instance.lifePowerupLevel++;
			GameManager.instance.savePowerups();
		} else {
			audio.clip = failedSfx;
			audio.Play();
		}
	}
}
