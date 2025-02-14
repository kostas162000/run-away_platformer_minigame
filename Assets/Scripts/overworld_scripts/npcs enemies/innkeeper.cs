using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class innkeeper : MonoBehaviour, interactable
{
    [SerializeField] private int dialogueID = 0;

    [SerializeField] Dialog dialog;
    [SerializeField] Dialog dialog1;
    public void Interact()
    {
        if (Gamecontroller.questCompletedID == 0 || Gamecontroller.questCompletedID == 1)
            StartCoroutine(dialogmanag.Instance.showdialog(dialog));

        if (Gamecontroller.questCompletedID == 2)
        {
            if (dialogueID == 0)
            {
                StartCoroutine(dialogmanag.Instance.showdialog(dialog1));
                Gamecontroller.questCompletedID = 3;
            }
        }
    }
}
