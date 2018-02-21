using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown_timer : MonoBehaviour {

    private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        sr.material.SetFloat("_Cutoff", Mathf.InverseLerp(0, Screen.width, Input.mousePosition.x));
    }
}
