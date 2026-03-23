using UnityEngine;

public class RagdollTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered ragdoll trigger");
            RagdollSwitch ragdollSwitch = other.GetComponentInParent<RagdollSwitch>();
            if (ragdollSwitch != null)
            {
                ragdollSwitch.EnableRagdoll();
            }
        }
    }
}
