using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public GameObject playerObject; // Référence vers le GameObject Player
    public Text infoText; // Référence vers le Text UI Component

    void Update()
    {
        if (playerObject != null && infoText != null)
        {
            // Récupérer la variable publique du GameObject Player et l'afficher dans le Text UI Component
            PlayerMovement playerController = playerObject.GetComponent<PlayerMovement>();
            if (playerController != null)
            {
                infoText.text = "Has Key 1: " + (playerController.Has_Key_1 ? "Yes" : "No");
                infoText.text += "\nHas Key 2: " + (playerController.Has_Key_2 ? "Yes" : "No");
                // Ajoutez d'autres informations sur le joueur ici en concaténant les chaînes de caractères
            }
        }
    }
}
