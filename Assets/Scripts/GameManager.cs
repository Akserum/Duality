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
    [SerializeField] private TextMeshProUGUI choixGentilControls;
    [SerializeField] private TextMeshProUGUI choixMechant;
    [SerializeField] private TextMeshProUGUI choixMechantControls;

    //Si le joueur est gentil ou mechant
    [SerializeField] private float moralite;
    [SerializeField] private Slider moraliteSlider;
    //fov pour savoir si le joueur est vu
    [SerializeField] private FieldOfView fov;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private string currentInput;
    void LateUpdate()
    {
        if (playerInput.currentControlScheme != currentInput)
        {
            currentInput = playerInput.currentControlScheme;
            if (currentInput.ToString()=="Keyboard and Mouse")
            {
                print("keyboard");
                choixGentilControls.text = "A";
                choixMechantControls.text = "E";
            }
            else if (currentInput.ToString() == "Gamepad")
            {
                print("gamepad");
                choixGentilControls.text = "A";
                choixMechantControls.text = "B";
            }
        }
    }
    void Start()
    {
        Time.timeScale = 1f;
        moralite = 0.5f;
        moraliteSlider.value = 0.5f;
        playerInput = GameObject.FindObjectOfType<PlayerInput>();
        currentInput = playerInput.currentControlScheme;
        fov = GameObject.FindObjectOfType<FieldOfView>();
        pickUpObject = GameObject.FindObjectOfType<PickUpObject>();
        NextObjective();
    }
    void Update()
    {
        print("update");
        if (pickUpObject.getCanPickUp)
        {
            print(pickUpObject.getCanPickUp);
            if (pickUpObject.getPickObject.GetComponent<InteractableObject>().task.objectiveName == currentObjective.task.objectiveName)
            {
                print("derniere cond");
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
            Time.timeScale = 0f;
            //fin jeu

        }
        else
        {
            if (currentObjectiveNumber != 0)
            {
                currentObjective.GetComponentInChildren<Transform>().GetChild(0).gameObject.SetActive(false);
            }
            currentObjective = interactableObjects[currentObjectiveNumber];
            objective.text = currentObjective.task.objectiveName;
            currentObjective.GetComponentInChildren<Transform>().GetChild(0).gameObject.SetActive(true);
            currentObjectiveNumber += 1;
        }
    }
}
