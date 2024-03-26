using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class Win : MonoBehaviour
{
    public GameObject pauseMenuUI;
    void Start()
    {
        pauseMenuUI.SetActive(true);
    }
    void Update()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
