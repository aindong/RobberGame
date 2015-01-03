using UnityEngine;
using System.Collections;

public class TargetButton : MonoBehaviour {
	public AudioClip purchaseSfx;
	public AudioClip failedSfx;
	
	void OnMouseDown() {
		if(GameManager.instance.coins >= 500 && GameManager.instance.targetPowerupLevel < 4) {
			audio.clip = purchaseSfx;
			audio.Play();
			GameManager.instance.coins -= 500;
			GameManager.instance.targetPowerupLevel++;
			GameManager.instance.savePowerups();
		} else {
			audio.clip = failedSfx;
			audio.Play();
		}
	}
}
