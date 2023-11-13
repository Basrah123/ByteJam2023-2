using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenemanager : MonoBehaviour
{
    
    [SerializeField] private int level1index;
    [SerializeField] private int deathScreenindex;
    public void startGame()
    {
        SceneManager.LoadScene(level1index);
    }
    public void loadDeathScene()
    {
        SceneManager.LoadScene(deathScreenindex);
    }
}
