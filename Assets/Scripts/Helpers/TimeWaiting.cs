using UnityEngine;
using System.Collections;

public class TimeWaiting : MonoBehaviour {

	public float timeInterval = 0f;
	public string nextLevel = "";

	private float timeReducer = 0f;

	// Use this for initialization
	void Start () {
		timeReducer = timeInterval;
	}
	
	// Update is called once per frame
	void Update () {
		if(timeReducer <= 0)
		{
			Application.LoadLevel(nextLevel);
		}

		timeReducer = timeReducer - Time.deltaTime;
		Debug.Log (timeReducer);
	}
}
