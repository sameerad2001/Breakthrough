using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
	void Awake(){
		// The delete save button is only for testing the application
		#if !UNITY_EDITOR
			GameObject.Find("Canvas/Delete Button").SetActive(false);
		#endif
	}

    public void StartGame(){
        // Scenes
		// 0 : Start menu
		// 1 : game
		SceneManager.LoadScene(1);
    }

    public void QuitGame(){
        // When testing the application in the editor
		#if UNITY_EDITOR
			EditorApplication.ExitPlaymode();
		
		// When using a built application
		#else
			Application.Quit();
		
		#endif
    }
}
