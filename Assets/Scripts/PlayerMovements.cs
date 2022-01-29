using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    //player movements
    [SerializeField] private float speed;
    [SerializeField] private float gravityValue;

    private PlayerInput _inputs;
    private CharacterController _cc;

    private Vector3 _motion;
    private Vector3 _movement;
    private float _verticalSpeed;

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        PlayerMotion();
    }

    private void Initialize()
    {
        _inputs = GetComponent<PlayerInput>();
        _cc = GetComponent<CharacterController>();
    }

    private void PlayerMotion()
    {
        transform.localRotation = Quaternion.Euler(0f, _inputs.camera.transform.rotation.eulerAngles.y, 0);
        //movements
        _motion = transform.right * _inputs.actions["Movement"].ReadValue<Vector2>().x + transform.forward * _inputs.actions["Movement"].ReadValue<Vector2>().y;
        _movement = _motion * speed * Time.deltaTime;

        //gravity
        if (_cc.isGrounded)
            _verticalSpeed = -gravityValue * 0.25f;
        else
            _verticalSpeed -= gravityValue * Time.deltaTime;

        _movement += _verticalSpeed * Vector3.up * Time.deltaTime;

        _cc.Move(_movement);
    }
}
