using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Declaring Constants
    private string WALK = "Walk", RUN = "Run", JUMP = "Jump", CROUCH = "Crouch";
    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";

    //Declaring Variables
    [SerializeField]
    private float moveForce = 10f, jumpForce = 10f;
    private float horizontal, vertical;

    //Declaring components
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;

    
    
    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        //code
    }

    private void FixedUpdate() {
        //Code
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        PlayerMovementKeyboard(horizontal);
        PlayerWalk(horizontal);
        PlayerRun(horizontal);
        PlayerJump();
        PlayerJumpAnimation(vertical);
        PlayerCrouch();
    }

    void PlayerMovementKeyboard(float horizontal)
    {
        transform.position += new Vector3(horizontal, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void PlayerWalk(float horizontal)
    {
        if(horizontal > 0)
        {
            anim.SetBool(WALK, true);
            sr.flipX = false;
        }
        else if(horizontal < 0)
        {
            anim.SetBool(WALK, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK, false);
            anim.SetBool("Run", false);
        }
        
    }

    void PlayerRun(float horizontal)
    {   
        if(Input.GetKey(KeyCode.LeftShift))
        {
            if(horizontal > 0)
        {
            anim.SetBool(RUN, true);
            sr.flipX = false;
        }
        else if(horizontal < 0)
        {
            anim.SetBool(RUN, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK, false);
            anim.SetBool(RUN, false);
        }
        }
    }

    void PlayerJump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void PlayerJumpAnimation(float vertical)
    {
        if(vertical > 0)
        {
            anim.SetBool(JUMP, true);
        }
        else
        {
            anim.SetBool(JUMP, false);
        }
    }

    void PlayerCrouch()
    {
        if(Input.GetKey(KeyCode.C))
        {
            anim.SetBool(CROUCH, true);
        }
        else
        {
            anim.SetBool(CROUCH, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(GROUND_TAG)) {
            isGrounded = true;
        }
    }
}
