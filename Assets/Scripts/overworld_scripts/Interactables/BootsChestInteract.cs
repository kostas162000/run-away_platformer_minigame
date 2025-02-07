using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsChestInteract : MonoBehaviour
{
    //public static bool playerPressedButton;
    public bool bootsPickedUp=false;

    [SerializeField] private GameObject interactableKeyText;
    public bool InteractWithBootsChest = false;

    //[SerializeField] private GameObject itemUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interactableKeyText.activeSelf && InteractWithBootsChest == true)
        {
            OpenChest();
        }

       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Debug.Log("Player is in collider");
            interactableKeyText.SetActive(true);
            InteractWithBootsChest = true;
        }
        
    }

    private void OpenChest()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //if (PlayerInChest)
            //{
            
            interactableKeyText.SetActive(false);

            //playerPressedButton = true;
            //itemUI.SetActive(true);
            //Debug.Log("Player openned chest");
            InteractWithBootsChest = false;
            bootsPickedUp = true;
            //}
        }
    }
}
