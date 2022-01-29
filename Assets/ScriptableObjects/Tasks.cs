using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tasks", menuName = "ScriptableObjects/TasksScriptableObject", order = 1)]
public class Tasks : ScriptableObject
{
    public string objectiveName;
    public string gentilChoix;
    public string mechantChoix;
    public Animation gentilAnimation;
    public Animation mechantAnimation;
}
