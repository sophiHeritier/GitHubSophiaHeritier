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

        void Update()
        {
            transform.Rotate(new Vector3(0, 100, 0) * Time.deltaTime);


        }
    }
}
