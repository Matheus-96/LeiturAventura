using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;

    public GameObject PanelUI;
    public GameObject CanvasUI;
    public GameObject questionsPanelUI;
    public GameObject statementPanelUI;
    public QuestionController questionController;

    private void Awake()
    {
        Instance = this;
    }



    void ShowUI()
    {
        PanelUI.SetActive(true);
        questionsPanelUI.SetActive(true);
        statementPanelUI.SetActive(true);
    }
    public void DisableUI()
    {
        PanelUI.SetActive(false);
        questionsPanelUI.SetActive(false);
        statementPanelUI.SetActive(false);
    }
    public void ShowQuestion()
    {
        ShowUI();
        questionController.ShowRandomQuestionOnScreen();
    }
}
