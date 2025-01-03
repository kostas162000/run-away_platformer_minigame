using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mercant : MonoBehaviour , interactable
{
    [SerializeField] Dialog dialog;
    public void Interact()
    {

        StartCoroutine(dialogmanag.Instance.showdialog(dialog));
    }
}
