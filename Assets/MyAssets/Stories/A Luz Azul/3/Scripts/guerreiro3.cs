using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guerreiro3 : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void EndScene()
    {
        animator.SetBool("endedScene", true);
    }
}
