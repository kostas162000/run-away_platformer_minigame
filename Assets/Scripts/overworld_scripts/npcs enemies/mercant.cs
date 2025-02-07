using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mercant : MonoBehaviour , interactable
{
    [SerializeField] private int dialogueID = 0;

    [SerializeField] private GameObject questMenu;

    [SerializeField] private GameObject mushroomInfoButton;

    [SerializeField] private GameObject mushroomQuestFinished;

    private int neededMushroomAmount = 3;
    //[SerializeField] private GameObject mushroomInfoAnswer;

    //[SerializeField] private AnswerArrowMovement answer;

    [SerializeField] private playerInventory player; // Reference to the player's inventory
    [SerializeField] private Gamecontroller gameController;  // Reference to the game controller for inventory UI


    [SerializeField] Dialog dialog;
    [SerializeField] Dialog dialog1;
    [SerializeField] Dialog dialog2;
    //[SerializeField] Dialog dialog3;

    public void Interact()
    {
        if (dialogueID == 0)
        {
            StartCoroutine(dialogmanag.Instance.showdialog(dialog));
            dialogueID = 1;
        }
        else if (dialogueID == 1)
        {
            if (player.threeRedMushrooms == false)
            {
                StartCoroutine(dialogmanag.Instance.showdialog(dialog1));
                mushroomInfoButton.SetActive(true);
                //StartCoroutine(dialogmanag.Instance.showdialog(dialog2));
                //mushroomInfoAnswer.SetActive(true);
                //dialogueID = 2;
            }

            else if (player.threeRedMushrooms == true)
            {
                StartCoroutine(dialogmanag.Instance.showdialog(dialog2));
                RemoveRedMushrooms(neededMushroomAmount - 1);
                UpdateInventoryUI();
                mushroomQuestFinished.SetActive(true);
            }
        }

        
        /*else if (dialogueID == 2)
        {
            if(answer.positiveAnswer == true)
            {
                StartCoroutine(dialogmanag.Instance.showdialog(dialog2));
                mushroomInfoAnswer.SetActive(false);
            }

            else if(answer.positiveAnswer == false)
            {
                StartCoroutine(dialogmanag.Instance.showdialog(dialog3));
                mushroomInfoAnswer.SetActive(false);
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (/*playerTestMovement.talkedToMerchant*/dialogueID == 1)
        {
            questMenu.SetActive(true);
            playerTestMovement.talkedToMerchant = false;
        }

        
    }


   private void RemoveRedMushrooms(int quantity)
{
    int remainingToRemove = quantity;

    // Iterate through inventory slots to remove all REDMUSHROOM items at once
    for (int i = 0; i < player.inventory.slots.Count; i++)
    {
        Inventory.Slot slot = player.inventory.slots[i];
        
        if (slot.type == collectableType.REDMUSHROOM)
        {
            // Check if the slot has enough items to remove
            if (slot.count >= remainingToRemove)
            {
                slot.count -= remainingToRemove;  // Remove mushrooms from this slot
                remainingToRemove = 0;            // All mushrooms have been removed
                slot.removeItem();                // Clear the slot if count reaches 0
                break;                            // Stop the loop once all mushrooms are removed
            }
            else
            {
                remainingToRemove -= slot.count;  // Subtract the slot's mushrooms
                slot.removeItem();                // Remove all mushrooms from this slot
            }
        }

        if (remainingToRemove <= 0)
        {
            break;  // Stop the loop if all mushrooms are removed
        }
    }

    // Reset the `threeRedMushrooms` flag after removal process is done
    player.threeRedMushrooms = false;  // Ensures it's set to false after removal
}



    private void UpdateInventoryUI()
    {
        // Update the inventory UI by calling `SetupForInventory` from the Gamecontroller
        gameController.SetupForInventory();
    }
}
