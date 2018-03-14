using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour {

    private bool isPaused;

    private GameObject pauseOverlay;


    public float gameDuration = 10 *1000;  // Time in milliseconds
    private float timeElapsed;
    private bool haltUpdate = false;

	// Use this for initialization
	void Start () {
        timeElapsed = 0;
        Time.timeScale = 1;
        Scorecounter.reset();
	}
	
	// Update is called once per frame
	void Update () {
        if (haltUpdate) return;

        timeElapsed += Time.deltaTime * 1000;
        GameObject.Find("Radial").GetComponent<Image>().fillAmount = 1 - timeElapsed/gameDuration;
        setTimerText("" + (int)(gameDuration - timeElapsed)/1000);


        if(timeElapsed >= gameDuration)
        {
            // Terminate game
            haltUpdate = true;
            Time.timeScale = 0; //temp
            GameObject.Find("PauseButton").GetComponent<Button>().interactable = false; // Disable UI buttons
            Add_scene("ResultScene");

            // Calculate score
            int rating = Scorecounter.getRating();
            int score = Scorecounter.getScore();

            GameObject[] goa = SceneManager.GetSceneByName("ResultScene").GetRootGameObjects();
            foreach(GameObject go in goa)
            {
                print("test");
                if(go.name == "ResultsCanvas")
                {
                    print("HYPE");
                    go.GetComponent<ResultsRating>().setRating(score, rating);
                }
            }
            
            
        }


    }
    

    public void setTimerText(string text)
    {
        GameObject.Find("CountdownText").GetComponent<Text>().text = text;
    }


    public void pauseGame()
    {
        if (FindObjectOfType<DataController>().isPaused) return;

        FindObjectOfType<DataController>().isPaused = true;
        Time.timeScale = 0;
        Vector2 position = new Vector2(95.62f, 203.59f);

        SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);

        /**pauseOverlay = (GameObject) Instantiate(Resources.Load("PauseOverlay"), position, Quaternion.identity);
        pauseOverlay.transform.parent = GameObject.Find("Canvas").transform;
        
        Button b = GameObject.Find("Resume").GetComponent<Button>();
        b.onClick.AddListener(() => onResumeButton());
        GameObject.Find("Quit").GetComponent<Button>().onClick.AddListener(() => onQuitButton());
        // ADD overlay 
        */
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
