using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogmanag : MonoBehaviour
{
    [SerializeField] GameObject dialogbox;
    [SerializeField] Text dialogtext;
   [SerializeField] int letterspersecond;
    public event Action OnShowDialog;
    public event Action OnHideDialog;
    public static   dialogmanag Instance {  get; private set; } /// everybody can use this Instance is 
    private void Awake()
    {
       Instance = this;
    }

    Dialog dialog;
    int currentline = 0;
    bool istyping;

    
    
    public IEnumerator showdialog(Dialog  dialog)
    {
        yield return new WaitForEndOfFrame();  
        OnShowDialog?.Invoke();
    this.dialog= dialog; // to use as global variable
    dialogbox.SetActive(true);
        StartCoroutine(TYPEDIALOG(dialog.Lines[0]));
    
    
    }

    public void HandleUpdate()
    {
        if (Input.GetKeyUp(KeyCode.E) && !istyping) // an gekinisa eidi tin sizitis kai patisa to koumbi e 
        {

            ++currentline; // add one number 
            if(currentline < dialog.Lines.Count)// an einai ligotero apo to olo arithmo lines dige epomeno line
                    {
                StartCoroutine(TYPEDIALOG(dialog.Lines[currentline]));// deige epomeno line

            }
            else
            {
                dialogbox.SetActive(false); // turn off dialogbox
                currentline = 0;
                OnHideDialog?.Invoke(); // hide it
            }

        }
    }

    public IEnumerator TYPEDIALOG(string line)
    {
        istyping = true;
        dialogtext.text = " ";
        foreach(var letter in line.ToCharArray())
        {
            dialogtext.text += letter;
            yield return new WaitForSeconds(1f / letterspersecond);
        }// its going to show the text latter by letter like pokemon

        istyping =false;
        
    }
}
