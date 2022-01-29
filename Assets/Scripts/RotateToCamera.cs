using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCamera : MonoBehaviour
{
    [SerializeField] private Transform cam;

    private void Update()
    {
        RotateWSC();
    }

    private void RotateWSC()
    {
        transform.LookAt(cam.transform);
    }
}
    