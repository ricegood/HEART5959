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

	public void SetPlayer1Name(Text t)
	{
		PlayerPrefs.SetString ("P1name", t.text);
	}

	public void SetPlayer2Name(Text t)
	{
		PlayerPrefs.SetString ("P2name", t.text);
	}

	public void SceneMove(){
		SceneManager.LoadScene ("main");
	}
}
