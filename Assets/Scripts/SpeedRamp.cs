using UnityEngine;

public class SpeedRamp : MonoBehaviour
{
    [SerializeField] private float acceleration = 500f;
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<RagdollSwitch>()) return;

        Rigidbody rb = collision.gameObject.GetComponentInParent<Rigidbody>();

        float force = rb.mass * acceleration; // F = m * a
        rb.AddForce(Vector3.forward * force, ForceMode.Force);
    }
}
