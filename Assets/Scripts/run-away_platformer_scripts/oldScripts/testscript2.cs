using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript2 : MonoBehaviour
{
    private CharacterController charController;

    public float speed;
    public float jump;
    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float Xaxis = Input.GetAxis("Horizontal") * speed;
        float Yaxis = Input.GetAxis("Vertical") * jump;
       /*transform.Translate(Xaxis * Time.deltaTime , Yaxis * Time.deltaTime, 0);*/
        
        Vector2 movement = new Vector2(Xaxis, Yaxis);
        movement = movement * Time.deltaTime;

        movement = transform.TransformDirection(movement);

        charController.Move(movement);

    }
}
