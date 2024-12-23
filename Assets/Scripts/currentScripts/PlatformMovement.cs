using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform upperEdge;
    [SerializeField] private Transform lowerEdge;
    private bool movingDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movingDown)
        {
            if (transform.position.y >= lowerEdge.position.y)
                MoveInDirection(-1);
            else
                movingDown = !movingDown;
        }
        else
        {
            if (transform.position.y <= upperEdge.position.y)
                MoveInDirection(1);
            else
                movingDown = !movingDown;
        }
    }

    void MoveInDirection(int direction)
    {

        /*transform.localScale = new Vector3(Mathf.Abs(initialScale.x) * direction,
            initialScale.y, initialScale.z);
        */
        float Yaxis = transform.position.y + Time.deltaTime * direction * speed;

        transform.position = new Vector2(transform.position.x,Yaxis);
    }
}
