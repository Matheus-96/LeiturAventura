using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class levelStep
{
    public UnityEvent action;
    public bool isDone;
}

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    public List<levelStep> levelFlow = new List<levelStep>();
    public GameObject PanelUI;
    public Animator panelAnimator;
    public GameObject CanvasUI;
    public GameObject questionsPanelUI;
    public GameObject statementPanelUI;
    public QuestionController questionController;


    private void Awake()
    {
        
        Instance = this;
        panelAnimator = PanelUI.GetComponent<Animator>();
    }


    public void DoNextStep()
    {
        foreach(levelStep step in levelFlow)
        {
            if(!step.isDone)
            {
                step.action.Invoke();
                break;
            }
        }
    }

    public void MarkCurrentStepAsDone()
    {
        foreach (levelStep step in levelFlow)
        {
            if (!step.isDone)
            {
                step.isDone = true;
                break;
            }
        }
    }
    void ShowUI()
    {
        panelAnimator.SetBool("Showing", true);
        /*
         * PanelUI.SetActive(true);
        questionsPanelUI.SetActive(true);
        statementPanelUI.SetActive(true);
        */
    }
    public void DisableUI()
    {
        panelAnimator.SetBool("Showing", false);
        /*
         * PanelUI.SetActive(false);
        questionsPanelUI.SetActive(false);
        statementPanelUI.SetActive(false);
        */
    }
    public void ShowQuestion()
    {
        ShowUI();
        questionController.ShowRandomQuestionOnScreen();
    }
}
