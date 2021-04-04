using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInputComponent : MonoBehaviour
{
    public delegate void Event();
    public static Event ClearTargets;

    [SerializeField] private Joystick joystick;
    [SerializeField] private GameObject button;

    [SerializeField] private LayerMask targetLayer; //Alex : This should come from the Skill 
    [SerializeField] private float circlecastRadius; //Alex : This should come from the Skill 

    public Target lastTarget;
    private SkillSO skill;

    public void Init(SkillSO _skill)
    {
        skill = _skill;

        if (skill.skill.activationType == SkillInstance.ActivationType.OnActorSelf || skill.skill.activationType == SkillInstance.ActivationType.Melee)
        {
            joystick.gameObject.SetActive(false);
            button.gameObject.SetActive(true);
        } else
        {
            joystick.gameObject.SetActive(true);
            button.gameObject.SetActive(false);
        }


        // Ben : Instant can be set on joystick too, they activate on joystick release
        //if(skill.skill.castType == SkillInstance.CastType.INSTANT)
        //{
        //    joystick.gameObject.SetActive(false);
        //    button.gameObject.SetActive(true);
        //}

    }

    void Update()
    {
        UpdateSkillUse();
    }

    private void UpdateSkillUse()
    {

    }

    public void OnInputDown ()
    {
        print("Down");
        switch (skill.skill.castType)
        {
            case SkillInstance.CastType.INSTANT:
                skill.skill.ExecuteSkill();
                break;
            case SkillInstance.CastType.CHARGED:
                break;
            case SkillInstance.CastType.CHANNELED:
                break;
            default:
                break;
        }
        //Cast type (instant, charged, channeled)
    }

    public void OnInputUp ()
    {
        print("up");

    }

    //public void OnJoystickUp()
    //{
    //    // Use skill on last target
    //    lastTarget = null;
    //
    //    if (ClearTargets != null)
    //        ClearTargets();
    //}

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        //if(linkedSkill != null && player != null)
        //{
        //    Vector3 direction = new Vector2(joystick.Horizontal, joystick.Vertical);
        //
        //    Debug.DrawRay(player.targetingOrigin.position, direction.normalized * linkedSkill.skill.targetingRadius, Color.green);
        //    Debug.DrawRay(player.targetingOrigin.position, direction * linkedSkill.skill.targetingRadius, Color.red);
        //    
        //    //UnityEditor.Handles.DrawWireDisc(player.targetingOrigin.position, player.targetingOrigin.forward, linkedSkill.skill.targetingRadius);
        //}

    }
#endif
}
