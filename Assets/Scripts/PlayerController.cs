using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 120f;
    private InputAction moveAction;
    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        transform.Translate(moveInput.y * moveSpeed * Time.deltaTime * Vector3.forward);
        transform.Rotate(moveInput.x * rotationSpeed * Time.deltaTime * Vector3.up);
    }
}
