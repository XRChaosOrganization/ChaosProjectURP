using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventoryComponent : MonoBehaviour
{
    public List<ItemSO> baseItems; 
    [SerializeField] private List<ItemInstance> itemInstances; 

    public void InitCharacterItems ()
    {
        for (int i = 0; i < baseItems.Count; i++)
        {
            itemInstances.Add(new ItemInstance(baseItems[i]));
        }
    }

    public List<ItemInstance> GetItems ()
    {
        return itemInstances; 
    }
}
