using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InteractableObject[] interactableObjects;
    [SerializeField] private InteractableObject currentObjective;
    [SerializeField] private TextMeshProUGUI objective;
    void Start()
    {
        interactableObjects = GameObject.FindObjectsOfType<InteractableObject>();
        randomizeObjective();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void randomizeObjective()
    {
        InteractableObject tmpTest;
        do
        {
            tmpTest = interactableObjects[Random.Range(0, interactableObjects.Length)];
        } while (tmpTest == currentObjective);
        currentObjective = tmpTest;
        objective.text = currentObjective.task.objectiveName;
    }
}
