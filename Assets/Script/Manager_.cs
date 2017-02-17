using UnityEngine;
using System.Collections;

public class Manager_ : MonoBehaviour {
	public GameObject[] itemPrefabs;
	private int type;	// 0:default, 1:item
	private float ranX;

	private float pickUpRate = 2f; //아이템 생성 지연 시간 설정
	private float nextPickUp = 0.1f; //다음 생성시간 

	private int randomNumber;

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
			setType ();
			ranX = Random.Range (-4f, 4f);
			Instantiate (itemPrefabs [type], new Vector3 (ranX, 3f, 0f), Quaternion.identity);
		}
	}

	private void setType(){
		randomNumber = (int)Random.Range (0, 100);

		if (randomNumber <= 90) {
			type = 0;
		} else if (randomNumber <= 100) {
			type = 1;
		}
	}
}
