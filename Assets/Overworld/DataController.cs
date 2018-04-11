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


    public bool isPaused = false;

    private PlayerData playerData;
    private string gameDataFileName = "data.json"; // 
    private string gameDataProjectFilePath = "/StreamingAssets/data.json";

    private string fileName = "data.json";


    // Use this for initialization
    void Start () {

        
        LoadGameData();

        //LoadPlayerProgress();
        DontDestroyOnLoad(this);
        SceneManager.LoadScene("overworld");
        


    }



    private void LoadGameData()
    {
        Debug.Log("Initializing loading sequence");
        // Path.Combine combines strings into a file path
        // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build

#if UNITY_EDITOR
        Debug.Log("Played from editor");
#elif UNITY_ANDROID
        Debug.Log("Playing on android");
#else
        Debug.Log("Not editor or android");
#endif
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
        if (File.Exists(filePath))
        {
            Debug.Log("Found save-file");
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            playerData = JsonUtility.FromJson<PlayerData>(dataAsJson);

            // Retrieve the allRoundData property of loadedData
            // allRoundData = loadedData.allRoundData;
            Debug.Log("Playerdata successfully loaded");
        }
        else
        {
            Debug.Log("Cannot load game data! Creating new File");
            playerData = new PlayerData();
            Debug.Log("new PlayerData object intialized");
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
            playerData.lastCleared = PlayerPrefs.GetInt("lastUnlockedStage");
        }
        if (PlayerPrefs.HasKey("energy"))
        { 
            playerData.energy = PlayerPrefs.GetInt("energy");
            print("INDEED: " + playerData.energy);
        }
        if (PlayerPrefs.HasKey("first_time"))
        {
            playerData.firstTimePlaying = PlayerPrefs.GetString("first_time");
        }

    }

    private void SavePlayerData()
    {
        // Save the value playerProgress.highestScore to PlayerPrefs, with a key of "highestScore"
        Debug.Log("Putting values in playerprefs: SavePlayerData()");
        PlayerPrefs.SetInt("energyReceivedTotal", playerData.energyReceivedTotal);
        PlayerPrefs.SetInt("lastUnlockedStage", playerData.lastCleared);
        PlayerPrefs.SetInt("energy", playerData.energy);
        PlayerPrefs.SetString("first_time", playerData.firstTimePlaying);
        Debug.Log("All values put in playerprefs");
    }

    public void SaveGameData()
    {
        Debug.Log("SaveGameData(): Converting PlayerPrefs to JSON");
        string dataAsJson = JsonUtility.ToJson(playerData);

#if UNITY_EDITOR
        Debug.Log("Played from editor");
        string filePath = Application.dataPath + gameDataProjectFilePath;
#elif UNITY_ANDROID
        Debug.Log("Writing save on android");
        //string filePath = Path.Combine ("jar:file://" + Application.dataPath + "!assets/", fileName);

       // string folderPath = (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer ? Application.persistentDataPath : Application.dataPath) + "/StreamingAssets/";
        string filePath = Application.persistentDataPath + "\\" + fileName;

        




#else
        Debug.Log("Save on Not editor or android");
        string filePath = Application.dataPath + gameDataProjectFilePath;
#endif






        Debug.Log("SaveGameData(): filePath = " + filePath);

        File.WriteAllText(filePath, dataAsJson);
        
        Debug.Log("SaveGameData(): File successfully written");
    }


    public int getEnergy()
    {
        return playerData.energy;
    }

    public int getLatestUnlockedStage()
    {
        return playerData.lastCleared;
    }

    public void addEnergy(int energy)
    {
        playerData.energy += energy;
    }


    public void read_tutorial()
    {
        playerData.firstTimePlaying = "n";
    }

    public bool isFirstTime()
    {
        Debug.Log("First time playing");
        return playerData.firstTimePlaying.Equals("y");
    }

    public bool completedLevel(int level)
    {
        if (level > playerData.lastCleared)
        {    // Only increase latest if u reached a later level than recorded
            Debug.Log("lagrer lastCleared");
            playerData.lastCleared = level;
            return true;
        }
        return false;
    }


}
