using UnityEngine;

public class RagdollSwitch : MonoBehaviour
{
    [Header("Ragdoll Target")]
    [SerializeField] private Transform hipsTransform;

    private Rigidbody[] rb;
    private Collider[] boneColliders;
    private PlayerController playerController;
    private CameraController cameraController;

    void Awake()
    {
        rb = GetComponentsInChildren<Rigidbody>();
        boneColliders = GetComponentsInChildren<Collider>();
        playerController = GetComponent<PlayerController>();
        cameraController = Camera.main.GetComponent<CameraController>();

        DisableRagdoll();
    }

    public void EnableRagdoll()
    {
        playerController.enabled = false;

        foreach (var rb in rb)
        {
            rb.isKinematic = false;
            rb.detectCollisions = true;
        }

        foreach (var col in boneColliders)
            col.enabled = true;

        // บอกกล้องให้เปลี่ยน target มาติดตาม Hips
        cameraController?.SetTarget(hipsTransform);
    }

    void DisableRagdoll()
    {
        foreach (var rb in rb)
        {
            rb.isKinematic = true;
            rb.detectCollisions = false;
        }

        foreach (var col in boneColliders)
            col.enabled = false;
    }
}