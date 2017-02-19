using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ogung : MonoBehaviour {
	public const int ITEMTIME = 7;
	public static bool gameOver;
	public static int winPlayer;

	public int playerNumber;
	public GameObject gameOverPanel;
	public GameObject heart;
	public SpriteRenderer kissFace;
	public SpriteRenderer defaultFace;
	public AudioSource jumpSound;
	public AudioSource getSound;
	public AudioSource scoreSound;

	public Text scoreText;
	public int speed;
	public string color;

	public string rightKey;
	public string leftKey;
	public string jumpKey;
	public string putKey;

	private SpriteRenderer spr;
	private Transform trs;

	private Vector3 movePos = new Vector3(0.03f , 0f , 0f);
	private Vector3 jumpPos = new Vector3(0f , 0.05f , 0f);

	private Vector3 getBigger = new Vector3 (0.5f, 0.5f, 0f);
	//private Vector3 getSmaller = new Vector3 (0.5f, 0.5f, 0f);

	private bool hasHeart;
	private int score;

	private bool noJump;
	private bool jumpSoundBool;

	// 0:speedUp, 1:slowDown, 2:flipKey, 3:noJump, 4:sizeUp, 5:sizeDown

	private float now;
	private List<float> itemStartTimeList = new List<float>();
	private List<int> itemTypeList = new List<int> ();
	private float noJumpStartTime;

	// Use this for initialization
	void Start () {
		gameOver = false;
		hasHeart = false;
		score = 0;
		noJump = false;
		jumpSoundBool = false;
		now = 0;
		itemStartTimeList.Clear ();
		itemTypeList.Clear ();
		noJumpStartTime = 0;
		spr = GetComponent<SpriteRenderer> ();
		trs = GetComponent<Transform> ();
	}

	void Update(){
		now += Time.deltaTime;
		if (gameOver) {
			this.enabled = false;
			gameOverPanel.SetActive (true);
		}
		// Game Over Check
		if (trs.position.y < -3.0f) {
			//Debug.Log ("LOSE");
			if (playerNumber == 1)
				winPlayer = 2;
			else
				winPlayer = 1;
			gameOver = true;
		} else if (score >= 30) {
			//Debug.Log ("WIN");
			winPlayer = playerNumber;
			gameOver = true;
		}

		// No Jump Time Out
		if (noJump && (now - noJumpStartTime >= ITEMTIME)) {
			noJump = false;
		}

		// Bigger, Smaller, Faster, Slower Item Time Out
		for(int i=0; i<itemTypeList.Count; i++){
			if (now - itemStartTimeList[i] >= ITEMTIME) {
				switch (itemTypeList [i]) {
				case 0:
					// speed up
					itemTypeList.RemoveAt (i);
					itemStartTimeList.RemoveAt (i);
					i--;
					speed -= 1;
					break;
				case 1:
					// speed down
					itemTypeList.RemoveAt (i);
					itemStartTimeList.RemoveAt (i);
					i--;
					speed += 1;
					break;
				case 2:
					// flip key
					itemTypeList.RemoveAt (i);
					itemStartTimeList.RemoveAt (i);
					i--;
					string temp = rightKey;
					rightKey = leftKey;
					leftKey = temp;
					break;
				case 4:
					// size up
					itemTypeList.RemoveAt (i);
					itemStartTimeList.RemoveAt (i);
					i--;
					trs.localScale -= getBigger;
					break;
				case 5:
					// size down
					itemTypeList.RemoveAt (i);
					itemStartTimeList.RemoveAt (i);
					i--;
					trs.localScale += getBigger;
					break;
				}
			}
		}
	}

	void FixedUpdate()
	{
		if(Input.GetKey(leftKey)){
			spr.flipX = true;
			trs.position -= speed*movePos;
		}

		if(Input.GetKey(rightKey)){
			spr.flipX = false;
			trs.position += speed*movePos;
		}

		if (Input.GetKey (jumpKey) && !noJump) {
			if (!jumpSoundBool) {
				jumpSound.Play ();
				jumpSoundBool = true;
			}
			trs.position += speed * jumpPos;
		} else {
			jumpSoundBool = false;
		}

		if (hasHeart) {
			heart.SetActive (true);
		} else {
			heart.SetActive (false);
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.CompareTag (color + "Flag")) {
			if (hasHeart) {
				scoreSound.Play ();
				getScore (coll);
			}
		}

		if (coll.gameObject.CompareTag ("ogung")) {
			changeFace (kissFace);
		}
	}

	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.CompareTag ("ogung")) {
			changeFace (defaultFace);
		}
	}

	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.CompareTag ("ogung")) {
			if (Input.GetKeyDown (putKey)) {
				getSound.Play ();
				stealHeart(coll);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag("Heart"))
		{
			getSound.Play ();
			getHeart (other);
		}
		else if (other.gameObject.CompareTag("Item"))
		{
			getSound.Play ();
			getItem (other);
		}
	}

	public void setHasHeart(bool n){
		hasHeart = n;
	}

	public bool getHasHeart(){
		return hasHeart;
	}

	private void getHeart(Collider2D other){
		Destroy (other.gameObject);
		hasHeart = true;
	}

	private void getItem(Collider2D other){
		Destroy (other.gameObject);
		int type = other.gameObject.GetComponent<item>().getType();
		Debug.Log ("type : " + type);
		// 0:speedUp, 1:slowDown, 2:flipKey, 3:noJump, 4:sizeUp
		switch (type) {
		case 0:
			itemStartTimeList.Add (now);
			itemTypeList.Add (0);
			speed += 1;
			break;
		case 1:
			if (speed > 0) {
				itemStartTimeList.Add (now);
				itemTypeList.Add (1);
				speed -= 1;
			}
			break;
		case 2:
			itemStartTimeList.Add (now);
			itemTypeList.Add (2);
			string temp = rightKey;
			rightKey = leftKey;
			leftKey = temp;
			break;
		case 3:
			noJump = true;
			noJumpStartTime = now;
			break;
		case 4:
			itemStartTimeList.Add (now);
			itemTypeList.Add (4);
			trs.localScale += getBigger;
			break;
		case 5:
			if (trs.localScale.x >= 2 * getBigger.x) {
				itemStartTimeList.Add (now);
				itemTypeList.Add (5);
				trs.localScale -= getBigger;
			}
			break;
		}
	}
	
	private void getScore(Collision2D coll){
		score++;
		scoreText.text = score.ToString();
		hasHeart = false;
	}

	private void stealHeart(Collision2D other){
		if (other.gameObject.GetComponent<ogung> ().getHasHeart ()) {
			other.gameObject.GetComponent<ogung> ().setHasHeart (false);
			hasHeart = true;
		}
	}

	private void changeFace(SpriteRenderer s){
		spr.sprite = s.sprite;
	}
}
