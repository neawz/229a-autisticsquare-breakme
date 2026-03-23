using UnityEngine;

public class RagdollSwitch : MonoBehaviour
{
    private Rigidbody[] rb;
    private PlayerController playerController;

    void Awake()
    {
        rb = GetComponentsInChildren<Rigidbody>();
        playerController = GetComponent<PlayerController>();
        DisableRagdoll();
    }

    public void EnableRagdoll()
    {
        Debug.Log("Ragdoll Enabled");
        playerController.enabled = false;

        foreach (var rb in rb)
        {
            rb.isKinematic = false;
        }
    }

    public void DisableRagdoll()
    {
        foreach (var rb in rb)
        {
            rb.isKinematic = true;
        }
    }
}