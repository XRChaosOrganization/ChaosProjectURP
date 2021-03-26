using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Alex : ButtonBehaviorComponent?
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
        if(skill.skill.castType == SkillInstance.CastType.INSTANT)
        {
            joystick.gameObject.SetActive(false);
            button.gameObject.SetActive(true);
        }
        //if sur le activationtype 
        //On Surface -> JOYSTICK(AOE)
        //Ranged -> JOYSTICK
        //On Actor->JOYSTICK 
        // OnActor.Self -> BUTTON
        //Melee->BUTTON
    }

    void Update()
    {
        UpdateSkillUse();
    }

    private void UpdateSkillUse()
    {
       //if (linkedSkill != null)
       //{
       //    Vector3 direction = new Vector2(joystick.Horizontal, joystick.Vertical);
       //    //RaycastHit2D hit = Physics2D.CircleCast(player.targetingOrigin.position, circlecastRadius, direction, linkedSkill.skill.targetingRadius, targetLayer);
       //
       //    if(direction == Vector3.zero) return; 
       //    
       //    RaycastHit2D hit = Physics2D.Raycast(player.targetingOrigin.position, direction, linkedSkill.skill.targetingRadius, targetLayer);
       //    if (hit)
       //    {
       //        Target target = hit.collider.gameObject.GetComponentInChildren<Target>();
       //
       //        if (target != lastTarget)
       //        {
       //            
       //            if(ClearTargets != null)
       //                ClearTargets();
       //            lastTarget = target;
       //            target.TargetOn();
       //
       //        }
       //    }
       //    else if (lastTarget != null)
       //    {
       //        lastTarget = null;
       //        if (ClearTargets != null)
       //            ClearTargets();
       //    }
       //}
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
