using UnityEngine;
using System.Collections;

public class CoinAI : MonoBehaviour {
	public AudioClip coinSfx;

	void OnMouseDown() {
		audio.clip = coinSfx;
		audio.Play();
		GameManager.instance.coins++;
		Destroy(gameObject, 0.2f);
	}
}
