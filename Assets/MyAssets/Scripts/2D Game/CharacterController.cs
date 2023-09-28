using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sprite;
    bool grounded = false;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float walkDirection = Input.GetAxis("Horizontal");
        if (walkDirection != 0)
        {
            sprite.flipX = walkDirection < 0 ? true : false;
            transform.Translate(walkDirection * Time.deltaTime * 3, 0, 0);
        }
        animator.SetFloat("speed", Mathf.Abs(walkDirection));


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Land"))
        {
            grounded = true;
        }
    }
}
