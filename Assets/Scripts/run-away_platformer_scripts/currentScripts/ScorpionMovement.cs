using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    private Vector3 initialScale;
    private bool movingLeft;
    //private bool movingRight;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingLeft)
        {
            transform.localScale = new Vector2(-5.466409f, 5.227953f);
            if (transform.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                movingLeft = !movingLeft;
        }
        else
        {
            transform.localScale = new Vector2(5.466409f, 5.227953f);
            if (transform.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                movingLeft = !movingLeft;
        }      
    }

    void MoveInDirection(int direction)
    {

        transform.localScale = new Vector3(Mathf.Abs(initialScale.x) * direction, 
            initialScale.y, initialScale.z);

        float Xaxis = transform.position.x + Time.deltaTime * direction * speed;

        transform.position = new Vector2(Xaxis, transform.position.y);
     }
}
