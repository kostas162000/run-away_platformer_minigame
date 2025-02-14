using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInventory : MonoBehaviour
{
    //public bool threeRedMushrooms = false;
    public int redMushroomTotalCount;
    public int lockpickTotalCount;
    private int runningBootsCount;
    public static bool runningBootsEquiped;

    public Inventory inventory;

    public bool keyForRoomAcquired = false;
    
    private void Awake()
    {
        inventory = new Inventory(11);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(runningBootsEquiped);

        redMushroomTotalCount = 0;
        foreach (Inventory.Slot slot in inventory.slots)
        {
            if (slot.type == collectableType.REDMUSHROOM)
            {
                redMushroomTotalCount += slot.count;
                /*if (redMushroomTotalCount >= 3)
                {
                    threeRedMushrooms = true;
                }*/
            }
        }

        lockpickTotalCount = 0;
        foreach (Inventory.Slot slot in inventory.slots)
        {
            if (slot.type == collectableType.LOCKPICK)
            {
               lockpickTotalCount += slot.count;
                /*if (redMushroomTotalCount >= 3)
                {
                    threeRedMushrooms = true;
                }*/
            }
        }
        
        runningBootsCount = 0;
        foreach (Inventory.Slot slot in inventory.slots)
        {
            if (slot.type == collectableType.RUNNINGBOOTS)
            {
               runningBootsCount += slot.count;
                if (runningBootsCount > 0)
                {
                    runningBootsEquiped = true;
                }
            }
        }


        if (Gamecontroller.questCompletedID == 3)
            keyForRoomAcquired = true;
    }
}
