using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class ItemDisplayComponent : MonoBehaviour
{
    public TextMeshProUGUI nameText; 
    public TextMeshProUGUI baseText;
    public Image itemBackground; 
    public GameObject modRoot;
    public GameObject modifierPrefab; 
    [Space]
    public Color commonColor;
    public Color rareColor;
    public Color epicColor;
    public Color legendaryColor;

    public void Init(ItemInstance _item)
    {
        nameText.text = _item.itemName;
        baseText.text = "Base : " + _item.itemBaseSO.itemBase.baseName;
        
        switch (_item.itemRarity)
        {
            case ItemInstance.ItemRarity.COMMON:
                itemBackground.color = commonColor;
                break;
            case ItemInstance.ItemRarity.RARE:
                itemBackground.color = rareColor;
                break;
            case ItemInstance.ItemRarity.EPIC:
                itemBackground.color = epicColor;
                break;
            case ItemInstance.ItemRarity.LEGENDARY:
                itemBackground.color = legendaryColor;
                break;
            default:
                break;
        }

        for (int i = 0; i < _item.modifiers.Count; i++)
        {
            GameObject temp = Instantiate(modifierPrefab, modRoot.transform);

            string percent = string.Empty;
            if (_item.modifiers[i].modeType == Modifier.ModeType.PERCENT)
                percent = "%";

            temp.transform.GetComponent<TextMeshProUGUI>().text = _item.modifiers[i].mode.ToString() + " " + _item.modifiers[i].ModifierValue + " " + percent + " " + _item.modifiers[i].statSO.stat.statName; 
        }
    }
}
