using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; 
using ChaosEditor; 

[CreateAssetMenu(fileName = "ItemBase_", menuName = "Data/RPG/Item Base", order = 2)]
[System.Serializable]
public class ItemBaseSO : ScriptableObject
{
    public ItemBase itemBase; 
}

[System.Serializable]
public class ItemBase
{
    public enum ItemType {ARMOR, WEAPON, BONUS};
    public enum ItemSlot {AMULET, BODY, BONUS, BOOTS, HEAD, MAINHAND, OFFHAND, TWOHANDED};
    
    public string baseName; 
    [Space]
    public ItemType itemType; 
    public ItemSlot itemSlot;
    [Space]
    public Sprite baseIcon;
    public Sprite baseSprite; 
    [Space]
    public ItemModifiersGridSO modifiersGrid; 
    [Space]
    public bool isStackable = false; 
    public bool isConsumable = false; 

    [System.Serializable]
    public struct Weapon
    {
        public enum WeaponAnimType { ONEHANDED_ATTACK, ONEHANDED_BLOCK, TWOHANDED_ATTACK, TWOHANDED_BLOCK, DUALWIELD_ATTACK, DUALWIELD_BLOCK};
        public WeaponAnimType weaponAnimType; 
    }

    [Header("Weapon")]
    public bool isWeapon = false;

    [ConditionalHide("isWeapon", true)]
    public Weapon weapon; 
}