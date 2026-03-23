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
    [SerializeField] private float followSmooth = 10f;  // ความนุ่มตอนตาม target
    [SerializeField] private float rotateSmooth = 10f;  // ความนุ่มตอนหมุน

    private float yaw;    // หมุนซ้าย/ขวา
    private float pitch;  // หมุนขึ้น/ลง
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

        // อ่าน Mouse Delta จาก New Input System
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();
        yaw += mouseDelta.x * sensitivity;
        pitch -= mouseDelta.y * sensitivity;
        pitch = Mathf.Clamp(pitch, minY, maxY);

        // คำนวณ position ที่ต้องการ
        Quaternion targetRot = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 targetPos = target.position - targetRot * Vector3.forward * distance;

        // Smooth
        currentPos = Vector3.Lerp(currentPos, targetPos, followSmooth * Time.deltaTime);
        currentRot = Quaternion.Slerp(currentRot, targetRot, rotateSmooth * Time.deltaTime);

        transform.position = currentPos;
        transform.rotation = currentRot;
    }

    /// เรียกจาก RagdollSwitch ตอน Ragdoll เริ่ม → เปลี่ยน target เป็น Hips bone
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}