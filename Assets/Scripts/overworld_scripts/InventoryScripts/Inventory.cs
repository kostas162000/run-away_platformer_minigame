using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Inventory 
{
    [System.Serializable]
    public class Slot 
    {
        public collectableType type;
        public int count;
        public int max;

        public Sprite icon;

        public Slot()
        {
            type = collectableType.NONE;
            count = 0;
            max = 5;
        }

        public bool canAddItem()
        {
            if(count < max)
            {
                return true;
            }
            else
            return false;
        }

        public void addItem(Collectables item)
        {
            this.type = item.type;
            this.icon = item.icon;
            count++;
        }

        public void removeItem()
        {
            count--;

            if(count == 0)
            {
                icon = null;
                type = collectableType.NONE;
            }
        }
    }

    public List<Slot> slots = new List<Slot>();
    
    public Inventory(int numslots)
    {
        for(int i = 0;  i < numslots; i++)
        {
            Slot slot = new Slot();
            slots.Add(new Slot());
        }
    }

    public void Add(Collectables item) 
    {
        foreach (Slot slot in slots)
        {
            if (slot.type == item.type && slot.canAddItem())
            {
                slot.addItem(item);
                return;
            }
        }

        foreach(Slot slot in slots)
        {
            if (slot.type == collectableType.NONE)
            {
                slot.addItem(item);
                return;
            }
        }
    }
}


//For everyone having the problem to pick up the item and still not showing in inventory after hours of comparing scripts to the video. 
//For me it was the script for player "player.cs" where she added (21) as inventory slots (line 11). But I copied more that 21.
//I decided to make 24 slots in inventory so you simply have to change it to (24) in the player script! Worked for me! 