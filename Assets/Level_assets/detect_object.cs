using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect_object : MonoBehaviour {


    private GameObject feedback;

    public void Start()
    {
        for(int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            if(this.gameObject.transform.GetChild(i).name == "ParticleFeedback")
            {
                feedback = this.gameObject.transform.GetChild(i).gameObject;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == tag)
        {
            Destroy(col.gameObject);
            feedback.GetComponent<ScoreFeedback>().correct();
            Scorecounter.updateScore(1);

                

            
           

        }
        if (col.gameObject.tag != tag)
        {
            Destroy(col.gameObject);
            feedback.GetComponent<ScoreFeedback>().incorrect();
            Scorecounter.updateScore(-1);
        }
    }
}
