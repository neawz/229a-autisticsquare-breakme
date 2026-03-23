using UnityEngine;

public class SpeedRamp : MonoBehaviour
{
    [SerializeField] private Rigidbody torsoRigidbody;
    [SerializeField] private float acceleration = 5f;

    void OlisionStay(Collision collision)
    {
        if (torsoRigidbody == null || torsoRigidbody.isKinematic) return;
        float force = torsoRigidbody.mass * acceleration; // F = m * a
        torsoRigidbody.AddForce(Vector3.forward * force, ForceMode.Force);
    }
}
