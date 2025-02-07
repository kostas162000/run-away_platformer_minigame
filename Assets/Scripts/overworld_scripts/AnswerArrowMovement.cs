using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerArrowMovement : MonoBehaviour
{
    [SerializeField] private Transform YESAnswer;
    [SerializeField] private Transform NOAnswer;

    public bool positiveAnswer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position = new Vector2(transform.position.x, YESAnswer.position.y);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position = new Vector2(transform.position.x, NOAnswer.position.y);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Answer();
        }
    }

    private void Answer()
    {
        if (transform.position.y == YESAnswer.position.y)
            positiveAnswer = true;

        else if (transform.position.y == NOAnswer.position.y)
            positiveAnswer = false;
    }
}
