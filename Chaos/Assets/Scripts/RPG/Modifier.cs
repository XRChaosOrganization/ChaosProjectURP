using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Modifier
{
    public StatSO statSO;
    public enum Mode {ADD, MINUS, MULT, DIVIDE};
    public Mode mode;
    public enum ModeType {FLAT, PERCENT};
    public ModeType modeType;
    public Vector2 modRangeValue; 
    private float modifierValue = 0.0f; 

    public float ModifierValue 
    {
        get
        {
            if(modifierValue == 0.0f)
                modifierValue = Random.Range(modRangeValue.x, modRangeValue.y);
            
            return modifierValue;
        }
    }
} 