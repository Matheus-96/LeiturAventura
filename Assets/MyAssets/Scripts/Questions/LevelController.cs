using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;

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
