using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBehaviorComponent : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
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

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isJoystick == true) return; 
        skillInput.OnInputDown();
    }
}
