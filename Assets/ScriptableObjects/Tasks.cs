using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tasks", menuName = "ScriptableObjects/TasksScriptableObject", order = 1)]
public class Tasks : ScriptableObject
{
    public string objectiveName;
    public string firstChoice;
    public string secondChoice;
    public Animation firstAnimation;
    public Animation secondAnimation;
}
