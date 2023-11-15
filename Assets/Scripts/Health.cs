using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] bool debugMode = false;
    [SerializeField] bool isPlayer = false;
    [SerializeField] ParticleSystem bloodEffect;
    public int maxHealth = 100; 
    public int currentHealth;
    public int damage = 10; 
    public int healing = 10; 
    public int testHealAmount = 20; 
    public int testDamageAmount = 30;
    public int armor = 0;

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
    public void Damage(int amount)
    {
        if(armor > 0)
        {
            UpdateArmor(-amount);
        }
        else
        {
            DamageHealth(amount);
        }
    }
    public void UpdateArmor(int amount)
    {
        
        int newArmor = armor + amount;

        if(amount > 0)
        {
            armor += amount;
        }
        if(amount < 0)
        {
            armor = Mathf.Max(newArmor, 0);

            if(armor == 0)
            {
                DamageHealth(newArmor);
            }
            else
            {
                GetComponent<DamageEffect>().ArmorDamage();
            }
            
        }
        FindObjectOfType<UIUpdater>().UpdateArmor(armor);
    }
    private void Update()
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

    public void setHealth(int amount)
    {
        currentHealth = amount;
        maxHealth = amount;
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

        currentHealth -= damageAmount;
        currentHealth = Mathf.Max(currentHealth, 0);
        if (isPlayer)
        {
            FindObjectOfType<UIUpdater>().UpdateHP(currentHealth);
            HealthDamageEffect();
        }
        else
        {
            bloodEffect.Play();
        }

        if (currentHealth <= 0)
        {
            Death();
        }
    }
    private void HealthDamageEffect()
    {
        GetComponent<DamageEffect>().HpDamage();
    }

    private void Death()
    {   
        if(isPlayer)
        {
            Scenemanager mySceneManager = FindObjectOfType<Scenemanager>();
            if (mySceneManager != null)
            {
                mySceneManager.loadDeathScene();
                print("dead as hell");
            }
            else
            {
                print("scenemanager not found");
            }
        }
        else
        {
            Enemy enemycomponent = GetComponent<Enemy>();
            if (enemycomponent != null)
            {
                enemycomponent.isAlive = false;
                Destroy(gameObject);
            }
            FindObjectOfType<UIUpdater>().UpdateEnemies();
        }


    }
    public bool getIsPlayer()
    {
        return isPlayer;
    }
}