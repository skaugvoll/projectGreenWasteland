using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour {


    public void Resume()
    {
        Time.timeScale = 1;
        FindObjectOfType<DataController>().isPaused = false;
        SceneManager.UnloadScene("PauseScene");
    }


    public void Quit()
    {
        Time.timeScale = 1;
        FindObjectOfType<DataController>().isPaused = false;
        SceneManager.LoadScene("overworld");
    }


}
