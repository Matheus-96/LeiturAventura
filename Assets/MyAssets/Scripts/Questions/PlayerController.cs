using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum States
    {
        QUESTION,
        ACTION
    }
    public States currentState = States.ACTION;
    public BalloonController balloonController;
    public QuestionController questionController;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    RaycastHit2D hit;
    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            hit = Physics2D.Raycast(mousepos, Vector2.zero);

            if (hit.collider)
            {
                Debug.Log(hit.collider);
            }
        }

    }


}
