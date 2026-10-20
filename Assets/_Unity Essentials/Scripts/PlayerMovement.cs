using UnityEngine;
using UnityEngine.InputSystem; // Klausa using di baris paling atas

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector3 moveDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Memastikan perangkat keyboard terdeteksi
        if (Keyboard.current != null)
        {
            float horizontal = 0f;
            float vertical = 0f;

            // Menggunakan nama properti yang benar (diakhiri dengan 'Key')
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) vertical = 1f;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) vertical = -1f;
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) horizontal = -1f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) horizontal = 1f;

            moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        }
    }

    void FixedUpdate()
    {
        Vector3 nextPosition = rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(nextPosition);
    }
}
