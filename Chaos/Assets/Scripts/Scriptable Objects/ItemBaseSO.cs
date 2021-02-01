using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/RPG/Item Base", order = 2)]
[System.Serializable]
public class ItemBaseSO : ScriptableObject
{
    public ItemBase itemBase; 
}

[System.Serializable]
public class ItemBase
{
    public enum ItemSlot {AMULET, HEAD, BODY, BOOTS, MAINHAND, OFFHAND, TWOHANDED};
    public ItemSlot itemSlot;
    public string baseName; 
    public Sprite baseIcon;
    public Sprite baseSprite; 
    public int maximumNumberOfMods; 
    public List<Modifier> baseMods; 
    public bool isStackable = false; 
    public bool isConsumable = false; 
}
