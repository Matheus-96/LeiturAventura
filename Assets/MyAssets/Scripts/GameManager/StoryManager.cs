using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{

    public StoryFlowSO flow;

    private void Awake()
    {

    }

    public void HandleGoToNextScene()
    {
        foreach(LevelSO level in flow.Levels)
        {
            Debug.Log(level.name);
            if (!level.CompletedGame)
            {
                SceneManager.LoadScene(level.SceneGame.name);
                break;
            }
            else if (!level.CompletedBook)
            {
                SceneManager.LoadScene(level.SceneBook.name);
                break;
            }
        }
    }
}
