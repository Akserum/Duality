using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPov : MonoBehaviour
{
    private FieldOfView _fov;

    private void Start()
    {
        _fov = GetComponentInParent<FieldOfView>();
    }

    public void ResetEvent()
    {
        _fov.ResetNpcFov();
    }
}
