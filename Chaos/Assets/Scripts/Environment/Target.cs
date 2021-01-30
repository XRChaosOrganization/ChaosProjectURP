using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    #region Go or components

    private SpriteRenderer target;

    #endregion

    #region Properties
    #endregion

    #region Inputs

    private void OnEnable()
    {
        ButtonBehavior.ClearTargets += TargetOff;
    }

    private void OnDisable()
    {
        ButtonBehavior.ClearTargets -= TargetOff;
    }

    #endregion

    #region Variables
    #endregion

    #region Unity loop
    void Awake()
    {
        target = GetComponentInChildren<SpriteRenderer>();
        TargetOff();
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

    private void TargetOff()
    {
        target.gameObject.SetActive(false);
    }

    public void TargetOn()
    {
        target.gameObject.SetActive(true);
    }

    #endregion
}
