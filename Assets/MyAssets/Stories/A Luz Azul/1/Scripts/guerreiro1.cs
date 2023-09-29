using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guerreiro1 : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void EnterTheScene()
    {
        animator.SetBool("enterScene", true);
        LevelController.Instance.MarkCurrentStepAsDone();
        //LevelController.Instance.DoNextStep();
    }

    public void EndingAnimation()
    {
        animator.SetBool("endedScene", true);
        LevelController.Instance.MarkCurrentStepAsDone();
    }
}
