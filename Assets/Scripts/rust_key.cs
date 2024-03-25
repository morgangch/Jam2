using UnityEngine;

public class rust_key : MonoBehaviour
{
    public bool hasKey = true; // Variable pour savoir si l'objet possède la clé
    public GameObject player; // Référence au GameObject du joueur
    public string interactKey = "e"; // Touche pour interagir
    public float interactionDistance = 2f; // Distance maximale d'interaction

    void Update()
    {
        if (Input.GetKeyDown(interactKey)) {
            // Lance un rayon depuis la caméra du joueur
            RaycastHit hit;
            if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, interactionDistance)) {
                // Vérifie si le rayon a touché cet objet
                // Si l'objet a la clé et que le joueur n'a pas déjà la clé
                if (hasKey && !player.GetComponent<PlayerMovement>().Has_Key_1) {
                    // Fait disparaître l'objet
                    gameObject.SetActive(false);
                    // Modifie la variable Has_Key du joueur en True
                    player.GetComponent<PlayerMovement>().Has_Key_1 = true;
                }
            }
        }
    }
}

