using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInventory : MonoBehaviour
{
    public bool threeRedMushrooms = false;
    public int totalCount;

    public Inventory inventory;

    
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
        totalCount = 0;
        foreach (Inventory.Slot slot in inventory.slots)
        {
            if (slot.type == collectableType.REDMUSHROOM)
            {
                totalCount += slot.count;
                if (totalCount >= 3)
                {
                    threeRedMushrooms = true;
                }
            }
        }

    }
}
