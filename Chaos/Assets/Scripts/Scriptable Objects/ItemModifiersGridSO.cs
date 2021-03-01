using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemModGrid_", menuName = "Data/RPG/Item Modfifiers Grid", order = 5)]
public class ItemModifiersGridSO : ScriptableObject 
{
    public List<Modifier> baseMods; 
    public List<Modifier> commonMods; 
    public List<Modifier> rareMods; 
    public List<Modifier> epicMods; 
    public List<Modifier> legendaryMods;

    public List<Modifier> GetRandomMods (ItemInstance.ItemRarity _rarity, int _commonMods = 1, int _rareMods = 1, int _epicMods = 1, int _legendaryMods = 1)
    {
        List<Modifier> mods = new List<Modifier>();

        //Add our base mods 
        for (int i = 0; i < baseMods.Count; i++)
        {
            mods.Add(baseMods[i]);
        }

        switch (_rarity)
        {
            case ItemInstance.ItemRarity.COMMON:
            mods.AddRange(GetRandomModsFromList(commonMods, _commonMods));
            break;

            case ItemInstance.ItemRarity.RARE:
            mods.AddRange(GetRandomModsFromList(commonMods, _commonMods));
            mods.AddRange(GetRandomModsFromList(rareMods, _rareMods));
            break;

            case ItemInstance.ItemRarity.EPIC:
            mods.AddRange(GetRandomModsFromList(commonMods, _commonMods));
            mods.AddRange(GetRandomModsFromList(rareMods, _rareMods));
            mods.AddRange(GetRandomModsFromList(epicMods, _epicMods));
            break;

            case ItemInstance.ItemRarity.LEGENDARY:
            mods.AddRange(GetRandomModsFromList(commonMods, _commonMods));
            mods.AddRange(GetRandomModsFromList(rareMods, _rareMods));
            mods.AddRange(GetRandomModsFromList(epicMods, _epicMods));
            mods.AddRange(GetRandomModsFromList(legendaryMods, _legendaryMods));
            break;
        }

        return mods; 
    }

    private List<Modifier> GetRandomModsFromList (List<Modifier> _list, int _qty)
    {
        List<Modifier> mods = new List<Modifier>();

        for (int i = 0; i < _qty; i++)
        {
            mods.Add(_list[Random.Range(0, _list.Count)]);
        }

        return mods;
    }

}
