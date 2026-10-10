using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;       // Arrastra aquí el objeto del jugador
    public Vector3 offset = new Vector3(0f, 5f, -7f); // Distancia de la cámara respecto al jugador
    public float smoothSpeed = 5f; // Velocidad de suavizado

    void LateUpdate()
    {
        if (player != null)
        {
            // Posición deseada de la cámara
            Vector3 desiredPosition = player.position + offset;

            // Movimiento suave usando Lerp
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            transform.position = smoothedPosition;

            // Opcional: hacer que la cámara siempre mire al jugador
            transform.LookAt(player.position);
        }
    }
}