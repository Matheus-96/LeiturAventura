using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerCallEvent : MonoBehaviour
{
    public UnityEvent onEvent;
    public string tag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tag))
        {
            onEvent?.Invoke();
        }
    }
}
