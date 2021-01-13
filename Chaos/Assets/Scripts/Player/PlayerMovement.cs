using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region Go or components

    private CharacterController2D cc;
    private Joystick joystick;



    #endregion

    #region Properties
    #endregion

    #region Inputs
    #endregion

    #region Variables

    float hMove;
    bool jump;


	#endregion

	#region Unity loop
    void Awake()
    {
        joystick = FindObjectOfType<Joystick>();
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
        hMove = joystick.Horizontal + Input.GetAxisRaw("Horizontal");
        DetectJump();
        
    }
	#endregion
	
	#region Methods

    private void DetectJump()
    {
        if (joystick.Vertical >= Mathf.Cos(cc.jumpDetectAngle) || Input.GetAxisRaw("Vertical") >= Mathf.Cos(cc.jumpDetectAngle))
        {
            Debug.Log("Jump Detected !");
            jump = true;
        }
            

    }

	#endregion
}
