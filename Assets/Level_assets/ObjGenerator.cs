using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjGenerator : MonoBehaviour {

    public GameObject equipPrefab;

    public List<GameObject> createdObjects = new List<GameObject>();


    private float minY = 207.78f;
    private float maxY = 207.33f;
    private float minX = 92.39f;
    private float maxX = 99.29f;



    // Use this for initialization
    void Start () {
        equipPrefab = GameObject.Find("FallingObject");
        CreateObject();
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void CreateObject()
    {
        // a prefab is need to perform the instantiation
        if (equipPrefab != null)
        {
            print("Creating object");
            // get a random postion to instantiate the prefab - you can change this to be created at a fied point if desired
            Vector3 position = new Vector3(Random.Range(minX + 0.5f, maxX - 0.5f), Random.Range(minY + 0.5f, maxY - 0.5f));

            // instantiate the object
            GameObject go = (GameObject)Instantiate(equipPrefab, position, Quaternion.identity);
            createdObjects.Add(go);
        }
    }


}
