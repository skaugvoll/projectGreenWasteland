using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverworldController : MonoBehaviour {

    private DataController dataController;
    private int energy;

	// Use this for initialization
	void Start () {
        dataController = FindObjectOfType<DataController>();
        energy = dataController.getEnergy();
        GameObject.Find("EnergyAmount").GetComponent<Text>().text = energy + "";

        for (int i = 1; i <= dataController.getLatestUnlockedStage()+1; i++)
        {
            GameObject levelButton = GameObject.Find("Button" + i);
            if (i <= 7)
                levelButton.GetComponent<Button>().interactable = true;
        }

        int j = dataController.getLatestUnlockedStage()+1;
        if (j <= 7)
        {
            ParticleSystem ps = GameObject.Find("levelGlow" + j).GetComponent<ParticleSystem>();
            ps.Play();
        }

        FindObjectOfType<DataController>().SaveGameData();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
