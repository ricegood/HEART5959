using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Record : MonoBehaviour {
	public AudioSource buttonSound;

	public GameObject[] record;
	public Text[] date;
	public Text[] p1;
	public Text[] p2;
	public GameObject[] blueFlag;
	public GameObject[] redFlag;
	public GameObject RightArrow;
	public GameObject LeftArrow;

	private int page;
	private int endpage;
	private int numOfRecord;
	private int index;

	// Use this for initialization
	void Start () {
		initialize ();
		updatePage (0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("escape")) {
			buttonSound.Play ();
			StartScene.popup = false;
			this.gameObject.SetActive (false);
			initialize ();
			updatePage (0);
		}
		else if (Input.GetKeyDown ("right")) {
			if (page < endpage) {
				buttonSound.Play ();
				updatePage (++page);
			}
		}
		else if (Input.GetKeyDown ("left")) {
			if (page > 0) {
				buttonSound.Play ();
				updatePage (--page);
			}
		}
	}

	private void initialize(){
		numOfRecord = PlayerPrefs.GetInt("numOfRecord");
		if (numOfRecord % 5 == 0) {
			endpage = numOfRecord / 5 - 1;
		} else endpage = numOfRecord / 5;
	}

	private void updatePage(int page){
		// arrow update
		if (page == 0 && page < endpage) {
			LeftArrow.SetActive (false);
			RightArrow.SetActive (true);
		} else if (page != 0 && page != endpage) {
			LeftArrow.SetActive (true);
			RightArrow.SetActive (true);
		} else if (page == endpage) {
			RightArrow.SetActive (false);
		} else if (page == 0) {
			RightArrow.SetActive (false);
		}

		// text & flag update
		for(int i=0; i<5; i++){
			record [i].SetActive (false);
			index = numOfRecord - 5*page - i;
			if (index > 0) {
				record [i].SetActive (true);
				if (PlayerPrefs.GetInt (index + "winner") == 1) {
					blueFlag [i].SetActive (true);
					redFlag [i].SetActive (false);
				} else {
					redFlag [i].SetActive (true);
					blueFlag [i].SetActive (false);
				}

				date[i].text = PlayerPrefs.GetString (index + "date");
				p1[i].text = PlayerPrefs.GetString (index + "P1name") + " " + PlayerPrefs.GetInt (index + "P1score");
				p2[i].text = PlayerPrefs.GetString (index + "P2name") + " " + PlayerPrefs.GetInt (index + "P2score");
			}
		}
		// endpage =
	}
}
