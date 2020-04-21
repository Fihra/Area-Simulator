using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EarthHealthManager : MonoBehaviour
{
    public Slider slider;

    public void SetEarthMaxHealth(int health)
    {
        //Debug.Log("Set Max Health: " + health);
        slider.maxValue = EarthBorder.earthHealth;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        //Debug.Log("Set Health: " + health);
        slider.value = health;
    }
}
