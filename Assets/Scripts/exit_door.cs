using UnityEngine;
using UnityEngine.SceneManagement;

public class exit_door : MonoBehaviour
{
    public Camera playerCamera; // Référence à la caméra du joueur
    public string interactKey = "e"; // Touche pour interagir
    public float interactionDistance = 4f; // Distance maximale d'interaction
    public GameObject key;
    public GameObject key_2;
    public LayerMask interactableLayer; // Layer contenant les objets avec lesquels le joueur peut interagir

    void win()
    {
        SceneManager.LoadScene("Win");
    }   

    void Update()
    {
        if (Input.GetKeyDown(interactKey) && PlayerPrefs.GetInt("has_key_2") == 1) {
           // Lance un rayon depuis la caméra du joueur
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionDistance, interactableLayer)) {
                if (hit.collider.gameObject != key && hit.collider.gameObject != key_2) {
                    return;
                }
                win();
            }
        }
    }
}
