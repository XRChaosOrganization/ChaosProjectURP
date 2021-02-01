using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatGrid_", menuName = "Data/RPG/StatGrid", order = 4)]
public class StatGridSO : ScriptableObject
{
    [System.Serializable]
    public struct BaseStat 
    {
        public StatSO statSO; 
        public float baseValue;
    }

    public List<BaseStat> baseStats; 
}
