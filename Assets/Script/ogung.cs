using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ogung : MonoBehaviour {
	public GameObject heart;
	public SpriteRenderer kissFace;
	public SpriteRenderer defaultFace;

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
	private Vector3 scaleY = new Vector3(0f, 0.1f, 0f);

	private bool hasHeart;
	private int score;

	// Use this for initialization
	void Start () {
		spr = GetComponent<SpriteRenderer> ();
		trs = GetComponent<Transform> ();
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

		if(Input.GetKey(jumpKey)){
			trs.position += speed*jumpPos;
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
				Debug.Log ("zzz");
				stealHeart(coll);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag("Heart"))
		{
			getHeart (other);
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
