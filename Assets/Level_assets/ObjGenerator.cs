using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjGenerator : MonoBehaviour {

    private GameObject equipPrefab;

    public List<GameObject> createdObjects = new List<GameObject>();

    private string[] tags = { "Plast", "Elektrisk", "Papp" };


    private float minY = 207.78f;
    private float maxY = 207.33f;
    private float minX = 92.39f;
    private float maxX = 99.29f;

    // In milliseconds
    private float maxTime = 1500;
    private float minTime = 500;
    private float nextCreation;
    private float timeElapsed = 0;

    private bool generateObjects = true;


    // Use this for initialization
    void Start () {
        nextCreation = Time.time * 1000 + Random.Range(minTime, maxTime);
	}
	
	// Update is called once per frame
	void Update () {
        if (!generateObjects)
            return;
        timeElapsed += Time.deltaTime * 1000;
        if(timeElapsed >= nextCreation)
        {
            
            CreateObject(tags[(int)Random.Range(0, tags.Length)], (int)Random.Range(1, 4));
            timeElapsed = 0;
            nextCreation = Random.Range(minTime, maxTime);
        }
        
	}



    public void CreateObject(string tag, int num) { 
            // a prefab is need to perform the instantiation

            // get a random postion to instantiate the prefab - you can change this to be created at a fied point if desired
            Vector3 position = new Vector3(Random.Range(minX + 0.5f, maxX - 0.5f), Random.Range(minY + 0.5f, maxY - 0.5f));

        // instantiate the object
        GameObject go = (GameObject)Instantiate(Resources.Load(tag + num), position, Quaternion.identity);
        go.tag = tag.ToLower();
        createdObjects.Add(go);
        

    }


}
