using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownMushroomInteract : MonoBehaviour
{
    //private bool PlayerInChest;
    public bool brownMushroomPickedUp = false;

    [SerializeField] private GameObject interactableKeyText;

    public bool InteractWithBrownMushroom = false;

    //[SerializeField] private GameObject itemUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (interactableKeyText.activeSelf && InteractWithBrownMushroom == true)
        {
            HarvestMushroom();
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactableKeyText.SetActive(true);
            InteractWithBrownMushroom = true;
        }

    }

    private void HarvestMushroom()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //itemUI.SetActive(true);
            interactableKeyText.SetActive(false);
            //Debug.Log("Player harvested mushroom");
            brownMushroomPickedUp = true;
            InteractWithBrownMushroom = false;
        }
    }
}
