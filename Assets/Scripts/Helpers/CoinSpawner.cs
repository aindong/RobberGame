using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour {
	public GameObject coin;
	public int chance = 0;
	public float dropTime = 0f;

	private int fullChance = 100;
	private bool instantiated = false;
	private float interval = 3f;
	private GameObject newCoin;

	private float dropInterval;

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision(8, 8);

		dropInterval = dropTime;
	}
	
	// Update is called once per frame
	void Update () {
		spawnRandomCoin();
	}

	void spawnRandomCoin() {
		if(instantiated == false) {

			dropInterval = dropInterval - Time.deltaTime;
			if(dropInterval <= 0) {
				int coinChance = Random.Range (0, fullChance);
				if(coinChance <= chance) {
					newCoin = (GameObject)Instantiate(coin, transform.position, coin.transform.rotation);
					instantiated = true;
				}
				dropInterval = dropTime;
			}

		} else {
			interval = interval - Time.deltaTime;

			if(interval <= 0) {
				interval = 3f;
				instantiated = false;
				Destroy(newCoin);
			}
		}
		
		//Instantiate(robberTypes[robberIndex], transform.position, robberTypes[robberIndex].transform.rotation);
	}
	
}
