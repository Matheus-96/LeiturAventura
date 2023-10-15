using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeInRandomDirection : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D collider;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        float randomX = Random.Range(-6, 6);
        rb.AddForce(new Vector2(randomX, 6), ForceMode2D.Impulse);
        StartCoroutine(WaitForTimeout());
    }

    IEnumerator WaitForTimeout()
    {
        yield return new WaitForSeconds(2f);

        collider.excludeLayers = 0;
        collider.isTrigger = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine(StartDespawning());
    }
    IEnumerator StartDespawning()
    {
        yield return new WaitForSeconds(2f);
        int counter = 0;
        while(true)
        {
            if (counter > 10) break;

            spriteRenderer.enabled = !spriteRenderer.enabled;
            counter++;
            yield return new WaitForSeconds(.2f);
        }
        Destroy(gameObject);
    }

}
