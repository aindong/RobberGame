using UnityEngine;
using System.Collections;

public class FreezeButton : MonoBehaviour {
	public AudioClip purchaseSfx;
	public AudioClip failedSfx;
	
	void OnMouseDown() {
		if(GameManager.instance.coins >= 500 && GameManager.instance.freezePowerupLevel < 5) {
			audio.clip = purchaseSfx;
			audio.Play();
			GameManager.instance.coins -= 500;
			GameManager.instance.freezePowerupLevel++;
			GameManager.instance.savePowerups();
		} else {
			audio.clip = failedSfx;
			audio.Play();
		}
	}
}
