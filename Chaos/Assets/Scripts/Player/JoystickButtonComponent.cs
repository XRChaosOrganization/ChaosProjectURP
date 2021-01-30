using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickButtonComponent : MonoBehaviour, IPointerUpHandler
{

    #region Go or components

    private ButtonBehavior buttonBehavior;

    #endregion

    #region Properties
    #endregion

    #region Inputs
    #endregion

    #region Variables
	#endregion

	#region Unity loop
    void Awake()
    {
        buttonBehavior = GetComponentInParent<ButtonBehavior>();
    }

    void Start()
    {
        
    }


	void FixedUpdate()
    {
        
    }
	
    void Update()
    {
        
    }


    #endregion

    #region Methods


    public void OnPointerUp(PointerEventData eventData)
    {
        buttonBehavior.OnJoystickUp();

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

    #endregion
}
