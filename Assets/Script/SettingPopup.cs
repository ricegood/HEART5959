using UnityEngine;
using System.Collections;

public class SettingPopup : MonoBehaviour {
	public AudioSource moveSound;
	public AudioSource clickSound;

	public GameObject[] buttonImage;
	public GameObject[] buttonOverImage;
	public GameObject[] openingPanel;

	private int choose;

	// Use this for initialization
	void Start () {
		choose = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("up") || Input.GetKeyDown ("down")) {
			deActivateMenu (choose);

			if (choose == 0)
				choose = 1;
			else
				choose = 0;

			activateMenu (choose);
		} else if (Input.GetKeyDown ("return")) {
			clickSound.Play ();
			openingPanel [choose].SetActive (true);
			this.gameObject.SetActive (false);
			deActivateMenu (choose);
			choose = 0;
			activateMenu (choose);
		} else if (Input.GetKeyDown ("escape")) {
			clickSound.Play ();
			this.gameObject.SetActive (false);
			StartScene.popup = false;
			deActivateMenu (choose);
			choose = 0;
			activateMenu (choose);
		}
	}

	private void activateMenu(int n){
		moveSound.Play();
		buttonImage [n].SetActive (false);
		buttonOverImage [n].SetActive (true);
	}

	private void deActivateMenu (int n){
		buttonOverImage [n].SetActive (false);
		buttonImage [n].SetActive (true);
	}
}
