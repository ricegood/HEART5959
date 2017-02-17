using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Util : MonoBehaviour {
	// movescene, quit
	public GameObject waitPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void moveScene(string name){
		waitPanel.SetActive (true);
		SceneManager.LoadScene(name);
	}

	public void openQuitPanel(){
		
	}
}
