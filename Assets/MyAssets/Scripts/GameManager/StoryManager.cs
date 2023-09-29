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
            if (!level.CompletedGame)
            {
                level.CompletedGame = true;
                SceneManager.LoadScene(level.SceneGame.name);
                break;
            }
            else if (!level.CompletedBook)
            {
                level.CompletedBook = true;
                SceneManager.LoadScene(level.SceneBook.name);
                break;
            }
        }
    }
}
