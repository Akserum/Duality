using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputs))]
[RequireComponent(typeof(CharacterController))]
public class PlayerMovements : MonoBehaviour
{
    //player movements
    [SerializeField] private float speed;
    [SerializeField] private float gravityValue;

    private PlayerInputs _inputs;
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
        _inputs = GetComponent<PlayerInputs>();
        _cc = GetComponent<CharacterController>();
    }

    private void PlayerMotion()
    {
        //movements
        _motion = transform.right * _inputs.MoveX + transform.forward * _inputs.MoveY;
        _movement = _motion * speed * Time.deltaTime;

        //physique de gravité
        if (_cc.isGrounded)
            _verticalSpeed = -gravityValue * 0.25f;
        else
            _verticalSpeed -= gravityValue * Time.deltaTime;

        _movement += _verticalSpeed * Vector3.up * Time.deltaTime;

        _cc.Move(_movement);
    }
}
