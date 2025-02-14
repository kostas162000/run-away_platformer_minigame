using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTestMovement : MonoBehaviour
{
    //[SerializeField] private Transform insideCave;

    public float moveSpeed = 5f;
    private bool ismoving;
    public Rigidbody2D RB;
    public Animator animator;
    [SerializeField] private LayerMask solidobjectslayer;
    [SerializeField] private LayerMask InteractablesLayer;
    private Vector2 movement;
    //private Vector2 movement;

    public static bool talkedToMerchant;

    // Start is called before the first frame update
    void Start()
    {
        //RB = GetComponent<Rigidbody2D>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal"); //* moveSpeed; //initilize horizontal movement of player

        //rb.velocity = new Vector2(Xaxis, rb.velocity.y);

        movement.y = Input.GetAxis("Vertical");// * moveSpeed; //initilize horizontal movement of player

        //rb.velocity = new Vector2(movement.x, movement.y);

        //Debug.Log(movement.x);

        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("HorizontalTest", movement.x); // animation for movement right/left
        animator.SetFloat("VerticalTest", movement.y);  // animation for movement up/down 
        animator.SetFloat("SpeedTest", movement.sqrMagnitude); // idle animation movement 

        if (Input.GetKeyDown(KeyCode.E)) //interact with key E  
            Interact();
            

    }

    void FixedUpdate()
    {
        RB.MovePosition(RB.position + movement * moveSpeed * Time.fixedDeltaTime);
    }



    void Interact()
    {
        //Debug.Log("pressed E");
    
        var facingDir = new Vector3(animator.GetFloat("HorizontalTest"), animator.GetFloat("VerticalTest"));
        var interactPos = transform.position + facingDir;


        Debug.DrawLine(transform.position, interactPos, Color.red, 1f);

        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, InteractablesLayer); //if in the end of the line we created does ovelap with the npc then 
        if (collider != null)
        {
            collider.GetComponent<interactable>()?.Interact();//if its interactable run this interact

        }

        /*if (collider.gameObject.tag == "Merchant")
            talkedToMerchant = true;
        else if (collider.gameObject.tag == null)
            talkedToMerchant = false;
        */
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "OutsideEntrance")
        {
            Debug.Log("Enter");
            RB.transform.position = insideCave.transform.position;
            //rb.transform.position = new Vector2(0, 0);
        }

    }*/
}
