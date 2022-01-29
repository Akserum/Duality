using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    private float _moveX, _moveY;
    private float _mouseX, _mouseY;

    private bool _interact;

    //Proprietes 
    public float MoveX => _moveX;
    public float MoveY => _moveY;
    public float MouseX => _mouseX;
    public float MouseY => _mouseY;

    public bool Interact => _interact;

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

        _interact = Input.GetMouseButtonDown(0);
    }
}
