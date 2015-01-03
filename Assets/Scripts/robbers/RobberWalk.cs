using UnityEngine;
using System.Collections;
using System;

public class RobberWalk : MonoBehaviour {
	public bool isLeft = true;
	public float velocity = 5f;
	private Transform powerup;
	private Transform freeze;
	private Transform target;

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision(8, 8);
		try {
			powerup = transform.FindChild("powerup");
			target = powerup.transform.FindChild("power_target");
			freeze = powerup.transform.FindChild("power_freeze");
		} catch(Exception ex) {
			// This is a citizen then
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		if(GameManager.instance.powerFlagFreeze != 1) {
			// move the enemy every fixed update
			this.ProcessMovement();
		}
		try {
			if(GameManager.instance.powerFlagTarget == 1) {
				target.gameObject.SetActive(true);
			} else {
				target.gameObject.SetActive(false);
			}

			if( GameManager.instance.powerFlagFreeze == 1) {
				freeze.gameObject.SetActive(true);
			} else {
				freeze.gameObject.SetActive(false);
			}
		} catch(Exception ex) {
			// This is an exception then
		}

	}

	void ProcessMovement() {
		// check if it's facing to the left
		if(this.isLeft == false) {
			// enemy facing left, move to left
			rigidbody2D.AddForce(-transform.right * velocity);
		} else {
			// enemy facing right, move to right
			rigidbody2D.AddForce(transform.right * velocity);
		}
	}
}
