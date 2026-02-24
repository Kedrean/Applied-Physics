using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 200f;
    public Transform playerBody;

    float xRotation = 0f;
    bool cursorLocked = true;

    void Start()
    {
        LockCursor();
    }

    void Update()
    {
        // Toggle cursor lock with Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLocked = !cursorLocked;
            if (cursorLocked) LockCursor();
            else UnlockCursor();
        }

        // Aggressively lock cursor if it's unlocked accidentally
        if (cursorLocked && Cursor.lockState != CursorLockMode.Locked)
        {
            LockCursor();
        }

        // Mouse movement
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}