using UnityEngine;

public class RagdollSwitch : MonoBehaviour
{
    private Rigidbody[] rigidbodies;
    private PlayerController playerController;

    void Awake()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        playerController = GetComponent<PlayerController>();
        DisableRagdoll();
    }

    public void EnableRagdoll()
    {
        playerController.enabled = false;

        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = false;
        }
    }

    public void DisableRagdoll()
    {
        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = true;
        }
    }
}