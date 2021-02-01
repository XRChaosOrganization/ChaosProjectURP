using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventoryComponent : MonoBehaviour
{
    public List<ItemSO> unequippedItems; 
    public List<ItemSO> equippedItems; 
    
    [SerializeField] private List<ItemInstance> itemInstances; //Only equipped items 

    public void UpdateEquippedItemInstances ()
    {
        for (int i = 0; i < equippedItems.Count; i++)
        {
            itemInstances.Add(new ItemInstance(equippedItems[i]));
        }
    }

    public List<ItemInstance> GetItems ()
    {
        return itemInstances; 
    }
}
