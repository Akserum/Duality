using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private float mouseSensivity;

    private float refRotation = 0f;

    private PlayerInputs _inputs;

    void Start()
    {
        _inputs = GetComponentInParent<PlayerInputs>();
    }

    void Update()
    {
        PlayerRotation();
    }

    private void PlayerRotation()
    {
        float mouseX = _inputs.MouseX * mouseSensivity * Time.deltaTime;
        float mouseY = _inputs.MouseY * mouseSensivity * Time.deltaTime;

        refRotation -= mouseY;
        refRotation = Mathf.Clamp(refRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(refRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
