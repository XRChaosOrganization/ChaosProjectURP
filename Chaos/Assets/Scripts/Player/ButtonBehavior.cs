using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{

    #region Go or components

    [SerializeField] private Player player;
    [SerializeField] private Joystick joystick;
    [SerializeField] private GameObject button;

    public SkillSO linkedSkill;

    #endregion

    #region properties

    [SerializeField][Range(1,3)] private int buttonId = 1;

    #endregion

    #region Inputs
    #endregion

    #region Variables
    #endregion

    #region Unity loop
    void Awake()
    {
        SkillLink();

    }

    void Start()
    {
        
    }


	void FixedUpdate()
    {
        
    }
	
    void Update()
    {
        SkillLink();   // Temp
    }
    #endregion

    #region Methods

    private void SkillLink()
    {

        switch (buttonId)
        {
            case 1:
                linkedSkill = player.skill1;
                break;

            case 2:
                linkedSkill = player.skill2;
                break;

            case 3:
                linkedSkill = player.skill3;
                break;
        }



        if (linkedSkill.skill.joystick == true)
        {
            button.SetActive(false);
            joystick.gameObject.SetActive(true);
        }
        else
        {
            button.SetActive(true);
            joystick.gameObject.SetActive(false);
        }

    }


    public void SkillUse()
    {
        linkedSkill.skill.UseSkill();
    }

    private void OnDrawGizmos()
    {
        if(linkedSkill != null)
        {
            Vector3 direction = new Vector2(joystick.Horizontal, joystick.Vertical);
            Debug.DrawRay(player.targetingOrigin.position, direction * linkedSkill.skill.targetingRadius, Color.red);
            UnityEditor.Handles.DrawWireDisc(player.targetingOrigin.position, player.targetingOrigin.forward, linkedSkill.skill.targetingRadius);
        }
        
    }







    #endregion
}
