﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Scorecounter 
{

    private static int rating1 = 5;
    private static int rating2 = 20;
    private static int rating3 = 25;


    private static int count = 0;
    private static int score = 0;


    public static void updateScore(int s) {
        Debug.Log("Score + " + s + " for a total of " + score + " points");
        score += s;
        GameObject.Find("ScoreText").GetComponent<Text>().text = score + "";

    }

    public static int getScore()
    {
        Debug.Log("Score: " + score);
        return score;
    }

    public static int getRating()
    {
        if (score >= rating1) {
            if (score >= rating2) {
                if (score >= rating3) {
                    return 3;
                }
                return 2;
            }
            return 1;
        }
        return 0;
    }

    public static void reset()
    {
        count = 0;
        score = 0;
    }

}