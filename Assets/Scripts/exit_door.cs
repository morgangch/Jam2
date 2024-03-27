using UnityEngine;
using UnityEngine.SceneManagement;

public class exit_door : MonoBehaviour
{
    public GameObject player; // Référence au GameObject du joueur
    public string interactKey = "e"; // Touche pour interagir
    public float interactionDistance = 2f; // Distance maximale d'interaction
    public GameObject key;
    public GameObject key_2;

    void win()
    {
        SceneManager.LoadScene("Win");
    }   
    void Update()
    {
        if (Input.GetKeyDown(interactKey) && player.GetComponent<PlayerMovement>().Has_Key_2) {
           // Lance un rayon depuis la caméra du joueur
            RaycastHit hit;
            if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, interactionDistance)) {
                if (hit.collider.gameObject != key && hit.collider.gameObject != key_2) {
                    return;
                }
                
                win();
            }
        }
    }
}

