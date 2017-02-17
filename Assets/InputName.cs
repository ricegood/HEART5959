using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class InputName : MonoBehaviour {
	public InputField inputField1;

	void Start () {
		EventSystem.current.SetSelectedGameObject(inputField1.gameObject, null);
		inputField1.OnPointerClick(new PointerEventData(EventSystem.current));
	}

	public void pointerOnField(InputField field){
		EventSystem.current.SetSelectedGameObject(field.gameObject, null);
		field.OnPointerClick(new PointerEventData(EventSystem.current));
	}

	public void SetPlayer1Name(string value)
	{
		PlayerPrefs.SetString ("P1name", value);
	}

	public void SetPlayer2Name(string value)
	{
		PlayerPrefs.SetString ("P2name", value);
	}

	public void SceneMove(){
		SceneManager.LoadScene ("main");
	}
}
