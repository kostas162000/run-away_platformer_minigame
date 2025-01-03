using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    public int scenebuildindex;


    //level move zoned enter,if colider is player
    // move game to another scene
    private void OnTriggerEnter2D(Collider2D other) // game object that walked into the area

    {
        print("trigger entered");

        if(other.tag == "Player")
        {
 print ("switching scene to " +  scenebuildindex);
            SceneManager
                .LoadScene(scenebuildindex, LoadSceneMode.Single);
        }
    }
}
