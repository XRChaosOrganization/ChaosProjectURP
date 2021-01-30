using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDetectionComponent : MonoBehaviour
{
    private NPCBehaviorComponent nPC; 
    
    private void Awake() 
    {
        nPC = GetComponentInParent<NPCBehaviorComponent>();    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            nPC.player = other.GetComponent<Player>();
            nPC.animator.SetBool("Bool_IsSeeingPlayer", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            nPC.animator.SetBool("Bool_IsSeeingPlayer", false);
            nPC.player = null;
        }
    }
}
