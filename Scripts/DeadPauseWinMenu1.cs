using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeadPauseWinMenu : MonoBehaviour
{
    public TMP_Text endPanel;
    public GameObject[] DeadPauseWinMenus;
    
    void Start()
    {
        DeadPauseWinMenus[0].SetActive(false);
        DeadPauseWinMenus[1].SetActive(false);
        DeadPauseWinMenus[2].SetActive(false);      
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                PauseGame();
            }
        }
    }

    public void LoseGame()
        {
            Time.timeScale = 0;
            DeadPauseWinMenus[2].SetActive(true);
        }

    public void WinGame()
        {
            Time.timeScale = 0;
            DeadPauseWinMenus[1].SetActive(true);
        }

    public void PauseGame()
        {
            Time.timeScale = 0;
            DeadPauseWinMenus[0].SetActive(true);
        }

    public void Resume()
        {
            Time.timeScale = 1;
            DeadPauseWinMenus[0].SetActive(false);
        }

    public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }

    public void Quit()
        {
            Application.Quit();
        }
    
}
