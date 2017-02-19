using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {
	public GameObject UI_Quit;
	public ogung[] ogungs;

	void start(){
	}
	void Update()
	{
		if (Input.GetKey("escape"))
		{
			ogungs [0].enabled = false;
			ogungs [1].enabled = false;
			UI_Quit.SetActive(true);
		}
	}
}
