using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Slider slider;
    public int maxHealth = 3;
    public int currentHealth;
    void Start()
    {
        //hp = GameObject.FindGameObjectWithTag("hp");
        currentHealth = maxHealth;
        SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage()
    {
        currentHealth = currentHealth - 1;
        SetHealth(currentHealth);
    }

    public void takeDeathDamage() {
        currentHealth = 0;
        SetHealth(currentHealth);
    }


    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}