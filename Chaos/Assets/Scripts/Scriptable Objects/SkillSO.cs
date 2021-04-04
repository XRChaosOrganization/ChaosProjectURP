using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill_", menuName = "Data/Skill/Skill", order = 0)]
public class SkillSO : ScriptableObject
{
    public SkillInstance skill;
}

[System.Serializable]
public class SkillInstance : SkillBase
{
    //Metadata (name desc, sprite)
    //verb = damage / heal / damage overtime 
    //Targetting 
    //UI

    public string baseName;
    public string desc;
    public Sprite baseIcon;
    
    public float cooldown;

    public string animKey;
    public float targetingRadius;
    
    public enum SkillSlot { ATTACK, SPECIAL, MAGIC};
    public SkillSlot skillSlot; 
    public enum SKillType { ACTIVE, PASSIVE};
    public SKillType sKillType;
    public enum CastType { INSTANT, CHARGED, CHANNELED};
    public CastType castType;
    public enum ActivationType { OnSurface, Ranged, OnActor, OnActorSelf, Melee };
    public ActivationType activationType;

    [Range(0.0f, 1.0f)]
    public float commitment; 

    [System.Serializable]
    public struct SourceWrapper
    {
        public SourceSO source;
        public Vector2 amount;
    }

    public SourceWrapper source;
}

//skillVerbSO
//nom
