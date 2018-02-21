using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour {

    private float aspect_ratio =  Screen.width / Screen.height;

	// Use this for initialization
	void Start () {
        Camera.main.projectionMatrix = Matrix4x4.Ortho(0 * aspect_ratio, 10f * aspect_ratio, 0f, 5.5f, 0.3f, 1000f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
