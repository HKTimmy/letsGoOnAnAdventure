using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manaBar : MonoBehaviour
{
    public Slider slider;
    public int maxMana = 3;
    public int currentMana = 3;

    public gameMaster gm;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameMaster>();
        SetMana(gm.loadMana);

    }


    public void SetMana(int mana)
    {
        slider.value = mana;
        currentMana = mana;
        
    }

    public void SpendMana()
    {
        currentMana = currentMana - 1;
        SetMana(currentMana);
    }
}