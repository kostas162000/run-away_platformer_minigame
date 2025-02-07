using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gamestate { Freeroam,dialog,battle}

public class Gamecontroller : MonoBehaviour
{

    [SerializeField] playerTestMovement playercontroller;
    Gamestate state;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject inventoryMenu;
    [SerializeField] private GameObject journalMenu;

    //[SerializeField] private GameObject MainCamera;
    private float temp;

    public playerInventory Player;
    public List<SlotUI> slots = new List<SlotUI>();

    private void Start()
    {
        temp = playercontroller.moveSpeed;

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
            //playercontroller.HandleUpdate();

            playercontroller.moveSpeed = temp;


        }
        else if ( state== Gamestate.dialog)
        {
            dialogmanag.Instance.HandleUpdate();
            playercontroller.moveSpeed = 0;
        }
        else if ( state== Gamestate.battle)
        {

        }
        

        if(TrapForMinigame.assignedID == 0) pauseButton();

        //if(StageController.buttonToReturnToCheckpoint) MainCamera.SetActive(true);
    }



    private void pauseButton()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void JournalButton() 
    {
        journalMenu.SetActive(true);
    }

    public void closeJournal()
    {
        journalMenu.SetActive(false);
    }

    public void InventoryButton()
    {
        inventoryMenu.SetActive(true);
        SetupForInventory();
    }

    public void closeInventory()
    {
        inventoryMenu.SetActive(false);
    }

    public void SetupForInventory()
    {
        if (slots.Count == Player.inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (Player.inventory.slots[i].type != collectableType.NONE)
                {
                    slots[i].setItem(Player.inventory.slots[i]);
                }
                else
                {
                    slots[i].setEmpty();
                }
            }
        }
    }
}
