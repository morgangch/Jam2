using UnityEngine;

public class crate_key : MonoBehaviour
{
    public bool hasKey = true; // Variable pour savoir si l'objet possède la clé
    public Camera player; // Référence au GameObject du joueur
    public string interactKey = "e"; // Touche pour interagir
    public float interactionDistance = 2f; // Distance maximale d'interaction
    public GameObject key;
    public LayerMask interactableLayer; // Layer contenant les objets avec lesquels le joueur peut interagir

    void Update()
    {
        if (Input.GetKeyDown(interactKey) && PlayerPrefs.GetInt("has_key_1") == 1) {
            // Lance un rayon depuis la caméra du joueur
            RaycastHit hit;
            if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, interactionDistance, interactableLayer)) {
                if (hit.collider.gameObject != key) {
                    return;
                }
                // Vérifie si le rayon a touché cet objet
                // Si l'objet a la clé et que le joueur n'a pas déjà la clé
                if (hasKey && PlayerPrefs.GetInt("has_key_2") == 0) {
                    // Fait disparaître l'objet
                    key.SetActive(false);
                    PlayerPrefs.SetInt("has_key_1", 0);
                    PlayerPrefs.SetInt("has_key_2", 1);
                }
            }
        }
    }
}

