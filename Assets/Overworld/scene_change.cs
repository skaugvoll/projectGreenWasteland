using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scene_change : MonoBehaviour {

    private bool touch_down = false;
    public Button thisButton;

    // Use this for initialization
    void Start () {
        print("init");
        Button btn = thisButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }
	
	// Update is called once per frame
	void Update () {
        print("test");
        if (Input.touchCount > 0)
        {
            print("some touch");

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touch_down = true;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if(touch_down)
                {
                    SceneManager.LoadScene("Level1", LoadSceneMode.Single);
                }
                touch_down = false;
            }
        }
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }
}
