using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class SceneNodeComponent : StateMachineBehaviour
{
    public SceneAsset sceneToLoad; 

    [Header("On Enter")]
    public bool loadOnEnter = false; 

    [Header("On Exit")]
    public bool unloadOnExit = false; 

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(loadOnEnter == true &&  sceneToLoad != null)
        {
            //Load scene
            if(SceneManager.GetSceneByName(sceneToLoad.name).isLoaded == false)
            {
                SceneManager.LoadScene(sceneToLoad.name, LoadSceneMode.Additive);
                //GameSceneManager.Instance.ToggleLoadingScreen(true);
            }
        } 
    }

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(unloadOnExit == true && sceneToLoad != null) 
        {
            //Unload scene
            if(SceneManager.GetSceneByName(sceneToLoad.name).isLoaded == true)
                SceneManager.UnloadSceneAsync(sceneToLoad.name);
        }
    }

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    //override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    //override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    //{
    //    Debug.Log("EXIT STATE MACHINE");
    //}
}
