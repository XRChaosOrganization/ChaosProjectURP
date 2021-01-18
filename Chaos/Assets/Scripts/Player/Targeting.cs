using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Targeting : MonoBehaviour
{

    #region Events

    public delegate void Event();
    public static Event ClearTargets;

    #endregion

    #region Go or components

    [SerializeField ]private Player player;


    #endregion

    #region Properties


    [SerializeField] private LayerMask targetLayer;

    #endregion

    #region Inputs
    #endregion

    #region Variables

    public Collider2D closestEnemy = null;
    private float nearestDistance = Mathf.Infinity;

    #endregion

    #region Unity loop
    void Awake()
    {

    }

    void Start()
    {
        
    }


	void LateUpdate()
    {


    }
	
    void Update()
    {
        TargetClosest();

        
    }
    #endregion

    #region Methods


    private void TargetClosest()
    {
        Collider2D[] enemyInRange = enemyInRange = Physics2D.OverlapCircleAll(player.targetingOrigin.position, player.skill1.skill.targetingRadius, targetLayer);

        if (enemyInRange.Length == 0)
        {
            if (ClearTargets != null)
                ClearTargets();
            closestEnemy = null;
        }
        else
        {
            foreach (Collider2D enemy in enemyInRange)
            {


                if (Vector2.Distance(player.targetingOrigin.transform.position, enemy.transform.position) < nearestDistance)
                {
                    nearestDistance = Vector2.Distance(player.targetingOrigin.transform.position, enemy.transform.position);

                    if (enemy != closestEnemy)
                    {
                        closestEnemy = enemy;
                        if (ClearTargets != null)
                            ClearTargets();
                        closestEnemy.GetComponent<Target>().TargetOn();
                    }

                }

            }
        }
        

        nearestDistance = Mathf.Infinity;
    }


    #endregion
}
