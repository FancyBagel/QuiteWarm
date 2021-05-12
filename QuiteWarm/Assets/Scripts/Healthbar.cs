using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Image border;

    public void SetActive(bool status) {
        var tempColor1 = fill.color;
        var tempColor2 = border.color;
        int transparent;
        if (status == true)
            transparent = 255;
        else
            transparent = 0;
        tempColor1.a = transparent;
        tempColor2.a = transparent;
        fill.color = tempColor1;
        border.color = tempColor2;
    }

    public void SetMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health) {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
