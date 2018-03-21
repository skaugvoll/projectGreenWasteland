using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_controller : MonoBehaviour {


    void Start()
    {
        Screen.SetResolution((int)Screen.width, (int)Screen.height, true);
    }


    public void Change_scene(string scene)
    {
        SceneManager.LoadScene(scene);
    }




}
