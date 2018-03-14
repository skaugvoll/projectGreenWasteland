using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/**
 * Big thanks to unity tutorial at https://unity3d.com/learn/tutorials/topics/scripting/high-score-playerprefs
 * 
 * 
 * */
public class DataController : MonoBehaviour {


    private PlayerData playerData;
    private string gameDataFileName = "data.json"; // 
    private string gameDataProjectFilePath = "/StreamingAssets/data.json";


    // Use this for initialization
    void Start () {


        LoadGameData();

        //LoadPlayerProgress();
        DontDestroyOnLoad(this);
        SceneManager.LoadScene("overworld");
        SaveGameData();


    }



    private void LoadGameData()
    {
        // Path.Combine combines strings into a file path
        // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
        if (File.Exists(filePath))
        {
            print("Found file");
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            playerData = JsonUtility.FromJson<PlayerData>(dataAsJson);
            
            // Retrieve the allRoundData property of loadedData
           // allRoundData = loadedData.allRoundData;
        }
        else
        {
            Debug.Log("Cannot load game data! Creating new File");
            playerData = new PlayerData();
            SavePlayerData();
            SaveGameData();
        }
    }


    private void LoadPlayerProgress()
    {
        playerData = new PlayerData();
        // If PlayerPrefs contains a key called "energyReceivedTotal", 
        //    set the value of playerProgress.energyReceivedTotal using the value associated with that key
        if (PlayerPrefs.HasKey("energyReceivedTotal"))
        {
            playerData.energyReceivedTotal = PlayerPrefs.GetInt("energyReceivedTotal");
        }
        if (PlayerPrefs.HasKey("lastUnlockedStage"))
        {
            playerData.lastUnlockedStage = PlayerPrefs.GetInt("lastUnlockedStage");
        }
        if (PlayerPrefs.HasKey("energy"))
        { 
            playerData.energy = PlayerPrefs.GetInt("energy");
            print("INDEED: " + playerData.energy);
        }

    }

    private void SavePlayerData()
    {
        // Save the value playerProgress.highestScore to PlayerPrefs, with a key of "highestScore"
        PlayerPrefs.SetInt("energyReceivedTotal", playerData.energyReceivedTotal);
        PlayerPrefs.SetInt("lastUnlockedStage", playerData.lastUnlockedStage);
        PlayerPrefs.SetInt("energy", playerData.energy);
    }

    private void SaveGameData()
    {

        string dataAsJson = JsonUtility.ToJson(playerData);

        string filePath = Application.dataPath + gameDataProjectFilePath;
        File.WriteAllText(filePath, dataAsJson);

    }


    public int getEnergy()
    {
        return playerData.energy;
    }

    public int getLatestUnlockedStage()
    {
        return playerData.lastUnlockedStage;
    }

    public void addEnergy(int energy)
    {
        playerData.energy += energy;
    }

    public void completedLevel(int level)
    {
        if(level >= playerData.lastUnlockedStage)    // Only increase latest if u reached a later level than recorded
            playerData.lastUnlockedStage = level+1;
    }


}
