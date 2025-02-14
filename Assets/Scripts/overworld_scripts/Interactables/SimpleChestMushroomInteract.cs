using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleChestMushroomInteract : MonoBehaviour
{
    
    public bool simpleMushChestPickedUp = false;
    [SerializeField] private LockPickingMinigame lockPickingMinigame; // Drag the minigame GameObject here in the Inspector
    [SerializeField] private GameObject interactableKeyText;
    public bool InteractWithSimpleMushroomChest = false;

    //[SerializeField] private GameObject itemUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (interactableKeyText.activeSelf && InteractWithSimpleMushroomChest == true)
        {
            OpenChest();
        }

        //Debug.Log($"original mushroom in chest:{simpleMushChestPickedUp}");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Player is in collider");
            interactableKeyText.SetActive(true);
            InteractWithSimpleMushroomChest = true;
        }

    }

    private void OpenChest()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //if (PlayerInChest)
            //{
            lockPickingMinigame.StartMinigame();// EGO TO EBALA AUTO KAI ENERGOPOISI TO MINIGAME
            interactableKeyText.SetActive(false);
            
            //itemUI.SetActive(true);
            //Debug.Log("Player openned chest");
              InteractWithSimpleMushroomChest = false;
            simpleMushChestPickedUp = true;
            //}
        }
    }
}
