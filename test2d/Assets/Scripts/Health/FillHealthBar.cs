using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillHealthBar : MonoBehaviour
{
    public Health health;
    //public Text healthText;
    //public Image playerBar;
    private Slider slider;


    void Awake()
    {        
       slider = GetComponent<Slider>();
        slider.maxValue = health.maxHealth;
        slider.value = slider.maxValue;
    }


    void Update()
    {
       // healthText.text = "  " + health.currentHealth + "%";
        if (health.currentHealth > health.maxHealth) health.currentHealth = health.maxHealth;
         float fillValue = health.currentHealth;
         slider.value = fillValue;
       // HealthBarFiller();

    }

    /*void HealthBarFiller()
    {
        playerBar.fillAmount = health.currentHealth / health.maxHealth;
    }*/
}
