using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour {

    public SpriteRenderer sr;
    public Transform t;
    private float incrementor = 0.1f;
    private bool mouseDown = false;

    private string type;

    private float minRot = 0.1f;
    private float maxRot = 1;


    public FallingObject(string type)
    {
        this.type = type;
    }

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        t = GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update()
    {
        if (!mouseDown)
        {
            t.position = new Vector3(t.position.x, t.position.y - incrementor);
        }
    }

    private void OnMouseDown()
    {
        mouseDown = true;
    }

    private void OnMouseUp()
    {
        mouseDown = false;
    }


    private void OnMouseDrag()
    {
        Vector3 mousePositionInWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = mousePositionInWorldPoint.x;
        float y = mousePositionInWorldPoint.y;
        t.position = new Vector3(x, y);
    }


    /*
     * Removes gameobject when outside of screen to avoid memory buildup
     */ 
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}



