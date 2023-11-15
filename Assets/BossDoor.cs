using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    [SerializeField] GameObject bossDoor;
    [SerializeField] GameObject bossEnemies;
    [SerializeField] AudioClip doorsound;
    private AudioSource mySource;
    bool hasOpened = false;
    bool hasClosed = false;
    private void Start()
    {
        mySource= GetComponent<AudioSource>();
        mySource.clip = doorsound;
    }
    private void Update()
    {
        Enemy[] enemyList = FindObjectsOfType<Enemy>();
        if (enemyList.Length == 0 && !hasOpened)
        {   
            bossEnemies.SetActive(true);
            bossDoor.SetActive(false);
            mySource.Play();

            hasOpened= true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasClosed)
        {
            bossDoor.SetActive(true);
            mySource.Play();
            hasClosed= true;
        }
        print("hi");
 
    }
}
