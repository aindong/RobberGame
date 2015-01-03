using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {
	public GameObject pauseMenu;

	void OnMouseDown() {
		if(GameManager.instance.isPuase) {
			pauseMenu.SetActive (false);
			Time.timeScale = 1f;
			GameManager.instance.isPuase = false;
		} else {
			pauseMenu.SetActive (true);
			Time.timeScale = 0f;
			GameManager.instance.isPuase = true;
		}
	}
}
