using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private InteractableObject[] interactableObjects;
    void Start()
    {
        interactableObjects = GameObject.FindObjectsOfType<InteractableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
