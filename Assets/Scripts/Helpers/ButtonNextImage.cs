using UnityEngine;
using System.Collections;

public class ButtonNextImage : MonoBehaviour {
	public GameObject nextImage;
	public bool lastImage;
	public string nextScene = "";

	void OnMouseDown() 
	{
		if(lastImage) 
		{
			Application.LoadLevel(nextScene);
			return;
		}

		gameObject.SetActive (false);
		nextImage.SetActive (true);
	}
}
