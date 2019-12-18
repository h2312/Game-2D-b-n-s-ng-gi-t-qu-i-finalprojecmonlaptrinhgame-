using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuController : MonoBehaviour
{
    public void PlayGame1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void PlayGame2()
    {
        SceneManager.LoadScene("Level2");
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
