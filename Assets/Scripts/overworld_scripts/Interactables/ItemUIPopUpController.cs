using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUIPopUpController : MonoBehaviour
{
    [SerializeField] private playerTestMovement playerMove;
    [SerializeField] private GameObject SimpleMushroomUI;
    [SerializeField] private GameObject BrownMushroomUI;
    [SerializeField] private GameObject RedMushroomUI;
    [SerializeField] private GameObject RunningBootsUI;

    [SerializeField] private GameObject acquiredPickLockToolUI;

    [SerializeField] private GameObject failedLockPickUI;

    public bool keyToCloseIsPressed=false;
    private GameObject pivot;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SimpleMushroomUI.activeSelf)
        {
            pivot = SimpleMushroomUI;
            //keyToCloseUI();
        }

        else if (BrownMushroomUI.activeSelf)
        {
            pivot = BrownMushroomUI;
        }

        else if (RedMushroomUI.activeSelf)
            pivot = RedMushroomUI;

        else if (RunningBootsUI.activeSelf)
            pivot = RunningBootsUI;

        else if (failedLockPickUI.activeSelf)
            pivot = failedLockPickUI;

        else if(acquiredPickLockToolUI)
            pivot = acquiredPickLockToolUI;

        else pivot = null;

        if(pivot != null)
        keyToCloseUI();

        //Debug.Log(pivot);
        //Debug.Log(keyToCloseIsPressed);

    }


    private void keyToCloseUI()
    {
        if (Input.GetKeyDown(KeyCode.E) /*&& pivot != null*/)
        { 
            pivot.SetActive(false);
            playerMove.enabled = true;
            keyToCloseIsPressed = true;
        }

        
    }
}
