using UnityEngine;
using System.Collections;

public class item : MonoBehaviour {
	private int type; // 0:speedUp, 1:slowDown, 2:flipKey, 3:noJump, 4:sizeUp, 5:sizeDown

	void Start () {
		type = Random.Range (0, 6);
	}

	public int getType(){
		return type;
	}
}
