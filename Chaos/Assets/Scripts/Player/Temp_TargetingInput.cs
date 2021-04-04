using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_TargetingInput : MonoBehaviour
{

    // Ben : Je Stock ici les scripts de targeting que j'avais codé en attendant de les placer dans les bons scripts



    // ------ Target Closest ------
    //Collider2D[] enemyInRange = enemyInRange = Physics2D.OverlapCircleAll(player.targetingOrigin.position, player.skill1.skill.targetingRadius, targetLayer);

    //if (enemyInRange.Length == 0)
    //{
    //    if (ClearTargets != null)
    //        ClearTargets();
    //    closestEnemy = null;
    //}
    //else
    //{
    //    foreach (Collider2D enemy in enemyInRange)
    //    {

    //        if (Vector2.Distance(player.targetingOrigin.transform.position, enemy.transform.position) < nearestDistance)
    //        {
    //            nearestDistance = Vector2.Distance(player.targetingOrigin.transform.position, enemy.transform.position);

    //            if (enemy != closestEnemy)
    //            {
    //                closestEnemy = enemy;
    //                if (ClearTargets != null)
    //                    ClearTargets();
    //                
    //                if(closestEnemy.GetComponent<Target>() != null)
    //                    closestEnemy.GetComponent<Target>().TargetOn();
    //            }

    //        }

    //    }
    //}      






    // ------ Target Joystick ------

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
