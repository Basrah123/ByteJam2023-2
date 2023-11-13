using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIUpdater : MonoBehaviour
{
    [SerializeField] Text HPTextCurrent;
    [SerializeField] Text HPTextMax;
    [SerializeField] Text CurrentAmmo;
    [SerializeField] Text MaxAmmo;
    [SerializeField] Text Armor;
    [SerializeField] Text EnemiesRemaining;
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        int hp = player.GetComponent<Health>().maxHealth;
        int maxAmmo = player.GetComponentInChildren<KeyBoard>().maxClipSize;
        int armor = player.GetComponent<Health>().armor;
        initializeUI(hp, maxAmmo,armor);
        

    }
    public void initializeUI(int maxHP, int maxAmmo, int armor)
    {
        HPTextCurrent.text = maxHP.ToString();
        HPTextMax.text = maxHP.ToString();
        CurrentAmmo.text = maxAmmo.ToString();
        MaxAmmo.text = maxAmmo.ToString();
        Armor.text = armor.ToString();
        UpdateEnemies();
    }
    public void UpdateHP(int newHP)
    {
        HPTextCurrent.text = newHP.ToString();
    }
    
    public void UpdateCurrentAmmo(int newAmmo)
    {
        CurrentAmmo.text = newAmmo.ToString();
    }
    public void UpdateArmor(int newArmor)
    {
        Armor.text = newArmor.ToString();
    }
    public void UpdateEnemies()
    {
        Enemy[] EnemyList = FindObjectsOfType<Enemy>();
        int aliveEnemies = 0;
        foreach (Enemy enemy in EnemyList)
        {
            if (enemy.isAlive) { aliveEnemies++; }
        }
        EnemiesRemaining.text = aliveEnemies.ToString();
    }
}
