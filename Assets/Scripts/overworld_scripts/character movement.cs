using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementcharacter : MonoBehaviour
{
    //[SerializeField] private Transform outsideCave;
    [SerializeField] private Transform insideCave;

    public float moveSpeed = 5f;
    private bool ismoving;
    public Rigidbody2D rb;
    public Animator animator;
    public LayerMask solidobjectslayer;
    public LayerMask InteractablesLayer;
    public LayerMask transportLayer;
    private Vector2 movement;
    private bool ex;
    public LockPickingMinigame lockPickingMinigame; // Drag the minigame GameObject here in the Inspector
                                                    // Update is called once per frame
    public void HandleUpdate()   //  frames can change wich makes it unrellable
    {
        if (!ismoving)   
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            if (movement != Vector2.zero) {
                var targetPos = rb.transform.position;
                targetPos.x += movement.x; // saving the move to the target variable
                targetPos.y += movement.y;


                
                    if (IsWalkable(targetPos)) // an einai true run it then start moving there 
                    {
                        StartCoroutine(move(targetPos)); // coroutine to run if true 
                    }
                
            }
        }
       animator.SetFloat("Horizontal", movement.x); // animation for movement right/left
       animator.SetFloat("Vertical", movement.y);  // animation for movement up/down 
       animator.SetFloat("Speed", movement.sqrMagnitude); // idle animation movement 
        
        if (Input.GetKeyDown(KeyCode.E)) //interact with key E  
            Interact();

       
    }
    void Interact()
    {
        var facingDir = new Vector3(animator.GetFloat("Horizontal"), animator.GetFloat("Vertical"));
        var interactPos = transform.position + facingDir ;


        Debug.DrawLine(transform.position, interactPos, Color.red, 1f);

        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, InteractablesLayer); //if in the end of the line we created does ovelap with the npc then 
        if(collider!= null)
        {
           collider.GetComponent<interactable>()?.Interact();//if its interactable run this interact

        }


       /* void OnTriggerEnter(Collider other) {


        if (other.CompareTag("Chest")) // Check if it's the chest
        {
            lockPickingMinigame.StartMinigame();
        }
    }*/

}
    IEnumerator move (Vector3 targetPos)//coroutine faction
    {
        ismoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon) {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.fixedDeltaTime);
            //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            yield return null;
        }
        transform.position = targetPos;
        ismoving = false;
    } // coroutine faction 
  
    private bool IsWalkable( Vector3 targetPos)
    {
        // if you are going to overlap with solid object or interactable you cant walk

        if (Physics2D.OverlapCircle(targetPos,0.1f,solidobjectslayer | InteractablesLayer ) != null) {
            return false; //i dont want to walk if overlapping
        }//taerget overlaps solid obj we cant not walk there
        return true;
    }


   


   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "OutsideEntrance")
        {
         //   ex = true;
            Debug.Log("Enter");
            transform.position = insideCave.transform.position;
            //rb.MovePosition(insideCave.transform.position);
            //rb.transform.position = new Vector3(0,0,-1);
            //StartCoroutine(move(rb.transform.position));
        }
    }*/
}