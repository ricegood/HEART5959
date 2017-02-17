using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Popup : MonoBehaviour {
	public Text resultText;
	public GameObject[] buttonOverImage;
	private string winner;

	public GameObject waitPanel;
	public AudioSource moveSound;
	public AudioSource clickSound;

	private int choose;

	// Use this for initialization
	void Start () {
		deActivateMenu (choose);
		choose = 0;
		activateMenu (choose);

		winner = PlayerPrefs.GetString ("P" + ogung.winPlayer.ToString () + "name");
		Debug.Log ("Win Player : " + winner);
		resultText.text = "♥ " + winner + " WIN ♥";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("left") || Input.GetKeyDown("right")) {
			deActivateMenu (choose);

			if (choose == 0)
				choose = 1;
			else
				choose = 0;

			activateMenu (choose);
		} else if (Input.GetKeyDown ("c")) {
			clickSound.Play ();
			switch (choose) {
			case 0:
				// OK => main scene
				StartScene.popup = false;
				moveScene ("Start");
				break;
			case 1:
				// retry
				moveScene ("Play");
				break;
			}
		}
	}

	private void activateMenu(int n){
		moveSound.Play();
		buttonOverImage [n].SetActive (true);
	}

	private void deActivateMenu (int n){
		buttonOverImage [n].SetActive (false);
	}

	private void moveScene(string name){
		waitPanel.SetActive (true);
		SceneManager.LoadScene(name);
	}
}
