using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour {
	private Transform trs;
	// Use this for initialization
	void Start () {
		trs = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (trs.position.y < -3)
			Destroy(this.gameObject);
	}
}
