using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill_", menuName = "Data/RPG/Skill", order = 3)]
public class SkillSO : ScriptableObject
{
    public Skill skill;
}

[System.Serializable]
public class Skill
{
    //Metadata (name desc, sprite)
    //verb = damage / heal / damage overtime 
    //Targetting 
    //UI

    #region Properties
    public string baseName;
    public Sprite baseIcon;
    public bool joystick;
    public float cooldown;
    public float targetingRadius;

    #endregion


    #region Go or components
    #endregion

    #region Variables
    #endregion

    #region Methods

    public void UseSkill()
    {

    }


    #endregion
}

//skillVerbSO
//nom
