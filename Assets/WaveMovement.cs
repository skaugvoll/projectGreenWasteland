using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour
{


    public SpriteRenderer sr;
    public Transform t;
    private float speed = -0.1f;
    private float heightChange = 5f;
    private float maxWidth = 190;
    private float initXpos;
    //private float initYpos;
    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        t = GetComponent<Transform>();

        initXpos = t.position.x;
        //initYpos = t.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        float newXpos = t.position.x;
        float newYpos = t.position.y + speed;

        if (newYpos < maxWidth) {
            newXpos = initXpos;
            newYpos = 225;
            newYpos += Random.Range(-heightChange, heightChange);
        }

        t.position = new Vector2(newXpos, newYpos);
    }
}
