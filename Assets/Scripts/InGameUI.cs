using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public GameObject key1_Icon; // Référence vers l'objet Image représentant l'icône de la clé
    public GameObject key2_Icon; // Référence vers l'objet Image représentant l'icône de la clé

    void Start()
    {
        key1_Icon.SetActive(false);
        key2_Icon.SetActive(false);
    }

    void Update()
    {
        // Vérifier si le joueur a la clé 2 et activer ou désactiver l'icône en conséquence
        if (key1_Icon && key2_Icon) {
            key1_Icon.SetActive(PlayerPrefs.GetInt("has_key_1") == 1);
            key2_Icon.SetActive(PlayerPrefs.GetInt("has_key_2") == 1);
        }
    }
}
