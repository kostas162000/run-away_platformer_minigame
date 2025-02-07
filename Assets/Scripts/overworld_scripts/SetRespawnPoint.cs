using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SetRespawnPoint : MonoBehaviour
{
    public static Vector3 RespawnPoint;
    //private bool inRespawnPoint = false;
    [SerializeField] private GameObject interactableKeyText;
    // Start is called before the first frame update
    void Start()
    {
        RespawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (inRespawnPoint)
        if (interactableKeyText.activeSelf)
            SetRespawn();
    }

    private void SetRespawn()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RespawnPoint = transform.position;
            //inRespawnPoint=false;
            interactableKeyText.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            interactableKeyText.SetActive(true);
            //inRespawnPoint = true; //when player triggers with these objects dies, so state is set to dead
        }
    }
}
