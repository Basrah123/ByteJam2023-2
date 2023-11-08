using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] bool debugMode = false;
    public int maxHealth = 100; 
    public int currentHealth;
    public int damage = 10; 
    public int healing = 10; 
    public int testHealAmount = 20; 
    public int testDamageAmount = 30; 

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        int oldHealth = currentHealth;
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    void Update()
    {
        if (debugMode)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ChangeHealth(testHealAmount);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                DamageHealth(testDamageAmount);
            }
        }
    }

    public void ApplyHealing(int healAmount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
        }
    }

    public void DamageHealth(int damageAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;
            currentHealth = Mathf.Max(currentHealth, 0);
            print(currentHealth);
            if (currentHealth <= 0)
            {
                Death();
            }
        }
    }

    private void Death()
    {
        Scenemanager mySceneManager = FindObjectOfType<Scenemanager>();
        if (mySceneManager != null)
        {
            //mySceneManager.loadDeathScene();
            print("dead as hell");
        }
        else
        {
            print("scenemanager not found");
        }

    }
}