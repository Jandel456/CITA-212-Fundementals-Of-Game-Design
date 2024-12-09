using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float spinSpeed = 100f;

    void Update()
    {
        transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
    }
}