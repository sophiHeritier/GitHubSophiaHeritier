using UnityEngine;
public class Player : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 12f;
    public float jumpForce = 6f;

    [Header("Estado")]
    public bool isGrounded = false;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // El salto solo se ejecuta si se presiona la tecla de salto Y el jugador está en el suelo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Lectura de ejes (Input.GetAxis)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0f, moveZ) * moveSpeed;
        rb.AddForce(movement, ForceMode.Force);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Detecta contacto con superficies con la Tag Ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Detecta cuando deja de tocar superficies con la Tag Ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detección de recolectables mediante Trigger
        if (other.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            //GameManager.instance.CollectItem();
        }
    }
}