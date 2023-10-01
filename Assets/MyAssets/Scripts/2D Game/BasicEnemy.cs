using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    float direction = 1;
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime, 0 , 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ASIM");
        if(collision != null)
        {
            Debug.Log("ASIM2");
            if (collision.gameObject.CompareTag("Barrier"))
            {
            Debug.Log("ASIM3");
                direction *= -1;
                sprite.flipX = direction > 0 ? false : true;
            }
        }
    }
}
