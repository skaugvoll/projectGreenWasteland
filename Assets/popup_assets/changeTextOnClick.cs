using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeTextOnClick : MonoBehaviour {

	// Use this for initialization
	public Button button;

	void Start () {
		// button = GetComponent<Button>();
		// button.onClick.AddListener(ButtonOnClick);

	}

	// Update is called once per frame
	void Update () {

	}

	// this happens everytime the buttion is clicked
	public void ButtonOnClick() {
		Debug.Log("Clicked");
	}
}
