using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetScript : MonoBehaviour
{
    private Animator _animator;

    private bool _isOpen;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ClosetBool()
    {
        _isOpen = !_isOpen;
        _animator.SetBool("IsOpen",_isOpen);
    }
}
