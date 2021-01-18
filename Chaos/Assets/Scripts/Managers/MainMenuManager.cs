using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance; 
    public GameObject mainMenu;
    public Button newRunButton; 

    private void Awake() 
    {
        Instance = this; 
        newRunButton.onClick.AddListener(() => GameSceneManager.Instance.LoadGameScene("Scene_CharacterCreation"));
    }

    //private void OnEnable() 
    //{
    //    SceneManager.sceneLoaded += OnSceneLoaded;    
    //}
    private void Update() {
        if(GameSceneManager.Instance.activeScene == "Scene_MainMenu")
            mainMenu.SetActive(true);
        else
            mainMenu.SetActive(false);

    }
    //private void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
    //{
    //    if(scene.name != "MainMenu")
    //    else 
    //}

    //private void OnDisable() 
    //{
    //    SceneManager.sceneLoaded -= OnSceneLoaded;    
    //}
}
