using UnityEngine;
using UnityEngine.UI;

public class KeyIconController : MonoBehaviour
{
    public GameObject playerObject; // Référence vers le GameObject Player
    public GameObject keyIcon; // Référence vers l'objet Image représentant l'icône de la clé

    private PlayerMovement playerMovement; // Référence vers le script PlayerMovement

    void Start()
    {
        // Récupérer le composant PlayerMovement du GameObject Player
        playerMovement = playerObject.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        // Vérifier si le joueur a la clé 2 et activer ou désactiver l'icône en conséquence
        if (playerMovement != null && keyIcon != null)
        {
            keyIcon.SetActive(playerMovement.Has_Key_2);
        }
    }
}
