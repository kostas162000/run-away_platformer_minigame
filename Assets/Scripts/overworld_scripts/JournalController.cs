using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalController : MonoBehaviour
{
    [SerializeField] private GameObject mushroomInfoMenu;
    [SerializeField] private GameObject mushroomInfoPage1;
    [SerializeField] private GameObject mushroomInfoPage2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMushroomInfo()
    {
        mushroomInfoMenu.SetActive(true);
    }

    public void CloseMushroomInfo()
    {
        mushroomInfoMenu.SetActive(false);
    }

    public void TurnMushroomPage()
    {
        mushroomInfoPage1.SetActive(!mushroomInfoPage1.activeSelf);
        mushroomInfoPage2.SetActive(!mushroomInfoPage2.activeSelf);
       // Debug.Log("button pressed");
    }

    /*public void TurnToMushroomPage1()
    {
        mushroomInfoPage2.SetActive(false);
        mushroomInfoPage1.SetActive(true);
        Debug.Log("button pressed");
    }*/
}
