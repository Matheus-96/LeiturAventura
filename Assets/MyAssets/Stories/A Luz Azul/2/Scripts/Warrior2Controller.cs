using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior2Controller : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void EndScene()
    {
        animator.SetBool("endedScene", true);
    }
}
