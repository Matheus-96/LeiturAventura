using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sprite;
    GameManagerSO gameManager;
    bool canControl = true;
    bool grounded = false;
    public GameObject pointsPrefab;
    public AudioClip jumpSound;
    public UnityEvent onDie;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = Resources.Load<GameManagerSO>("General/GameManager");
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetCanControl(bool state)
    {
        canControl = state;
    }

    private void Update()
    {
        if (canControl)
        {
            if (SimpleInput.GetButton("action"))
            {
                if (grounded)
                {
                    audioSource.PlayOneShot(jumpSound);
                    grounded = false;
                    rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                }
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canControl)
        {
            float walkDirection = SimpleInput.GetAxis("Horizontal");
            if (walkDirection != 0)
            {
                sprite.flipX = walkDirection < 0 ? true : false;
                transform.Translate(walkDirection * Time.deltaTime * 3, 0, 0);
            }
            animator.SetFloat("speed", Mathf.Abs(walkDirection));
        }
    }

    private async void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Land"))
        {
            grounded = true;
        }

        if (collision.collider.CompareTag("Enemy"))
        {
            Hurt(collision);
            LoseCoinsOrDie();
        }

        if (collision.collider.CompareTag("Trampoline"))
        {
            float highestYLocal = collision.collider.bounds.max.y;
            float highestYGlobal = collision.collider.transform.TransformPoint(new Vector3(0, highestYLocal, 0)).y;

            if (highestYGlobal < transform.position.y)
                rb.AddForce(Vector3.up * 10, ForceMode2D.Impulse);
        }
    }

    async void Hurt(Collision2D collision)
    {
        float direction = collision.transform.position.x - transform.position.x;
        direction = direction < 0 ? 2 : -2;
        rb.freezeRotation = false;
        canControl = false;
        rb.AddForce(new Vector2(direction, 2f), ForceMode2D.Impulse);
        rb.AddTorque(-direction, ForceMode2D.Impulse);
        await Task.Delay(1000);
        transform.rotation = Quaternion.identity;
        canControl = true;
        rb.freezeRotation = true;
    }

    void LoseCoinsOrDie()
    {
        int points = gameManager.Points;
        int lostPoints = 0;

        switch (points)
        {
            case 0:
                Die();
                break;
            case >10:
                lostPoints = Mathf.FloorToInt(points * 0.3f);
                break;
            default:
                lostPoints = points;
                break;
        }
        gameManager.Points = points - lostPoints;
        SpawnPoints(lostPoints);
    }

    void Die() {
        canControl = false;
        onDie?.Invoke();
    }

    void SpawnPoints(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(pointsPrefab, transform.position, Quaternion.identity, null);
        }
    }
}
