using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRPGComponent : MonoBehaviour
{
    public CharacterInventoryComponent inventory;
    public List<StatSO> baseStats; 
    [SerializeField] private List<StatInstance> statInstances; 

    public void InitRPGComponent ()
    {
        //Inits
        inventory.InitCharacterItems();
        InitCharacterStats();
        UpdateRPGStatsFromItems();
    }

    private void InitCharacterStats()
    {
        for (int i = 0; i < baseStats.Count; i++)
        {
            statInstances.Add(new StatInstance(baseStats[i].stat.statName, baseStats[i].stat.statBaseValue));
        }
    }

    //Go through all items & for each modifiers & base modifiers send them to our stats
    public void UpdateRPGStatsFromItems ()
    {
        List<ItemInstance> items = inventory.GetItems();

        for (int i = 0; i < items.Count; i++)
        {
            for (int j = 0; j < items[i].modifiers.Count; j++)
            {
                Modifier mod = items[i].modifiers[j]; 
                ApplyModifierToStat(mod);

                for (int k = 0; k < items[i].GetBase().baseMods.Count; k++)
                {
                    Modifier baseMod = items[i].GetBase().baseMods[k]; 
                    ApplyModifierToStat(baseMod);
                }
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
