using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class SkillBase
{
    public virtual void UpdateActivationType () { }
    public virtual void UpdateCastingType () { }
    public virtual void ExecuteSkill () 
    {
        Debug.Log("skill executed");
    }
}

