using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_controller : MonoBehaviour {

    public void Change_scene(string scene)
    { 
        SceneManager.LoadScene(scene);
    }


}
