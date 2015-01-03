using UnityEngine;
using System.Collections;

public class SoundEffects : MonoBehaviour {

	private static SoundEffects _instance;

	// Public variables
	public float sfxVolume = 1f;

	public AudioClip buttonSfx;

	public AudioClip robber1Sfx;
	public AudioClip robber2Sfx;
	public AudioClip robber3Sfx;

	public AudioClip femaleCitizenSfx;
	public AudioClip maleCitizenSfx;

	// Persistent singleton
	public static SoundEffects instance {
		get {
			if(_instance == null) {
				_instance = GameObject.FindObjectOfType<SoundEffects>();
				// never destroy this gameobject
				DontDestroyOnLoad(_instance.gameObject);
			}
			
			return _instance;
		}
	}

	// Use this for initialization
	void Awake() {
		if(_instance == null) {
			_instance = this;
			DontDestroyOnLoad(this);
		} else {
			if(this != _instance) {
				// if the instance already exists
				// destroy the current instance
				Destroy(this.gameObject);
			}
		}
	}

	public void PlayButtonClick()
	{
		this.audio.volume = this.sfxVolume;
		this.audio.clip = buttonSfx;
		this.audio.Play();
	}

	public void PlayRobber1()
	{
		this.audio.volume = this.sfxVolume;
		this.audio.clip = robber1Sfx;
		this.audio.Play();
	}

	public void PlayRobber2()
	{
		this.audio.volume = this.sfxVolume;
		this.audio.clip = robber2Sfx;
		this.audio.Play();
	}

	public void PlayRobber3()
	{
		this.audio.volume = this.sfxVolume;
		this.audio.clip = robber3Sfx;
		this.audio.Play();
	}

	public void PlayMaleCitizen()
	{
		this.audio.volume = this.sfxVolume;
		this.audio.clip = maleCitizenSfx;
		this.audio.Play();
	}

	public void PlayFemaleCitizen()
	{
		this.audio.volume = this.sfxVolume;
		this.audio.clip = femaleCitizenSfx;
		this.audio.Play();
	}

}
