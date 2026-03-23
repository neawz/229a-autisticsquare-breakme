using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Orbit")]
    [SerializeField] private float distance = 5f;
    [SerializeField] private float sensitivity = 0.3f;
    [SerializeField] private float minY = -20f;
    [SerializeField] private float maxY = 60f;

    [Header("Smoothing")]
    [SerializeField] private float followSmooth = 10f;
    [SerializeField] private float rotateSmooth = 10f;

    private float yaw;
    private float pitch;
    private Vector3 currentPos;
    private Quaternion currentRot;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        currentPos = transform.position;
        currentRot = transform.rotation;
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector2 mouseDelta = Mouse.current.delta.ReadValue();
        yaw += mouseDelta.x * sensitivity;
        pitch -= mouseDelta.y * sensitivity;
        pitch = Mathf.Clamp(pitch, minY, maxY);

        Quaternion targetRot = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 targetPos = target.position - targetRot * Vector3.forward * distance;

        // Smooth
        currentPos = Vector3.Lerp(currentPos, targetPos, followSmooth * Time.deltaTime);
        currentRot = Quaternion.Slerp(currentRot, targetRot, rotateSmooth * Time.deltaTime);

        transform.position = currentPos;
        transform.rotation = currentRot;
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}