using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject sword;
    public GameObject dagger;

    [SerializeField] private GameObject daggerMenu;
    [SerializeField] private GameObject swordMenu;

    public int weapon_id;
    // Start is called before the first frame update
    void Start()
    {
        weapon_id = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (weapon_id==1) 
        {
            dagger.SetActive(true);
            sword.SetActive(false);

            daggerMenu.SetActive(true);
            swordMenu.SetActive(false);
        }
        if (weapon_id==2)
        {
            sword.SetActive(true);
            dagger.SetActive(false);

            swordMenu.SetActive(true);
            daggerMenu.SetActive(false);
        }
    }

    public void changeWeapon()
    {
        if (weapon_id == 1)
        {
            weapon_id = 2;
        }

        else if (weapon_id == 2)
        {
            weapon_id = 1;
        }
    }
}
