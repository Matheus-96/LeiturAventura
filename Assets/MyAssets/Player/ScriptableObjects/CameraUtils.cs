using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Camera Utils", menuName = "Camera Utils")]
public class CameraUtils : ScriptableObject
{
    public delegate void CameraPriorityEvent();
    public event CameraPriorityEvent OnChangePriority;

    [SerializeField]
    int cameraPriority;

    public int CameraPriority
    {
        get { return cameraPriority; }
        set
        {
            cameraPriority = value;
            OnChangePriority?.Invoke();
        }
    }

}
