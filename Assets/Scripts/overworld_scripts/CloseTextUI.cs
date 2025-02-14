using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTextUI : MonoBehaviour
{
    [SerializeField] private GameObject interactableKeyText;

    public GameObject itemPivot;
    private SimpleMushroomInteract simpleMushroom;
    private BrownMushroomInteract brownMushroom;
    private RedMushroomInteract redMushroom;
    private RunningBootsChestInteract runningBoots;
    private SimpleChestMushroomInteract mushItem;
    //private RoomDoorOpen enteringDoor;

    [SerializeField] private ItemUIPopUpController UIToClose;
    // Start is called before the first frame update
    void Start()
    {
        if (itemPivot != null)
        {
            simpleMushroom = itemPivot.GetComponent<SimpleMushroomInteract>();
            runningBoots = itemPivot.GetComponent<RunningBootsChestInteract>();
            mushItem = itemPivot.GetComponent<SimpleChestMushroomInteract>();
            brownMushroom = itemPivot.GetComponent<BrownMushroomInteract>();
            redMushroom = itemPivot.GetComponent<RedMushroomInteract>();
            //enteringDoor = itemPivot.GetComponent<RoomDoorOpen>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Player is in collider");
            interactableKeyText.SetActive(false);
            UIToClose.keyToCloseIsPressed = false;
            //PlayerInChest = true;
            if (itemPivot != null)
            {
                if (mushItem != null)
                {
                    mushItem.InteractWithSimpleMushroomChest = false;
                }
                if (runningBoots != null)
                {
                    runningBoots.InteractWithRunningBootsChest = false;
                    runningBoots.noLockpickText.SetActive(false);
                }
                if (simpleMushroom != null)
                {
                    simpleMushroom.InteractWithSimpleMushroom = false;
                }
                if (brownMushroom != null)
                {
                    brownMushroom.InteractWithBrownMushroom = false;
                }
                if (redMushroom != null)
                {
                    redMushroom.InteractWithRedMushroom = false;
                }
                /*if(enteringDoor != null)
                {
                    enteringDoor.textToOpenDoor.SetActive(false);
                }*/
            }
        }

    }
}
