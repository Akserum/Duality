using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClosetScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private Animator _animator;
    private bool _isOpen;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ClosetBool()
    {
        _isOpen = !_isOpen;
        _animator.SetBool("IsOpen", _isOpen);
    }

    public void SetUi()
    {
        text.gameObject.SetActive(true);
    }
}
