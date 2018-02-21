using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud_movement : MonoBehaviour {


	public SpriteRenderer sr;
	public Transform t;
	private float speed = 0.01f;
	private float heightChange = 5f;
	private float maxWidth = 105;
	private float initXpos;
	private float initYpos;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		t = GetComponent<Transform>();

		initXpos = t.position.x;
		initYpos = t.position.y;

	}
	
	// Update is called once per frame
	void Update () {
		float newXpos = t.position.x + speed;
		float newYpos = t.position.y;

		if (newXpos > maxWidth) {
			newXpos = 88;
			newYpos = initYpos;
			newYpos += Random.Range (-heightChange, heightChange);
		}

		t.position = new Vector2(newXpos, newYpos);
	}
}
