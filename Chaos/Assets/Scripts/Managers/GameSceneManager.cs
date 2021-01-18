using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance; 

    public Animator animator; 

    [Header("Loading")]
    public GameObject loadingCanvas; 

    [Header("Macro Scenes")]
    public SceneAsset mainMenuScene; 
    public SceneAsset gameScene; 
    
    [Header("Debug")]
    public bool startWithSpecificScene = false;
    public SceneAsset sceneToForce;
    public string activeScene; 

    private void Awake() 
    {
        Instance = this;
    }

    private void OnEnable() 
    {
        SceneManager.sceneLoaded += OnSceneLoaded;    
        SceneManager.sceneUnloaded += OnSceneUnLoaded;    
    }

    private void Start() 
    {
        //if(startWithSpecificScene)
            //SceneManager.LoadSceneAsync(star)
    }

    private void Update() 
    {
        activeScene = SceneManager.GetActiveScene().name;
    }

    public void ToggleLoadingScreen(bool _toggle)
    {
        loadingCanvas.SetActive(_toggle);
    }
    
    public void LoadGameScene (string _sceneName)
    {
        animator.SetBool("Bool_" + _sceneName, true);
    }

    public void StartRun ()
    {
        animator.SetTrigger("Trigger_LaunchRun");
    }

    //EVENTS 
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
    {
        SceneManager.SetActiveScene(scene);
    }

    private void OnSceneUnLoaded(Scene scene) 
    {
        if(scene.name == "Scene_MainMenu" || scene.name == "Scene_Game") return;

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if(SceneManager.GetSceneAt(i).name == "Scene_MainMenu" || SceneManager.GetSceneAt(i).name == "Scene_Game")
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneAt(i));
            }
        }
    }

    //Un subscribe from events
    private void OnDisable() 
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;    
        SceneManager.sceneUnloaded -= OnSceneUnLoaded;   
    }


}