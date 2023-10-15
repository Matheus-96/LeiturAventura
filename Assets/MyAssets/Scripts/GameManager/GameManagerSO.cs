using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManager", menuName = "Game Manager")]
public class GameManagerSO : ScriptableObject
{
    public delegate void OnPauseEvent();
    public event OnPauseEvent OnPause;

    public delegate void OnPlayerCamera();
    public event OnPlayerCamera OnPlayerCanLook;

    public delegate void OnCollectPointEvent();
    public event OnCollectPointEvent OnCollectPoint;

    [SerializeField]
    private int points;
    public int Points
    {
        get { return points; }
        set
        {
            points = value;
            OnCollectPoint?.Invoke();
        }
    }

    [SerializeField]
    private bool canLook;

    public bool CanLook
    {
        get { return canLook; }
        set {
            canLook = value;
            OnPlayerCanLook?.Invoke();
        }
    }

    [SerializeField]
    private bool paused;

    public bool Paused
    {
        get { return paused; }
        set {
            paused = value;
            OnPause?.Invoke();
        }
    }

    public void AddPoints(int points)
    {
        Points += points;
    }
}
