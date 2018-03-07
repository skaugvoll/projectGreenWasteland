using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour {

    private bool isPaused;

    private GameObject pauseOverlay;


    private float gameDuration = 30 *1000;  // Time in milliseconds
    private float timeElapsed;
    private bool haltUpdate = false;

	// Use this for initialization
	void Start () {
        timeElapsed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (haltUpdate) return;

        timeElapsed += Time.deltaTime * 1000;
        setTimerText("" + (int)(gameDuration - timeElapsed)/1000);


        if(timeElapsed >= gameDuration)
        {
            // Terminate game
            haltUpdate = true;
            Time.timeScale = 0; //temp
            GameObject.Find("PauseButton").GetComponent<Button>().interactable = false; // Disable UI buttons
            Add_scene("ResultScene");
        }


    }


    public void setTimerText(string text)
    {
        GameObject.Find("CountdownText").GetComponent<Text>().text = text;
    }


    public void pauseGame()
    {
        if (isPaused) return;

        isPaused = true;
        Time.timeScale = 0;
        Vector2 position = new Vector2(95.62f, 203.59f);
        pauseOverlay = (GameObject) Instantiate(Resources.Load("PauseOverlay"), position, Quaternion.identity);
        pauseOverlay.transform.parent = GameObject.Find("Canvas").transform;
        GameObject.Find("Resume").GetComponent<Button>().onClick.AddListener(() => onResumeButton());
        GameObject.Find("Quit").GetComponent<Button>().onClick.AddListener(() => onQuitButton());
        // ADD overlay
    }

    public void resumeGame()
    {
        //Remove overlay
        isPaused = false;
        Destroy(pauseOverlay);
        Time.timeScale = 1;


    }

    /** Load a new scene, while unloading all open scenes.
     * 
     **/
    public void Change_scene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    /** Load an additional scene.
     * 
     * */
    public void Add_scene(string scene)
    {
        SceneManager.LoadScene("ResultScene", LoadSceneMode.Additive);
    }


    public void onResumeButton()
    {
        print("ONRESUME");
        Time.timeScale = 1;
        isPaused = false;
        Destroy(pauseOverlay);
    }

    public void onQuitButton()
    {
        Time.timeScale = 1;
        print("QUIT");
        Change_scene("overworld");
    }

}
