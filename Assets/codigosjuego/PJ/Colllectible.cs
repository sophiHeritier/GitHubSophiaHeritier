using UnityEngine;


public class Collectible : MonoBehaviour


{
    [Header("Configuración de Rotación")]
    public float rotationSpeed = 180f; // Grados por segundo
    public Vector3 rotationAxis = Vector3.up; // Eje vertical por defecto
    public Space relativeTo = Space.Self; // Girar respecto a sí mismo

    [Header("Configuración de Flotación")]
    public float bobSpeed = 2f;    // Velocidad de oscilación
    public float bobHeight = 0.5f; // Altura máxima

    private Vector3 startPos;      // Posición inicial

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // 1. Rotación continua de 360 grados
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime, relativeTo);

        // 2. Movimiento de arriba a abajo (Flotación)
        float yOffset = Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = new Vector3(startPos.x, startPos.y + yOffset, startPos.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore();
            Destroy(gameObject);
        }
    }

}