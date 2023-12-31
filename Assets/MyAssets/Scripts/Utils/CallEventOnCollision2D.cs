using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CallEventOnCollision2D : MonoBehaviour
{

    public string tag;

    [Serializable]
    public class MyEventType : UnityEvent { }

    public MyEventType OnEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(tag))
        {
            OnEvent?.Invoke();
        }
    }
}
