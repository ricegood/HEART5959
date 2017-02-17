using UnityEngine;
using System.Collections;

public class StartScene : MonoBehaviour {
	public GameObject arrow;
	public GameObject[] menuList;
	public GameObject[] menuOverList;

	private int choose;

	private Vector3 arrowPos = new Vector3(0.9f, 1.15f, 0f);
	private Vector3 arrowOffset = new Vector3 (0f, 0.6f, 0f);

	// Use this for initialization
	void Start () {
		choose = 0;
		activateMenu (choose);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("up")){
			deActivateMenu (choose);

			if (choose == 0)
				choose = menuList.Length - 1;
			else
				choose--;

			activateMenu (choose);
		}
		else if(Input.GetKeyDown("down")){
			deActivateMenu (choose);

			if (choose == menuList.Length - 1)
				choose = 0;
			else
				choose++;

			activateMenu (choose);
		}
		else if(Input.GetKeyDown("c")){
			switch (choose) {
			case 0:
				break;
			case 1:
				break;
			case 2:
				break;
			case 3:
				Application.Quit ();
				break;
			}
		}
	}

	private void activateMenu(int n){
		menuList [n].SetActive (false);
		menuOverList [n].SetActive (true);
		arrow.GetComponent<Transform> ().position = arrowPos - n * arrowOffset;
	}

	private void deActivateMenu (int n){
		menuList [n].SetActive (true);
		menuOverList [n].SetActive (false);
	}
}
