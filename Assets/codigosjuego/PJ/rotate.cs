using UnityEngine;

public class rotate : MonoBehaviour
{
    
    void Update()
    {
        transform.Rotate(new Vector3(0, 100, 0) * Time.deltaTime);


    }
}
