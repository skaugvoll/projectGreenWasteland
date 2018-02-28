using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour {

    public SpriteRenderer sr;
    public Transform t;
    public Rigidbody2D rigidBody;

    private float incrementor = 0.1f;
    private bool mouseDown = false;

    private string type;

    private float minRot = 0.1f;
    private float maxRot = 1;


    private Vector2 prevPos;
    private Vector2 currentPos;
    private int maxVelocity = 1;


    public FallingObject(string type)
    {
        this.type = type;
    }

	// Use this for initialization
	void Start () { 
        maxVelocity = 4;
        int angularVelocity = 50;
        sr = GetComponent<SpriteRenderer>();
        t = GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();
        // Initial speed and angular velocity
        int negOrPos = ((int) Random.Range(0, 2))*2 -1;
        float vx = Random.Range(0, maxVelocity + 1) * negOrPos;
        rigidBody.velocity = new Vector2(vx, Mathf.Sqrt(Mathf.Pow(maxVelocity,2) - Mathf.Pow(vx, 2)));
        rigidBody.angularVelocity = negOrPos * Random.Range(0, angularVelocity);

	}

    // Update is called once per frame
    void Update()
    {
        if (!mouseDown)
        {
            t.position = new Vector3(t.position.x, t.position.y - incrementor);
        }else
        {
            prevPos = currentPos;
            currentPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    private void OnMouseDown()
    {
        mouseDown = true;
    }

    private void OnMouseUp() {
        print(maxVelocity);
        mouseDown = false;
        Vector2 direction = new Vector2(currentPos.x - prevPos.x, currentPos.y - prevPos.y);
        if (direction.x == 0 && direction.y == 0)
        {
            rigidBody.velocity = new Vector2(0, 0);
            return;
        }
        float modifier;
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            modifier = maxVelocity / direction.x;
        }else
        {
            modifier = maxVelocity / direction.y;
        }
        modifier = Mathf.Abs(modifier);
        //        print(modifier);
        rigidBody.velocity = new Vector2(direction.x * modifier, direction.y * modifier);
       // print(modifier);

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



