using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    public int currentWeaponAmmo = 1;
    public int currentWeaponMaxAmmo = 10;
    public bool currentWeaponInfiniteAmmo = false;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }

        if (previousSelectedWeapon != selectedWeapon)
            SelectWeapon();

        updateAmmoValues();
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            
            i++;
        }
    }

    void updateAmmoValues() {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon) {
                Shooting w_shooting = weapon.GetComponent<Shooting>();
                currentWeaponAmmo = w_shooting.currentAmmo;
                currentWeaponMaxAmmo = w_shooting.maxAmmo;
                currentWeaponInfiniteAmmo = w_shooting.infiniteAmmo;
            }
            
            i++;
        }
    }

    public void addAmmoToRandWeapon(int value) {

        int numberOfWeapons = 0;

        foreach (Transform weapon in transform)
        {
            numberOfWeapons++;
        }

        int weaponToBeGiven = Random.Range(0, numberOfWeapons);

        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == weaponToBeGiven) {
                Shooting w_shooting = weapon.GetComponent<Shooting>();
                w_shooting.currentAmmo += value;
                if (w_shooting.currentAmmo > w_shooting.maxAmmo) 
                    w_shooting.currentAmmo = w_shooting.maxAmmo;
            }
            
            i++;
        }
    }

    public void saveWeaponAmmo() {
        int i = 0;
        string savePath = PlayerPrefs.GetString("CurrentSlot", "Slot 1") + "/Weapons/";
        foreach (Transform weapon in transform)
        {
            
            Shooting w_shooting = weapon.GetComponent<Shooting>();
            
            PlayerPrefs.SetInt(savePath + i.ToString(), w_shooting.currentAmmo);
            i++;
        }
    }

    public void loadWeaponAmmo() {
        int i = 0;
        string savePath = PlayerPrefs.GetString("CurrentSlot", "Slot 1") + "/Weapons/";
        foreach (Transform weapon in transform)
        {
            
            Shooting w_shooting = weapon.GetComponent<Shooting>();
            
            w_shooting.currentAmmo = PlayerPrefs.GetInt(savePath + i.ToString(), w_shooting.maxAmmo);
            
            i++;
        }
    }
}
