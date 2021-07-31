using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveForce = 10f;
    [SerializeField] float jumpForce = 10f;
    private float movementX;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private string walkAnimation = "walk";
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        animatePlayer();
        playerJump();
    }
    private void FixedUpdate()
    {
       
    }
    public void movePlayer()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        Vector3 movePos = new Vector3(movementX, 0,0);
        transform.position += moveForce * Time.deltaTime * movePos;
    }
    public void animatePlayer()
    {
        if(movementX > 0)
        {
            sr.flipX = false;
            anim.SetBool(walkAnimation, true);
        }
        else if(movementX < 0)
        {
            sr.flipX = true;
            anim.SetBool(walkAnimation, true);
        }
        else
        {
            anim.SetBool(walkAnimation, false);
        }
    }
    public void playerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
