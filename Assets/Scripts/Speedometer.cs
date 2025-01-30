using UnityEngine;

public class Speedometer : MonoBehaviour
{
    public Rigidbody playerRigidbody; // Assign the Rigidbody in the Inspector.
    public float speed;    // Speed will be displayed in the Inspector.

    void Update()
    {
        // Calculate speed as magnitude of velocity.
        speed = playerRigidbody.linearVelocity.magnitude;
    }
}
