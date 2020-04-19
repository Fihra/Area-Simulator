using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        Debug.Log("Set Max Health: " + health);
        slider.maxValue = SpacePlayer.playerHealth;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        Debug.Log("Set Health: " + health);
        slider.value = health;
    }
}
