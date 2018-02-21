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
        if (contains(Input.mousePosition))
        {
            print("OIOIOI");
        }else
        {
            t.position = new Vector3(t.position.x, t.position.y - incrementor);
        }
	}

    public bool contains(Vector2 mouse)
    {
        return (t.position.x < mouse.x && t.position.x + sr.size.x > mouse.x &&
            t.position.y < mouse.y && t.position.y + sr.size.y > mouse.y);
    }


}
