using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class hpbar : MonoBehaviour
{

    public SlimeMovement[] sm;
    public int initialSlimeAmout;
    [SerializeField]
    private int currentHealth;
    public event Action<float> OnHealthPercentage = delegate { };



    private void OnEnable()
    {
        sm = FindObjectsOfType<SlimeMovement>();


        for (int i = 0; i < sm.Length; i++)
        {
            initialSlimeAmout++;
        }
        currentHealth = initialSlimeAmout;
    }

    public void modifyHealth(int amount)
    {
        currentHealth += amount;

        float currentHealthpct = (float)currentHealth / (float)initialSlimeAmout;

        OnHealthPercentage(currentHealthpct);

    }

    public void decreaseHealth(int amount)
    {
        currentHealth -= amount;
        Debug.Log("função");
        float currentHealthpct = (float)currentHealth / (float)initialSlimeAmout;

        OnHealthPercentage(currentHealthpct);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "inimigoBloco")
        {
            Destroy(collision.gameObject);
            decreaseHealth(1);
        }
    }
}
