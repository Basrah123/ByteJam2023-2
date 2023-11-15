using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isLevelClear())
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex + 1);
        }
    }

    private bool isLevelClear()
    {
        Enemy[] enemyList = FindObjectsOfType<Enemy>();
        int enemyNum = enemyList.Length;
        if(enemyNum == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
