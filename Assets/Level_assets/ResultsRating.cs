using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class ResultsRating : MonoBehaviour {


    public void Start()
    {
        setRating(Scorecounter.getScore(), Scorecounter.getRating());
    }


    public void setRating(int score, int rating)
    {
        GameObject.Find("NumericScore").GetComponent<Text>().text = score + "";

        if (rating >= 1)
            GameObject.Find("R1").GetComponent<Image>().enabled = true;
        if (rating >= 2)
            GameObject.Find("R2").GetComponent<Image>().enabled = true;
        if (rating == 3)
            GameObject.Find("R3").GetComponent<Image>().enabled = true;


        FindObjectOfType<DataController>().addEnergy(rating);
        string numbers = Regex.Replace(SceneManager.GetActiveScene().name, "[^0-9]", "");
    

        int latestLvl = int.Parse(numbers);
        print(latestLvl + ": rating " + rating);
        if (rating >= 1)
        {
            bool newStageUnlocked = FindObjectOfType<DataController>().completedLevel(latestLvl); // request highest stage, and set if it is
            if (newStageUnlocked && rating >= 1)
            {
                GameObject.Find("NewStageUnlocked").GetComponent<Text>().enabled = true;
            }
        }

    }


}
