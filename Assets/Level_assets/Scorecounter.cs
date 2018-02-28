using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorecounter : MonoBehaviour
{
    
    private int count;
    private int score;

    // Use this for initialization
    void Start()
    {

        count = 0;
        score = 0;
    }

    public void updateScore(int score) {
        count += score;
        GameObject.Find("ScoreText").GetComponent<Text>().text = count + "";

    }

    
}