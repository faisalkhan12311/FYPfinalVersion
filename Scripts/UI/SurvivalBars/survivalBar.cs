using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class survivalBar : MonoBehaviour
{
    public float healthReduceOverTime, thirstReduceOverTime, hungerReduceOverTime;
    public float Health, Thirst, Hunger;
    public Slider healthBar, thirstBar, hungerBar ;
    public float MaxThirst;

    public float minAmount = 5f;
    //public float sprintSpeed = 5f;

    Rigidbody mybody;

    public void Start()
    {
        //Health = maxHealth;
        mybody = GetComponent<Rigidbody>();
        healthBar.maxValue = Health;
        thirstBar.maxValue = Thirst;
        hungerBar.maxValue = Hunger;


        UpdateUI();
    }
    public void Update()
    {
        CalculateValue();

    }
    public void Die()
    {
        print("You have died of Hunger/Thirst");
    }
    public void CalculateValue()
    {
        Hunger -= hungerReduceOverTime * Time.deltaTime;

        if (Hunger <= minAmount || Thirst <= minAmount)
        {
            Health -= healthReduceOverTime * Time.deltaTime; 
        }
        

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Thirst -= thirstReduceOverTime * Time.deltaTime;
        }
        else
        {
            //thirstBar.maxValue = Thirst - 20f;
            //float X = Thirst;
            if(Thirst >= 0 && Thirst < 50)
            Thirst += thirstReduceOverTime * Time.deltaTime;
        }

        if (Health <= 0)
        {
            Die();
        }
        UpdateUI();

    }
    public void UpdateUI()
    {
        Health = Mathf.Clamp(Health, 0, 100f);
        Thirst = Mathf.Clamp(Thirst, 0, 100f);
        Hunger = Mathf.Clamp(Hunger, 0, 100f);

        healthBar.value = Health;
        thirstBar.value = Thirst;
        hungerBar.value = Hunger;
    }

    //public float amnt;
    public void TakeDmg(float amnt)
    {
        Health -= amnt;
        UpdateUI();
    }
}
