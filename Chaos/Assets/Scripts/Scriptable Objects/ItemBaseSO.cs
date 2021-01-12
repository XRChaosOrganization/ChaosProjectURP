using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/RPG/Item Base", order = 2)]
public class ItemBaseSO : ScriptableObject
{
    public ItemBase itemBase; 
}

[System.Serializable]
public class ItemBase
{
    public string baseName; 
    public Sprite baseIcon;
    public int maximumNumberOfMods; 
    public List<Modifier> baseMods; 
}
