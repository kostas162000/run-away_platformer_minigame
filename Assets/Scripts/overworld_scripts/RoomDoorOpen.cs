using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoorOpen : MonoBehaviour
{

    [SerializeField] private playerInventory player;
    [SerializeField] private GameObject colliderForEnteringRoom;
    public GameObject textToOpenDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(player.keyForRoomAcquired == true)
                colliderForEnteringRoom.SetActive(true);
        }
    }

    
}
