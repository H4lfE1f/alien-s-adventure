using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astro : MonoBehaviour
{
    [SerializeField] public float speed = 3f; //скорость персонажа
    [SerializeField] public int lives = 3; //количество жизней
    [SerializeField] public float jumpforce = 0.5f; //сила прыжка
    private bool isGrounded = false;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate() {
        CheckGround();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        Run();
        if (isGrounded && Input.GetButton("Jump"))
        Jump();
    }
    private void Run ()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }
    private void Jump()
    {
        rb.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
    }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("TRIGGER!");
    }
}

