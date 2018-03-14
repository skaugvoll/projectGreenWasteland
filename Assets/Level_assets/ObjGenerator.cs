using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjGenerator : MonoBehaviour {

    private GameObject equipPrefab;

    public List<GameObject> createdObjects = new List<GameObject>();

    public string[] tags = { "Plast", "Papp", "Elektrisk", "mat" };
    

    private float minY = 207.78f;
    private float maxY = 207.33f;
    private float minX = 92.39f;
    private float maxX = 99.29f;

    // In milliseconds
    public float maxTime = 1500;
    public float minTime = 500;
    private float nextCreation;
    public float timeElapsed = 0;

    private bool generateObjects = true;



    // Use this for initialization
    void Start () {
        // Generated bounds within shape
        Transform t = GetComponent<Transform>();
        SpriteRenderer r = GetComponent<SpriteRenderer>();
        minY = t.position.y;
        minX = t.position.x;
        maxX = minX + r.bounds.size.x;
        maxY = minY + r.bounds.size.y;
        generateObjects = true;

        nextCreation = Random.Range(minTime, maxTime);
        print("nextCreation: " + nextCreation);
	}
	
	// Update is called once per frame
	void Update () {
        timeElapsed += Time.deltaTime * 1000;
        if (!generateObjects)
            return;
        if(timeElapsed >= nextCreation) {
            print("timelapsed >= nextCreation");
            print(tags.Length);
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
        print("Created an object");
        

    }


}
