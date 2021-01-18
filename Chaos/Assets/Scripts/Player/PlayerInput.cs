using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    #region Go or components

    private CharacterController2D cc;
    [SerializeField] private Joystick joystick;



    #endregion

    #region Properties
    #endregion

    #region Inputs
    #endregion

    #region Variables

    float hMove;
    bool jump;
    [SerializeField][Range(-0.5f, 0)] private float interractDetectAngle;
    public bool interact;
    public bool hLock = false;
    


    #endregion

    #region Unity loop
    void Awake()
    {
        cc = GetComponent<CharacterController2D>();
    }

    void Start()
    {

    }


	void FixedUpdate()
    {
        cc.Move(hMove, jump);
        jump = false;
    }
	
    void Update()
    {
        if (hLock)
            hMove = 0;
        else hMove = joystick.Horizontal;

        DetectJump();
        DetectInterract();

        
    }
	#endregion
	
	#region Methods

    private void DetectJump()
    {
        if (joystick.Vertical >= Mathf.Sin(cc.jumpDetectAngle * Mathf.PI))
        {
            jump = true;
            
        }

    }

    private void DetectInterract()
    {
        if (joystick.Vertical <= Mathf.Sin(interractDetectAngle * Mathf.PI))
        {
            interact = true;
            hLock = true;
        }
        else
        {
            interact = false;
            hLock = false;
        }
        

    }


    private void OnTriggerStay2D(Collider2D other)
    {

        if(other.tag == "Interactable" && interact == true)
        {
            Debug.Log("Interacted !");
            
        }
    }

    #endregion
}
