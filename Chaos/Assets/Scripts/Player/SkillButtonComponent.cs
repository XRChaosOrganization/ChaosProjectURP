using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillButtonComponent : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private SkillInputComponent skillInput;
    public bool isJoystick = false; 

    void Awake()
    {
        skillInput = GetComponentInParent<SkillInputComponent>();
        if(GetComponent<FixedJoystick>() != null)
        {
            isJoystick = true; 
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isJoystick == false) return; 
        skillInput.OnInputUp();

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
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isJoystick == true) return; 
        skillInput.OnInputDown();
    }
}
