using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonBehavior : MonoBehaviour
{

    #region Events

    public delegate void Event();
    public static Event ClearTargets;

    #endregion


    #region Go or components

    [SerializeField] private Player player;
    [SerializeField] private Joystick joystick;
    [SerializeField] private GameObject button;

    public SkillSO linkedSkill;

    #endregion

    #region properties

    [SerializeField][Range(1,3)] private int buttonId = 1;
    [SerializeField] private LayerMask targetLayer;

    #endregion

    #region Inputs
    #endregion

    #region Variables
    [SerializeField] private float circlecastRadius;
    public Target lastTarget;
    #endregion

    #region Unity loop
    void Awake()
    {
        player = FindObjectOfType<Player>();
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
        Autolock();
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

    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if(linkedSkill != null)
        {
            Vector3 direction = new Vector2(joystick.Horizontal, joystick.Vertical);

            Debug.DrawRay(player.targetingOrigin.position, direction.normalized * linkedSkill.skill.targetingRadius, Color.green);
            Debug.DrawRay(player.targetingOrigin.position, direction * linkedSkill.skill.targetingRadius, Color.red);
            
            UnityEditor.Handles.DrawWireDisc(player.targetingOrigin.position, player.targetingOrigin.forward, linkedSkill.skill.targetingRadius);
        }
        
    }

#endif

    private void Autolock()
    {
        if (linkedSkill != null)
        {
            Vector3 direction = new Vector2(joystick.Horizontal, joystick.Vertical);
            RaycastHit2D hit = Physics2D.CircleCast(player.targetingOrigin.position, circlecastRadius, direction, linkedSkill.skill.targetingRadius, targetLayer);

            if (hit)
            {
                Target target = hit.collider.gameObject.GetComponent<Target>();
                Debug.Log(target);

                if (target != lastTarget)
                {
                    
                    if(ClearTargets != null)
                        ClearTargets();
                    lastTarget = target;
                    target.TargetOn();

                }
            

            }
            else if (lastTarget != null)
            {
                lastTarget = null;
                if (ClearTargets != null)
                    ClearTargets();
            }

            



        }
    }

    public void OnJoystickUp()
    {
        // Use skill on last target

        lastTarget = null;

        if (ClearTargets != null)
            ClearTargets();
    }

    #endregion
}
