using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoScript : MonoBehaviour
{
    public WeaponSwitching weaponManager;
    public Text ammoText;
    public GameObject weaponHolder;

    void Start() {
        weaponManager = weaponHolder.GetComponent<WeaponSwitching>();
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponManager.currentWeaponInfiniteAmmo) {
            ammoText.text = "∞/∞";
        } else {
            ammoText.text = weaponManager.currentWeaponAmmo.ToString() + "/" + weaponManager.currentWeaponMaxAmmo.ToString();
        }
    }
}
