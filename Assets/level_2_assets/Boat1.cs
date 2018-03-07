using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat1 : MonoBehaviour {


    private Transform t;
    public float increment = 0.05f;

	// Use this for initialization
	void Start () {
        t = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        t.position = new Vector2(t.position.x - increment, t.position.y);
	}
}
