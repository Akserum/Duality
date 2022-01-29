using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Core Gameplay with InterractableObj + currentObj
    [SerializeField] private InteractableObject[] interactableObjects;
    [SerializeField] private int currentObjectiveNumber = 0;
    [SerializeField] private InteractableObject currentObjective;
    [SerializeField] private PickUpObject pickUpObject;
    //UI
    [SerializeField] private TextMeshProUGUI objective;
    [SerializeField] private GameObject renderActions;
    [SerializeField] private TextMeshProUGUI choixGentil;
    [SerializeField] private TextMeshProUGUI choixMechant;
    //Si le joueur est gentil ou mechant
    [SerializeField] private float moralite;
    [SerializeField] private Slider moraliteSlider;
    //fov pour savoir si le joueur est vu
    [SerializeField] private FieldOfView fov;
    [SerializeField] private PlayerInput playerInput;

    void Start()
    {
        moralite = 0.5f;
        moraliteSlider.value = 0.5f;
        playerInput = GameObject.FindObjectOfType<PlayerInput>();
        fov = GameObject.FindObjectOfType<FieldOfView>();
        interactableObjects = GameObject.FindObjectsOfType<InteractableObject>();
        pickUpObject = GameObject.FindObjectOfType<PickUpObject>();
        NextObjective();
    }
    // Update is called once per frame
    void Update()
    {
        if (pickUpObject.getCanPickUp)
        {
            if (pickUpObject.getPickObject.GetComponent<InteractableObject>().task.objectiveName == currentObjective.task.objectiveName)
            {
                print("test");
                renderActions.SetActive(true);
                choixMechant.text = pickUpObject.getPickObject.GetComponent<InteractableObject>().task.mechantChoix;
                choixGentil.text = pickUpObject.getPickObject.GetComponent<InteractableObject>().task.gentilChoix;
                if (playerInput.actions["InteractE"].triggered)
                {
                    //currentObjective.task.mechantAnimation.Play();
                    print("mechant");
                    moralite -= 0.1f;
                    moraliteSlider.value = moralite;
                    NextObjective();
                    renderActions.SetActive(false);
                    return;
                }
                else if (playerInput.actions["InteractQ"].triggered)
                {
                    //currentObjective.task.gentilAnimation.Play();
                    print("gentil");
                    moralite += 0.1f;
                    moraliteSlider.value = moralite;
                    NextObjective();
                    renderActions.SetActive(false);
                    return;
                }
            }
        }
        else if (!pickUpObject.getCanPickUp)
        {
            renderActions.SetActive(false);
        }
        if (fov.canSeePlayer)
        {
            //gameover ici
        }
    }

    private void RandomizeObjective()
    {
        InteractableObject tmpTest;
        do
        {
            tmpTest = interactableObjects[Random.Range(0, interactableObjects.Length)];
        } while (tmpTest == currentObjective);
        currentObjective = tmpTest;
        objective.text = currentObjective.task.objectiveName;
    }
    private void NextObjective()
    {
        if (currentObjectiveNumber == interactableObjects.Length)
        {
            print("fini le jeu");
        }
        else
        {
            currentObjective = interactableObjects[currentObjectiveNumber];
            objective.text = currentObjective.task.objectiveName;
            currentObjectiveNumber += 1;
        }
    }
}
