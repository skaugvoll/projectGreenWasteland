using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour {

    public SpriteRenderer sr;
    public Transform t;
    private float incrementor = 0.1f;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        t = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        t.position = new Vector3(t.position.x, t.position.y - incrementor);
	}
}
