using UnityEngine;

public class Colllectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Esta parte es la misma que ya tenías y funciona:
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore();
            Destroy(gameObject); // Al destruirse, el Update deja de ejecutarse.
        }
    }

    public class Collectible : MonoBehaviour
    {
        [Header("Configuración de Rotación")]
        public float rotationSpeed = 180f; // Grados por segundo
        public Vector3 rotationAxis = Vector3.up; // Eje vertical por defecto
        public Space relativeTo = Space.Self; // Girar respecto a sí mismo

        [Header("Configuración de Flotación (Arriba/Abajo)")]
        public float bobSpeed = 2f;    // Velocidad de oscilación
        public float bobHeight = 0.5f; // Altura máxima

        private Vector3 startPos;      // Posición inicial del ancla

        void Start()
        {
            // Guardamos la posición original donde colocamos el ancla
            startPos = transform.position;
        }

        void Update()
        {
            // 1. ROTACIÓN CONTINUA DE 360 GRADOS SIN PARAR
            transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime, relativeTo);

            // 2. FLOTACIÓN (OPCIONAL)
            float yOffset = Mathf.Sin(Time.time * bobSpeed) * bobHeight;
            transform.position = new Vector3(startPos.x, startPos.y + yOffset, startPos.z);
        }
      
    }
}
