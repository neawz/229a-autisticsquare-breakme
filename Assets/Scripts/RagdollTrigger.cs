using UnityEngine;

public class RagdollTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!other.CompareTag("Player")) return;
            other.GetComponentInParent<RagdollSwitch>()?.EnableRagdoll();
        }
    }
}
