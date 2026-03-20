using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Transform playerPos;
    [SerializeField] private Vector3 offset = new Vector3(0, 1, -5);

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform;
        transform.position = playerPos.position + offset;
    }
}
