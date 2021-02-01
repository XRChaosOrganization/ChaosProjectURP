using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRPGComponent : MonoBehaviour
{
    public CharacterInventoryComponent inventory;
    public StatGridSO statGrid; 
    [SerializeField] private List<StatInstance> statInstances; 
    
    [Header("Debug")]
    public bool debugStatsFromItemUpdate = false; 

    public void InitRPGComponent ()
    {
        //Inits
        InitCharacterStats();
        UpdateStatsFromItems();
    }

    private void InitCharacterStats()
    {
        for (int i = 0; i < statGrid.baseStats.Count; i++)
        {
            statInstances.Add(new StatInstance(statGrid.baseStats[i].statSO.stat.statName, statGrid.baseStats[i].baseValue));
        }
    }

    //Go through all items & for each modifiers & base modifiers send them to our stats
    public void UpdateStatsFromItems ()
    {
        if(inventory == null) return; 
        if(inventory.equippedItems.Count <= 0) return; 

        inventory.UpdateEquippedItemInstances();

        List<ItemInstance> items = inventory.GetItems();

        for (int i = 0; i < items.Count; i++)
        {
            //Add base mods stats 
            for (int k = 0; k < items[i].itemBaseSO.itemBase.baseMods.Count; k++)
            {
                Modifier baseMod = items[i].itemBaseSO.itemBase.baseMods[k]; 
                ApplyModifierToStat(baseMod);
            }
            //Add item mods stats 
            for (int j = 0; j < items[i].modifiers.Count; j++)
            {
                Modifier mod = items[i].modifiers[j]; 
                ApplyModifierToStat(mod);
            }
            if(debugStatsFromItemUpdate) 
            {
                print("Processed -> " + items[i].itemName + " <<<\n" + "it has    -> " + items[i].itemBaseSO.itemBase.baseMods.Count + " base mods / " + "and       -> " + items[i].modifiers.Count + " mods");
                //print();
                //print();
            }
        }

    }

    public void ApplyModifierToStat (Modifier _modifier)
    {
        StatInstance statToModify = null; 

        //Select the stat to modify
        for (int i = 0; i < statInstances.Count; i++)
        {
            if(statToModify == null && _modifier.statSO.stat.statName == statInstances[i].statName)
            {
                statToModify = statInstances[i];
            }
        }

        if(statToModify == null)
        {
            Debug.LogWarning("No stat to modify found on this RPG Component, did you forget to add this stat ? : " + _modifier.statSO.stat.statName);
            return; 
        }

        //A refaire plus proprement
        if(_modifier.mode == Modifier.Mode.ADD)
        {
            if(_modifier.modeType == Modifier.ModeType.FLAT)
                statToModify.statCurrentValue += _modifier.modifierValue;
            else if(_modifier.modeType == Modifier.ModeType.PERCENT)
                statToModify.statCurrentValue += (_modifier.modifierValue / 100) * statToModify.statCurrentValue;
        }
        else if(_modifier.mode == Modifier.Mode.DIVIDE)
        {
            if(_modifier.modeType == Modifier.ModeType.FLAT)
                statToModify.statCurrentValue /= _modifier.modifierValue;
            else if(_modifier.modeType == Modifier.ModeType.PERCENT)
                statToModify.statCurrentValue /= (_modifier.modifierValue / 100) * statToModify.statCurrentValue;
        }
        else if(_modifier.mode == Modifier.Mode.DIVIDE)
        {
            if(_modifier.modeType == Modifier.ModeType.FLAT)
                statToModify.statCurrentValue -= _modifier.modifierValue;
            else if(_modifier.modeType == Modifier.ModeType.PERCENT)
                statToModify.statCurrentValue -= (_modifier.modifierValue / 100) * statToModify.statCurrentValue;
        }
        else if(_modifier.mode == Modifier.Mode.DIVIDE)
        {
            if(_modifier.modeType == Modifier.ModeType.FLAT)
                statToModify.statCurrentValue *= _modifier.modifierValue;
            else if(_modifier.modeType == Modifier.ModeType.PERCENT)
                statToModify.statCurrentValue *= (_modifier.modifierValue / 100) * statToModify.statCurrentValue;
        }
        else
        {
            Debug.LogError("This modifier is trying to apply an incorrect/wrong mod to the value : " + _modifier.statSO.stat.statName);
        }
    }

    public List<StatInstance> GetStats ()
    {
        return statInstances; 
    }

    public StatInstance GetStat (string _statName)
    {
        StatInstance stat = null;
        stat = statInstances.Find(x => x.statName == _statName);

        if(stat == null)
        {
            Debug.LogWarning("Did no find stat : " + _statName);
        }

        return stat;
    }
}
