using UnityEngine;
using System.Collections;

public class SoundClick : MonoBehaviour {

	public AudioClip clicksfx;
	public string target = "button";

	void Start()
	{
		this.gameObject.AddComponent<AudioSource>();
		this.gameObject.GetComponent<AudioSource>().clip = clicksfx;
	}

	void OnMouseDown()
	{
		if (target == "button") {
			this.gameObject.GetComponent<AudioSource>().Play();
		} else if (target == "robber") {
			int robberHealth = this.GetComponent<RobberHealth>().robberHealthPoints;
			if (robberHealth <= 0) {
				this.gameObject.GetComponent<AudioSource>().Play();
			}
		}
	}
}
