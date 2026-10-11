using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [Header("Panel del Menú")]
    public GameObject mainMenuPanel; // Arrastra aquí el panel principal

    void Start()
    {
        // Nos aseguramos de que el tiempo corra con normalidad al arrancar el juego
        Time.timeScale = 1f;
    }

    // Esta función se activará cuando hagas clic en el botón
    public void PlayGame()
    {
        // Desactivamos el panel del menú para que desaparezca de la pantalla
        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(false);
        }
        else
        {
            // Si prefieres poner este script directamente en el panel, se desactiva a sí mismo
            gameObject.SetActive(false);
        }

        // Opcional: Si quieres asegurarte de que el juego empiece a correr sin pausa
        Time.timeScale = 1f;
    }
}