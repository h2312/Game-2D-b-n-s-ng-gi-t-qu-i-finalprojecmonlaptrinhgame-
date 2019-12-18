using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public GameObject pausePanel;
    public Button ButtonRestart;


    public void PlayerDie()
    {
        StartCoroutine(ActivePausePanel());
        //pausePanel.SetActive(true);
        //StartBut.interactable = false;

    }

    IEnumerator ActivePausePanel()
    {
        
        yield return new WaitForSeconds(2);

        pausePanel.SetActive(true);
    }
    public void RestartGame()
    {
        pausePanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
