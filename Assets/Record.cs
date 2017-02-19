using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Record : MonoBehaviour {
	public AudioSource buttonSound;

	public GameObject[] record;
	public Text[] recordText;
	public GameObject[] blueFlag;
	public GameObject[] redFlag;
	public GameObject RightArrow;
	public GameObject LeftArrow;

	private int page;
	private int endpage;
	private int numOfRecord;

	// Use this for initialization
	void Start () {
		initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("escape")) {
			buttonSound.Play ();
			StartScene.popup = false;
			this.gameObject.SetActive (false);
			initialize ();
		}
	}

	private void initialize(){
		page = 0;
		// endpage =
		// numOfRecord = PlayerPrefs.GetInt("numOfRecord");
	}
}
