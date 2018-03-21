using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStats : MonoBehaviour {

    public int rating1 = 5;
    public int rating2 = 20;
    public int rating3 = 25;


    public void Start()
    {
        Scorecounter.setRatingRequirements(rating1, rating2, rating3);
    }

}
