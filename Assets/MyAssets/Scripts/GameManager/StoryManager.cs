using System.Collections;
using System.Collections.Generic;
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
                SceneManager.LoadScene(level.SceneGame);
                break;
            }
            else if (!level.CompletedBook)
            {
                level.CompletedBook = true;
                SceneManager.LoadScene(level.SceneBook);
                break;
            }
        }
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
