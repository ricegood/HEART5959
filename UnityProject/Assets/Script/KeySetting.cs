using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeySetting : MonoBehaviour {
	public AudioSource keySound;
	public AudioSource returnSound;
	public GameObject[] settingPanels;
	public Text keyText;

	private int page;

	// Use this for initialization
	void Start () {
		page = 0;
		keyText.text = PlayerPrefs.GetString ("1LeftKey");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("return")) {
			returnSound.Play ();
			if (page == settingPanels.Length - 1) {
				page = 0;
				this.gameObject.SetActive (false);
				StartScene.popup = false;
				keyText.gameObject.SetActive (true);
				keyText.text = PlayerPrefs.GetString ("1LeftKey");
			} else {
				settingPanels [page].SetActive (false);
				switch (page) {
				case 0:
					PlayerPrefs.SetString ("1LeftKey", keyText.text);
					keyText.text = PlayerPrefs.GetString ("1RightKey");
					break;
				case 1:
					PlayerPrefs.SetString ("1RightKey", keyText.text);
					keyText.text = PlayerPrefs.GetString ("1JumpKey");
					break;
				case 2:
					PlayerPrefs.SetString ("1JumpKey", keyText.text);
					keyText.text = PlayerPrefs.GetString ("1StealKey");
					break;
				case 3:
					PlayerPrefs.SetString ("1StealKey", keyText.text);
					keyText.text = PlayerPrefs.GetString ("2LeftKey");
					break;
				case 4:
					PlayerPrefs.SetString ("2LeftKey", keyText.text);
					keyText.text = PlayerPrefs.GetString ("2RightKey");
					break;
				case 5:
					PlayerPrefs.SetString ("2RightKey", keyText.text);
					keyText.text = PlayerPrefs.GetString ("2JumpKey");
					break;
				case 6:
					PlayerPrefs.SetString ("2JumpKey", keyText.text);
					keyText.text = PlayerPrefs.GetString ("2StealKey");
					break;
				case 7:
					PlayerPrefs.SetString ("2StealKey", keyText.text);
					keyText.gameObject.SetActive (false);
					break;
				}
				page = page + 1;
				settingPanels [page].SetActive (true);
			}
		} else if(Input.anyKeyDown) {
			keySound.Play ();
			keyText.text = (string)Input.inputString;
		}
	}
}
