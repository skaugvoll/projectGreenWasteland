using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect_object : MonoBehaviour {

    


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == tag)
        {
            GameObject.Find("Main Camera)").GetComponent<Scorecounter>().updateScore(1);
                

            Destroy(col.gameObject);
           

        }
    }
}
