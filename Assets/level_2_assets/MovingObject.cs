using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {


    private Transform t;
    private Vector2 originalPosition;

    public bool sinMoveX;
    public bool sinMoveY;
    public float incrementX = 0.05f;
    public float incrementY = 0;
    public float sinIncX = 3;
    public float sinIncY = 3;
    public float lessenImpact = 30; 


    // Use this for initialization
    void Start()
    {
        t = GetComponent<Transform>();
        originalPosition = t.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (lessenImpact == 0) return;
        
        if(sinMoveY) {
            t.position = new Vector2(t.position.x + incrementX, t.position.y + Mathf.Sin(Time.time * sinIncY) / (Mathf.PI * lessenImpact) + incrementY);
        } else
        {
            if(sinMoveX)
            {
                t.position = new Vector2(t.position.x + Mathf.Sin(Time.time * sinIncX) / (Mathf.PI * lessenImpact) + incrementX, t.position.y + incrementY);
            } else
            {
                t.position = new Vector2(t.position.x + incrementX, t.position.y + incrementY);
            }
        }
    }

    private void OnBecameInvisible()
    {
        t.position = originalPosition;
    }
}