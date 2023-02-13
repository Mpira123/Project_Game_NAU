using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    private float mouseX;
    private float mouseY;
    private float sensitivity = 2f;

    float xRotation = 0f;

    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -60f, 60f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(-mouseY * new Vector3(1, 0, 0) * Time.deltaTime);

        Player.Rotate(mouseX * new Vector3(0, 1, 0));
    }
}
