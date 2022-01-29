using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    private float _moveX, _moveY;
    private float _mouseX, _mouseY;

    private bool _pickUp;
    private bool _interact;

    //Properties 
    public float MoveX => _moveX;
    public float MoveY => _moveY;
    public float MouseX => _mouseX;
    public float MouseY => _mouseY;

    public bool PickUp => _pickUp;

    void Update()
    {
        GetPlayerInputs();
    }

    private void GetPlayerInputs()
    {
        _moveX = Input.GetAxis("Horizontal");
        _moveY = Input.GetAxis("Vertical");
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");

        _pickUp = Input.GetMouseButtonDown(0);
        _interact = Input.GetButtonDown("Interact");
    }
}
