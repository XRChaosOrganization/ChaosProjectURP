using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Alex : Pour les skills ont fera un SkillComponent
public class Player : MonoBehaviour
{
    public Transform targetingOrigin;

    private void Start() 
    {
        GetComponent<CharacterRPGComponent>().InitRPGComponent();
    }

    public void ReceiveHit ()
    {
        print("received hit !");
    }
}
