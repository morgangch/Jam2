using UnityEngine;
using UnityEngine.SceneManagement;

public class exit_door : MonoBehaviour
{
    public bool hasKey = true; // Variable pour savoir si l'objet possède la clé
    public GameObject player; // Référence au GameObject du joueur
    public string interactKey = "e"; // Touche pour interagir
    public float interactionDistance = 2f; // Distance maximale d'interaction
    public GameObject key;

    void Update()
    {
        if (Input.GetKeyDown(interactKey) && player.GetComponent<PlayerMovement>().Has_Key_2) {
           // Lance un rayon depuis la caméra du joueur
            RaycastHit hit;
            if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, interactionDistance)) {
                if (hit.collider.gameObject != key) {
                    return;
                }
                if (hasKey) {
                    key.SetActive(false);
                    win();
                }
            }
        }
    }
    void win()
    {
        SceneManager.LoadScene("Win");
    }   
}

