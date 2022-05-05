using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astro : MonoBehaviour
{
    [SerializeField] public float speed = 3f; //скорость персонажа
    [SerializeField] public int lives = 3; //количество жизней
    // [SerializeField] public float jumpforce = 0.1f; //сила прыжка
    // private bool isGrounded = false;
    public float jumpHeight;
    private bool isJumping = false;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public static Astro Instance { get; set; }

    private void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        Instance = this;
    }
    
    // Start is called before the first frame update
  
    // private void FixedUpdate() 
    // {
    //     CheckGround();
    // }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        Run();
        // if (isGrounded && Input.GetButton("Jump"))
        // Jump();
        if (Input.GetKeyDown (KeyCode.Space) && !isJumping) // both conditions can be in the same branch
         { 
            rb.AddForce(Vector2.up * jumpHeight); // you need a reference to the RigidBody2D component
            isJumping = true;
          }
    }

    private void Run ()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }



    // private void CheckGround()
    // {
    //     Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
    //     isGrounded = collider.Length > 1;
    // }
    private void OnCollisionEnter2D (Collision2D col)
     {
        if (col.gameObject.tag == "ground") // GameObject is a type, gameObject is the property
        {
            isJumping = false;
            Debug.Log("STAND");
        }
     }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("TRIGGER!");
    }
    
    public void GetDamage()
    {
        lives -=1;
        Debug.Log(lives);
    }
}
