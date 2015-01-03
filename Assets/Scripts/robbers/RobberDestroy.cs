﻿using UnityEngine;
using System.Collections;

public class RobberDestroy : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag == "Enemy") {
			Destroy(col.gameObject);
		}
	}
}
