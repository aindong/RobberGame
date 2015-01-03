using UnityEngine;
using System.Collections;

public class RobberHealth : MonoBehaviour {
	public int robberHealthPoints = 1;
	public int scoreRobber = 0;
	public int robberType = 1;

	public bool isEnemy = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(robberHealthPoints <= 0) {
			// Add a score
			if(isEnemy) {
				if(GameManager.instance.powerFlagTarget == 1) {
					GameManager.instance.playerScore += scoreRobber * (GameManager.instance.multiplier + GameManager.instance.targetPowerupLevel);
				} else {
					GameManager.instance.playerScore += scoreRobber;
				}

				GameManager.instance.robberToKill--;
			} else {
				GameManager.instance.playerLife -= 1;
			}

			switch (robberType) {
				case 1: 
					SoundEffects.instance.PlayRobber1();
					break;
				case 2:
					SoundEffects.instance.PlayRobber2();
					break;
				case 3:
					SoundEffects.instance.PlayRobber3();
					break;
			case 4:
				SoundEffects.instance.PlayFemaleCitizen();
				break;
			case 5:
				SoundEffects.instance.PlayMaleCitizen();
				break;
			}

			// Destroy robber
			Destroy(gameObject);
		}
	}

	void OnMouseDown() {
		if(GameManager.instance.isGameOver == false && GameManager.instance.isPuase == false) {
			robberHealthPoints--;
		}
	}
}
