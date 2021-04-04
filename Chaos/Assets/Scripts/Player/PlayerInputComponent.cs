using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInputComponent : MonoBehaviour
{

    #region Go or components

    private CharacterControllerComponent cc;
    [SerializeField] private Joystick joystick;



    #endregion

    #region Properties
    #endregion

    #region Inputs
    #endregion

    #region Variables

    float hMove;
    bool jump;
    
    private bool wasInteracting;
    private bool interact;
    private bool hLock = false;
    public bool inputLock;

    Vector3 joyDirection;


    #endregion

    #region Unity loop
    void Awake()
    {
        cc = GetComponent<CharacterControllerComponent>();
    }

    void Start()
    {

    }


	void FixedUpdate()
    {

        if (!inputLock)
        {
            cc.Move(hMove, jump);
            jump = false;
        }
        
    }
	
    void Update()
    {
        if (!inputLock)
        {
            joyDirection = new Vector2(joystick.Horizontal, joystick.Vertical).normalized;

            if (hLock)
                hMove = 0;
            else hMove = joyDirection.x;

            DetectJump();
            DetectInterract();
            
        }

    }
	#endregion
	
	#region Methods

    private void DetectJump()
    {

        if (joyDirection.y >= Mathf.Sin(cc.jumpDetectAngle * Mathf.PI) && cc.isGrounded)
        {
            jump = true;
            
        }

    }

    private void DetectInterract()
    {

        if (joyDirection.y <= Mathf.Sin(cc.interractDetectAngle * Mathf.PI))
        {
            interact = true;
            hLock = true;
        }
        else
        {
            interact = false;
            hLock = false;
            wasInteracting = false;
        }
        

    }


    private void OnTriggerStay2D(Collider2D other)
    {

        if(other.tag == "Interactable" && interact == true && !wasInteracting)
        {
            other.GetComponent<InteractableComponent>().OnInteract();
            wasInteracting = true;
            
        }
    }

    #endregion
}
