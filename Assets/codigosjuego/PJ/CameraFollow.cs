using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;               // El jugador
    public Vector3 offset = new Vector3(0f, 6f, -10f); // Posición fija detrás del jugador
    public float smoothSpeed = 0.125f;     // Suavizado del movimiento

    [Header("Configuración de Altura")]
    public bool seguirEnY = false;        // Desactivado: la cámara NO subirá/bajará cuando el jugador salte

    private float fixedYPosition;

    void Start()
    {
        // Guarda la altura Y inicial deseada
        fixedYPosition = transform.position.y;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Tomamos la posición objetivo en el mundo (ignorando la rotación de la pelota)
            Vector3 desiredPosition = target.position + offset;

            // Si no queremos que siga los saltos, congelamos la altura Y
            if (!seguirEnY)
            {
                desiredPosition.y = fixedYPosition;
            }

            // Transición suave hacia la nueva posición
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
    }
}