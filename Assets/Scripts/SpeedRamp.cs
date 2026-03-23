using UnityEngine;

public class SpeedRamp : MonoBehaviour
{
    [SerializeField] private float acceleration = 500f;
    void OnCollisionStay(Collision collision)
    {
        RagdollSwitch ragdoll = collision.gameObject.GetComponentInParent<RagdollSwitch>();
        if (ragdoll == null) return;

        Rigidbody rb = collision.gameObject.GetComponentInParent<Rigidbody>();

        float force = rb.mass * acceleration; // F = m * a
        rb.AddForce(Vector3.forward * force, ForceMode.Force);
    }
}
