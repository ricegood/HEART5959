using UnityEngine;
using System.Collections;

public class ogung : MonoBehaviour {

	public int speed;
	public bool lookRight;

	private SpriteRenderer spr;
	private Transform trs;

	private Vector3 movePos = new Vector3(0.03f , 0f , 0f);
	private Vector3 jumpPos = new Vector3(0f , 0.05f , 0f);
	private Vector3 scaleY = new Vector3(0f, 0.1f, 0f);

	// Use this for initialization
	void Start () {
		spr = GetComponent<SpriteRenderer> ();
		trs = GetComponent<Transform> ();
	}

	void FixedUpdate()
	{
		if(Input.GetKey("left")){
			spr.flipX = true;
			trs.position -= speed*movePos;
		}

		if(Input.GetKey("right")){
			spr.flipX = false;
			trs.position += speed*movePos;
		}

		if(Input.GetKey(".")){
			trs.position += speed*jumpPos;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
