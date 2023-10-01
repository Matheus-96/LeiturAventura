using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Scene", menuName = "Story Management/Scene")]
public class LevelSO : ScriptableObject
{
    [SerializeField]
    private SceneAsset sceneGame;

    public SceneAsset SceneGame
    {
        get { return sceneGame; }
        set
        {
            sceneGame = value;
        }
    }

    [SerializeField]
    private SceneAsset sceneBook;

    public SceneAsset SceneBook
    {
        get { return sceneBook; }
        set
        {
            sceneBook = value;
        }
    }

    [SerializeField]
    private bool completedGame;

    public bool CompletedGame
    {
        get { return completedGame; }
        set
        {
            completedGame = value;
        }
    }

    [SerializeField]
    private bool completedBook;

    public bool CompletedBook
    {
        get { return completedBook; }
        set
        {
            completedBook = value;
        }
    }

    [SerializeField]
    private List<Question> questions = new();

    public List<Question> GetQuestions()
    {
        return questions;
    }
    public void SetQuestion(Question question)
    {
        questions.Add(question);
    }

}
