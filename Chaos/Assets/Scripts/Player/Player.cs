using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Alex : Pour les skills ont fera un SkillComponent
public class Player : MonoBehaviour
{
    public Transform targetingOrigin;

    [Header("Skills")] //Skill component ? 
    public SkillSO skill1;
    public SkillSO skill2;
    public SkillSO skill3;

    private void Start() 
    {
        GetComponent<CharacterRPGComponent>().InitRPGComponent();
    }

    public void ReceiveHit ()
    {
        print("received hit !");
    }
}
