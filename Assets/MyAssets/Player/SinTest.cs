using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinTest : MonoBehaviour
{
    public float value = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (value > Mathf.PI * 2) value = 0;
        value += Time.deltaTime * 6;
        transform.position = new Vector3(
                (Mathf.Sin(value)/2),
                (Mathf.Sin(value * 2)/4),
                transform.position.z
                );
    }
}
