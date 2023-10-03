using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollisionCallEvent : MonoBehaviour
{
    public UnityEvent onEvent;
    public string tag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(tag))
        {
            onEvent?.Invoke();
        }
    }
}
