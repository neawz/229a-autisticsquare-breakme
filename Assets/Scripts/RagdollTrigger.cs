using UnityEngine;

public class RagdollTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RagdollSwitch ragdollSwitch = other.GetComponent<RagdollSwitch>();
            if (ragdollSwitch != null)
            {
                ragdollSwitch.EnableRagdoll();
            }
        }
    }
}
