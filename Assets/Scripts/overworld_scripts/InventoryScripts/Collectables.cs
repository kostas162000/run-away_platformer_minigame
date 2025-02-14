using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;


public class Collectables : MonoBehaviour
{
    //[SerializeField] private ChestInteract item;
    public GameObject itemPivot;
    private SimpleMushroomInteract simpleMushroom;
    private BrownMushroomInteract brownMushroom;
    private RedMushroomInteract redMushroom;
    private RunningBootsChestInteract runningBoots;
    private SimpleChestMushroomInteract mushItem;
    private mercant lockpickFromMerchant;
    
    /*[SerializeField] private MushroomInteract mushroom;
    [SerializeField] private BootsChestInteract item;
    [SerializeField] private SimpleChestMushroomInteract mushItem;*/


    [SerializeField] private playerInventory Player;
    [SerializeField] private playerTestMovement playerMove;

    [SerializeField] private GameObject itemUI;

    public Sprite icon;

    public collectableType type;

    [SerializeField] private ItemUIPopUpController UItoClose;

    
    // Start is called before the first frame update
    void Start()
    {
        simpleMushroom = itemPivot.GetComponent<SimpleMushroomInteract>();
        runningBoots = itemPivot.GetComponent<RunningBootsChestInteract>();
        mushItem = itemPivot.GetComponent<SimpleChestMushroomInteract>();
        brownMushroom = itemPivot.GetComponent <BrownMushroomInteract>();
        redMushroom = itemPivot .GetComponent<RedMushroomInteract>();
        lockpickFromMerchant = itemPivot.GetComponent<mercant>();
    }

    // Update is called once per frame
    void Update()
    {

        

        if (mushItem != null)
        {
            
            if (mushItem.simpleMushChestPickedUp == true)
            {
                takeItem();
                mushItem.simpleMushChestPickedUp = false;
                
            }
        }
        if (runningBoots != null)
        {
            
            if (runningBoots.runningBootsPickedUp == true)
            {
                takeItem();
                runningBoots.runningBootsPickedUp = false;
                /*
                Player.inventory.Add(this);
                //Debug.Log("Player picked up item");
                itemUI.SetActive(true);
                playerMove.enabled = false;
                if (UItoClose.keyToCloseIsPressed)
                {
                    Destroy(this.gameObject);
                    item.itemPickedUp = false;
                    
                }*/
                LockPickingMinigame.pickLockSuccessfull = false;
            }
        }

        if(lockpickFromMerchant != null)
        {
            if(lockpickFromMerchant.lockpickReceived == true)
            {
                //takeItem();
                takeMultipleItems(3);
                lockpickFromMerchant.lockpickReceived = false;
            }
        }

        if (simpleMushroom != null)
        {
            

            if (simpleMushroom.simpleMushroomPickedUp == true)
            {

                takeItem();
                simpleMushroom.simpleMushroomPickedUp = false;
                /*if (UItoClose.keyToCloseIsPressed)
                {
                    Destroy(this.gameObject);
                    //UItoClose.keyToCloseIsPressed = false;
                    simpleMushroom.mushroomPickedUp = false;
                    
                }*/
            }
        }

        if (brownMushroom != null)
        {
            if (brownMushroom.brownMushroomPickedUp == true)
            {

                takeItem();
                brownMushroom.brownMushroomPickedUp = false;
            }
        }

        if(redMushroom != null)
        {
            if (redMushroom.redMushroomPickedUp == true)
            {
                /*Player.inventory.Add(this);
                itemUI.SetActive(true);
                playerMove.enabled = false;
                Destroy(this.gameObject);*/
                takeItem();
                redMushroom.redMushroomPickedUp = false;
            }
        }
    }

    private void takeItem()
    {
        Player.inventory.Add(this);
        itemUI.SetActive(true);
        playerMove.enabled = false;
        Destroy(this.gameObject);
    }

    private void takeMultipleItems(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Player.inventory.Add(this);
        }
        itemUI.SetActive(true);
        playerMove.enabled = false;
        Destroy(this.gameObject);
    }
}


public enum collectableType
{
    NONE,SIMPLEMUSHROOM,BROWNMUSHROOM,REDMUSHROOM,ARMOR,RUNNINGBOOTS,LOCKPICK
}