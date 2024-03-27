using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class DifficultiesMenu : MonoBehaviour
{
    public string sceneToLoad;
    
    private void Start_Game(int width, int height)
    {
        PlayerPrefs.SetInt("width", width);
        PlayerPrefs.SetInt("height", height);
        PlayerPrefs.Save();
        SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Single);
    }
    public void PracticeMode()
    {
        PlayerPrefs.SetFloat("sprintSpeed", 14f);
        PlayerPrefs.SetFloat("walkSpeed", 7.5f);
        Start_Game(2, 2);
    }
    public void EasyMode()
    {
        Start_Game(3, 3);
    }
    public void MediumMode()
    {
        Start_Game(4, 4);
    }
    public void HardMode()
    {
        PlayerPrefs.SetFloat("sprintSpeed", 12f);
        PlayerPrefs.SetFloat("walkSpeed", 7.5f);
        Start_Game(6, 6);
    }
    public void ExtremeMode()
    {
        PlayerPrefs.SetFloat("sprintSpeed", 14f);
        PlayerPrefs.SetFloat("walkSpeed", 8f);
        Start_Game(8, 8);
    }
}
