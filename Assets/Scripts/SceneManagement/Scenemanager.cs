using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenemanager : MonoBehaviour
{
    
    [SerializeField] int level1index;
    [SerializeField] int deathScreenindex;
    public void startGame()
    {
        SceneManager.LoadScene(level1index);
    }
    public void loadDeathScene()
    {
        SceneManager.LoadScene(deathScreenindex);
    }
}
