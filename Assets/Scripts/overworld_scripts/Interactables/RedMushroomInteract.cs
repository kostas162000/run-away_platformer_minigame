using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMushroomInteract : MonoBehaviour
{
    //private bool PlayerInChest;
    public bool redMushroomPickedUp = false;

    [SerializeField] private GameObject interactableKeyText;

    public bool InteractWithRedMushroom = false;

    //[SerializeField] private GameObject itemUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (interactableKeyText.activeSelf && InteractWithRedMushroom == true)
        {
            HarvestMushroom();
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactableKeyText.SetActive(true);
            InteractWithRedMushroom = true;
        }

    }

    private void HarvestMushroom()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //itemUI.SetActive(true);
            interactableKeyText.SetActive(false);
            //Debug.Log("Player harvested mushroom");
            redMushroomPickedUp = true;
            InteractWithRedMushroom = false;
        }
    }
}
