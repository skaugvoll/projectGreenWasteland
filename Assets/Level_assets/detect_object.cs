using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect_object : MonoBehaviour {

    


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == tag)
        {
            Destroy(col.gameObject);
            Scorecounter.updateScore(1);

                

            
           

        }
        if (col.gameObject.tag != tag)
        {
            Destroy(col.gameObject);
            Scorecounter.updateScore(-1);
        }
    }
}
