using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {

    private bool isPaused;

    private GameObject pauseOverlay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void pauseGame()
    {
        if (isPaused) return;

        isPaused = true;
        Time.timeScale = 0;
        Vector2 position = new Vector2(95.62f, 203.59f);
        pauseOverlay = (GameObject) Instantiate(Resources.Load("PauseOverlay"), position, Quaternion.identity);
        pauseOverlay.transform.parent = GameObject.Find("Canvas").transform;
        // ADD overlay
    }

    public void resumeGame()
    {
        //Remove overlay
        isPaused = false;
        Destroy(pauseOverlay);
        Time.timeScale = 1;


    }


    public void Change_scene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

}
