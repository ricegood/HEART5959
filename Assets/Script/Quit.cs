using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour {
	public AudioSource keySound;

	public int type;				// 0. play scene  1. setting popup
	public GameObject UI_Quit;
	public ogung[] ogungs;

	void start(){
	}
	void Update()
	{
		if (type == 0) {
			if (Input.GetKeyDown ("escape")) {
				keySound.Play ();
				ogungs [0].enabled = false;
				ogungs [1].enabled = false;
				UI_Quit.SetActive (true);
			}
		}
		else if(type == 1){
			if (Input.GetKeyDown ("escape") || Input.GetKeyDown("return")) {
				keySound.Play();
				this.gameObject.SetActive(false);
				StartScene.popup = false;
			}
		}
	}
}
