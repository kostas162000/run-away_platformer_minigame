using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningBootsChestInteract : MonoBehaviour
{
    [SerializeField] private playerInventory inventory;


    //public static bool playerPressedButton;
    public bool runningBootsPickedUp=false;
    [SerializeField] private LockPickingMinigame lockPickMinigame; // Drag the minigame GameObject here in the Inspector

    [SerializeField] private GameObject interactableKeyText;
    public GameObject noLockpickText;

    public bool InteractWithRunningBootsChest = false;

    //[SerializeField] private GameObject itemUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interactableKeyText.activeSelf && InteractWithRunningBootsChest == true)
        {
            OpenChest();
        }

       if(LockPickingMinigame.pickLockSuccessfull == true)
        {
            runningBootsPickedUp = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Debug.Log("Player is in collider");
            interactableKeyText.SetActive(true);
            InteractWithRunningBootsChest = true;
        }
        
    }

    private void OpenChest()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            
            interactableKeyText.SetActive(false);

            if(inventory.lockpickTotalCount > 0)
            lockPickMinigame.StartMinigame();

            else if(inventory.lockpickTotalCount <= 0)
                noLockpickText.SetActive(true);
            
            //itemUI.SetActive(true);
            //Debug.Log("Player openned chest");
            InteractWithRunningBootsChest = false;
            //runningBootsPickedUp = true;
            //}
        }
    }
}
