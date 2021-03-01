using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LootGeneratorManager : MonoBehaviour
{
    public GameObject scrollViewContent; 
    public GameObject itemInventoryDisplayPrefab; 
    public TMP_Dropdown dropDownBases;
    public TMP_InputField inputFieldQty; 
    [Space]
    public List<ItemBaseSO> itemBases; 
    public List<ItemInstance> generatedLoot;
    private int lootQuantity = 0;
    
    private void Start() 
    {
        for (int i = 0; i < itemBases.Count; i++)
        {
            dropDownBases.options.Add(new TMP_Dropdown.OptionData(itemBases[i].name));
        }    
    }

    public void GenerateLoot ()
    {
        int qty = lootQuantity;

        ClearInventory();
        Debug.Log("Now generating from base : " + dropDownBases.value + itemBases[dropDownBases.value] + " quantity : " + lootQuantity);

        for (int i = 0; i < lootQuantity; i++)
        {
            generatedLoot.Add(new ItemInstance(itemBases[dropDownBases.value]));
            GameObject temp = Instantiate(itemInventoryDisplayPrefab, scrollViewContent.transform);
            temp.GetComponent<ItemDisplayComponent>().Init(generatedLoot[i]);
        }
    }

    private void ClearInventory()
    {
        generatedLoot.Clear();

        foreach (Transform item in scrollViewContent.transform)
        {
            Destroy(item.transform.gameObject);
        }
    }

    public void UpdateNumberOfLoot ()
    {
        if(string.IsNullOrEmpty(inputFieldQty.text) == true) return; 
        
        lootQuantity = int.Parse(inputFieldQty.text);
    }
}

