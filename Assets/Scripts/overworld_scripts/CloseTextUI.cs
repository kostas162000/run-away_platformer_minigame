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
    private BootsChestInteract item;
    private SimpleChestMushroomInteract mushItem;

    [SerializeField] private ItemUIPopUpController UIToClose;
    // Start is called before the first frame update
    void Start()
    {
        if (itemPivot != null)
        {
            simpleMushroom = itemPivot.GetComponent<SimpleMushroomInteract>();
            item = itemPivot.GetComponent<BootsChestInteract>();
            mushItem = itemPivot.GetComponent<SimpleChestMushroomInteract>();
            brownMushroom = itemPivot.GetComponent<BrownMushroomInteract>();
            redMushroom = itemPivot.GetComponent<RedMushroomInteract>();
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
                if (item != null)
                {
                    item.InteractWithBootsChest = false;
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
            }
        }

    }
}
