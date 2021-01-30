using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCBase
{
    [Header("RPG")]
    public string npcName = "NPC_NoName"; 
    public int baseLife = 10;
    public int baseXp = 10;

    [Header("Sprite")]
    public Sprite NPCSprite; 

    [Header("Behavior Settings")]
    [Range(5f, 30f)] public float npcDetectionRadius; 
    [Range(3f, 30f)] public float verticalLoseDistance = 3.5f; 
    public float timeBeforeEnteringCombat = 1.0f;

    [Space]
    [Range(1.9f, 30f)] public float npcAttackRange; 
    [Tooltip("Attack Rate in seconds.")] public float npcAttackRate = 6.5f; 

    [Space]
    [Tooltip("Block Rate in seconds.")] public float npcBlockRate = 12f; 

    [Space]
    public Vector2 minMaxMovementSpeed; 

    [Header("Skills")]
    public SkillSO skill; 
}
