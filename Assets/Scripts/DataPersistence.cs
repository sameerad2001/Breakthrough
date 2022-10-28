using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class DataPersistence : MonoBehaviour
{
    // For singleton :
    public static DataPersistence Instance;
    
    GameObject userNameInputField; 
	public TextMeshProUGUI scoreText;  

    // Persistent Data :
    public string userName;
    public string highScorer;
    public int bestScore;

    // Save data_________________________________
	[System.Serializable]
	class SaveData
	{
        public string highScorer;
        public int bestScore;
	};

    void Awake()
    {
        // Only if the menu scene is loaded
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
       
        if (sceneName == "Start Menu"){
            userNameInputField = GameObject.Find("User Name Input Field");
            scoreText = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
        }

        // Singleton :
        if (Instance != null){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadSaveData();
    }

    public void GetUserName(){
        userName = userNameInputField.GetComponent<TMP_InputField>().text;
    }

    public void SaveCurrentData(){
        SaveData data = new SaveData();

		data.highScorer = highScorer;
        data.bestScore = bestScore;

		string jsonSaveData = JsonUtility.ToJson(data);

		File.WriteAllText(Application.persistentDataPath + "/saveFile.json", jsonSaveData);
    }

    public void DeleteSaveDate(){
        SaveData data = new SaveData();

		data.highScorer = "";
        data.bestScore = 0;

		string jsonSaveData = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", jsonSaveData);
        LoadSaveData();
    }

    public void LoadSaveData(){
        string path = Application.persistentDataPath + "/savefile.json";

		if (File.Exists(path))
		{
			string json = File.ReadAllText(path);
			SaveData data = JsonUtility.FromJson<SaveData>(json);

			highScorer = data.highScorer;
            bestScore = data.bestScore;

            if (bestScore != 0)
                scoreText.text = "Best Score : " + highScorer + " - " + bestScore;
            else
                scoreText.text = "No high scores!";
		}
        else 
            scoreText.text = "No high scores!";
    }    

    public void UpdateHighScorer(int newScore){
        highScorer = userName;
        bestScore = newScore;

        SaveCurrentData();
    }
}
