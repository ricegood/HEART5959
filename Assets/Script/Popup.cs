using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Popup : MonoBehaviour {
	public int type;	// 0: Result Popup,   1: Quit Popup(Play Scene)

	public Text resultText;
	public GameObject[] buttonOverImage;
	private string winner;

	public GameObject waitPanel;
	public AudioSource moveSound;
	public AudioSource clickSound;

	public ogung[] ogungs;

	private int choose;

	// Use this for initialization
	void Start () {
			deActivateMenu (choose);
			choose = 0;
			activateMenu (choose);

		if (type == 0) {
			winner = PlayerPrefs.GetString ("P" + ogung.winPlayer.ToString () + "name");
			Debug.Log ("Win Player : " + winner);
			resultText.text = "♥ " + winner + " WIN ♥";
		}
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
		} else if (Input.GetKeyDown ("return")) {
			clickSound.Play ();
			switch (choose) {
			case 0:
				// OK => main scene
				StartScene.popup = false;
				moveScene ("Start");
				break;
			case 1:
				// retry
				if (type == 0) {
					moveScene ("Play");
				} else if (type == 1) {
					ogungs [0].enabled = true;
					ogungs [1].enabled = true;
					this.gameObject.SetActive (false);
					deActivateMenu (choose);
					choose = 0;
					activateMenu (choose);
				}
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
