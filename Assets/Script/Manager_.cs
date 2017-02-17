using UnityEngine;
using System.Collections;

public class Manager_ : MonoBehaviour {
	public GameObject[] itemPrefabs;
	private float ranX;

	private float pickUpRate = 2f; //아이템 생성 지연 시간 설정
	private float nextPickUp = 0.1f; //다음 생성시간 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CreateHearts ();
	}

	void CreateHearts(){
		if (Time.time > nextPickUp) {
			nextPickUp = Time.time + pickUpRate;

			for (int i = 0; i < itemPrefabs.Length; i++) {
				ranX = Random.Range (-4f, 4f);
				Instantiate (itemPrefabs [i], new Vector3 (ranX, 3f, 0f), Quaternion.identity);
			}
		}
	}
}
