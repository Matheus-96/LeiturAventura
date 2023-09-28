using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Story Flow", menuName = "Story Management/Story Flow")]
public class StoryFlowSO : ScriptableObject
{
    [SerializeField]
    private List<LevelSO> levels;

    public List<LevelSO> Levels
    {
        get { return levels; }
    }
}
