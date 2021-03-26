using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Source_", menuName = "Data/Skill/Source", order = 1)]
public class SourceSO : ScriptableObject
{
    public string name;
    public Modifier statToInfluence; 
}
