using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    private Animator myAnimator;

    [SerializeField]
    public float movementSpeed;

    private bool facingRight;

    [SerializeField]
    public Transform[] groundPoints;

    [SerializeField]
    public float groundRadius;

    [SerializeField]
    public LayerMask whatIsGround;

    private bool isGrounded;

    private bool jump;

    [SerializeField]
    public float jumpforce;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleInput();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isGrounded = IsGrounded();

        HandleMovement(horizontal);

        flip(horizontal);

        ResetValues();
    }

    private void HandleMovement(float horizontal)
    {
        if (isGrounded && jump)
        {
            isGrounded = false;
            myRigidbody.AddForce(new Vector2(0, jumpforce));

        }

        myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);

        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    private void flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }

    private bool IsGrounded()
    {
        if(myRigidbody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    private void ResetValues()
    {
        jump = false;
    }
}
