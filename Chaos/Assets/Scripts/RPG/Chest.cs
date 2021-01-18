using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{

    #region Go or components

    public SpriteRenderer sr;

    #endregion

    #region Properties

    private bool state = true;
    

    #endregion

    #region Inputs
    #endregion

    #region Variables



    #endregion

    #region Methods

    public override void OnInteract()
    {
        if (state)
        {
            sr.color = Color.gray;
            state = !state;
        }
            
        else 
        {
            sr.color = Color.yellow;
            state = !state;
        }

        

    }


    #endregion
}
