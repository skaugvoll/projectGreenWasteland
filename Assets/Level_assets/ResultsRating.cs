using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsRating : MonoBehaviour {


    public void Start()
    {
        setRating(Scorecounter.getScore(), Scorecounter.getRating());
    }


    public void setRating(int score, int rating)
    {
        GameObject.Find("NumericScore").GetComponent<Text>().text = score + "";

        if (rating >= 1)
            GameObject.Find("R1").GetComponent<Text>().enabled = true;
        if (rating >= 2)
            GameObject.Find("R2").GetComponent<Text>().enabled = true;
        if (rating == 3)
            GameObject.Find("R3").GetComponent<Text>().enabled = true;


    }


}
