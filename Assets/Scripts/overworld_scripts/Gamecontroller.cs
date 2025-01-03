using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gamestate { Freeroam,dialog,battle}

public class Gamecontroller : MonoBehaviour
{

    [SerializeField] movementcharacter playercontroller;
    Gamestate state;

    private void Start()
    {
        dialogmanag.Instance.OnShowDialog += () =>
        {
            state = Gamestate.dialog;
        };
        dialogmanag.Instance.OnHideDialog += () =>
        {
           if( state == Gamestate.dialog)
                state = Gamestate.Freeroam;// to freeroam to start walking again
        };
    }
    private void Update()
    {
        if (state == Gamestate.Freeroam)
        {
            playercontroller.HandleUpdate();

        
        
        }else if ( state== Gamestate.dialog)
        {
            dialogmanag.Instance.HandleUpdate();
        }else if ( state== Gamestate.battle)
        {

        }
    }
}
