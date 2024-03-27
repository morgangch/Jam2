using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    // Fonction pour trouver tous les GameObjects ayant un script particulier
    void Start()
    {
        pauseMenuUI.SetActive(false);
        PlayerPrefs.SetInt("gameIsPaused", 0);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PlayerPrefs.GetInt("gameIsPaused") == 1)
                Resume();
            else
                Paused();
        }
    }
    void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        PlayerPrefs.SetInt("gameIsPaused", 1);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        PlayerPrefs.SetInt("gameIsPaused", 0);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
