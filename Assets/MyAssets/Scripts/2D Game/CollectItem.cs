using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectItem : MonoBehaviour
{
    public UnityEvent onCollisionEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                onCollisionEvent?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
