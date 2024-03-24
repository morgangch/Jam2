using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneToLoad;
    public GameObject mainMenu;
    
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Single);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Main_Scene")
        {
            // Une fois la scène "MainScene" chargée, vous pouvez appeler la génération du labyrinthe ici
            return;
            //GenerateLabyrinth();
        }
    }

    private void GenerateLabyrinth()
    {
        // Vous pouvez ici appeler la fonction pour générer le labyrinthe
        // Assurez-vous que le script LabyrinthGenerator est attaché à un GameObject dans la scène "MainScene"
        GameObject labyrinthGeneratorObject = GameObject.Find("LabyrinthGenerator");
        if (labyrinthGeneratorObject != null)
        {
            LabyrinthGenerator labyrinthGenerator = labyrinthGeneratorObject.GetComponent<LabyrinthGenerator>();
            if (labyrinthGenerator != null)
            {
                labyrinthGenerator.GenerateLabyrinth(0, 0);
            }
            else
            {
                Debug.LogError("LabyrinthGenerator script not found on the object.");
            }
        }
        else
        {
            Debug.LogError("LabyrinthGenerator object not found in the scene.");
        }
    }
}
