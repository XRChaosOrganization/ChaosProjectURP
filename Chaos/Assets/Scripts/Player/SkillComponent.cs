using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillComponent : MonoBehaviour
{
    [Header("Skills")] 
    public SkillSO skillAttackSlot;
    public SkillSO skillSpecialSlot;
    public SkillSO skillMagicSlot;

    public SkillInputComponent attackSlotInput; 
    public SkillInputComponent specialSlotInput; 
    public SkillInputComponent magicSlotInput; 


    void Awake()
    {
        attackSlotInput = GameObject.Find("Action Button 1").GetComponent<SkillInputComponent>();
        //specialSlotInput = gameobj.find("');
        //magicSlotInput = gameobj.find("');
        EquipSkill(skillAttackSlot);
    }

    void Update()
    {
        
    }

    public void EquipSkill(SkillSO _skill)
    {
        switch (_skill.skill.skillSlot)
        {
            case SkillInstance.SkillSlot.ATTACK:
                attackSlotInput.Init(_skill);
                break;
            case SkillInstance.SkillSlot.SPECIAL:
                break;
            case SkillInstance.SkillSlot.MAGIC:
                break;
            default:
                break;
        }
    }

    //private void SkillLink()
    //{
    //
    //    switch (buttonId)
    //    {
    //        case 1:
    //            linkedSkill = player.skill1;
    //            break;
    //
    //        case 2:
    //            linkedSkill = player.skill2;
    //            break;
    //
    //        case 3:
    //            linkedSkill = player.skill3;
    //            break;
    //    }
    //
    //
    //
    //    if (linkedSkill.skill.joystick == true)
    //    {
    //        button.SetActive(false);
    //        joystick.gameObject.SetActive(true);
    //    }
    //    else
    //    {
    //        button.SetActive(true);
    //        joystick.gameObject.SetActive(false);
    //    }
    //
    //}

}
