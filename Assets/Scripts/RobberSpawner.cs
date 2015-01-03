using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RobberSpawner : MonoBehaviour {

	public List<GameObject> robberTypes = new List<GameObject>();
	public float spawnerIntervalMaxTime = 0f;
	public float spawnerIntervalMinTime = 0f;

	private float countdown = 0f;

	// Use this for initialization
	void Start () {
		this.countdown = this.GenerateRandomInterval(this.spawnerIntervalMinTime, this.spawnerIntervalMaxTime);
	}
	
	// Update is called once per frame
	void Update () {
		if(this.countdown > 0) {
			this.countdown = this.countdown - Time.deltaTime;
		} else {
			// Spawn new robber
			if(GameManager.instance.isGameOver == false && GameManager.instance.powerFlagFreeze != 1) {
				spawnRandomRobber();
			}

			// Reset the countdown and get a new random interval
			this.countdown = this.GenerateRandomInterval(this.spawnerIntervalMinTime, this.spawnerIntervalMaxTime);
		}
	}

	void spawnRandomRobber() {
		int robberIndex = Random.Range (0, robberTypes.Count);

		Instantiate(robberTypes[robberIndex], transform.position, robberTypes[robberIndex].transform.rotation);
	}

	float GenerateRandomInterval(float minTime, float maxTime) {
		return Random.Range(minTime, maxTime);
	}
}
