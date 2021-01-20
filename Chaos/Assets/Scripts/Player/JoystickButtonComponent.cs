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
        
    }

    #endregion
}
