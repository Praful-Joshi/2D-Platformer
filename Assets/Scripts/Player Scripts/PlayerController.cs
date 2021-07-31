using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerController : MonoBehaviour
{

    //Declaring Constants
    private string WALK = "Walk", RUN = "Run", CROUCH = "Crouch", GROUNDED = "Grounded", JUMP = "Jump";
    private string GROUND_TAG = "Ground";

    //Declaring Variables
    [SerializeField]
    private float moveForce, jumpForce = 10f;
    private bool isGrounded;
    internal bool hasKey = false;
    private float horizontal;
    public int health = 100, lives = 2;

    //Declaring components
    private Rigidbody2D myBody;
    private Transform myTransform;
    private SpriteRenderer sr;
    internal Animator anim;
    public TMPController tMPController;
    public LevelController levelController;


    // Start, Awake, Update etc.
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
    }

    void Start()
    {
        //code
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        PlayerMovementKeyboard(horizontal);

        if (Input.GetKey(KeyCode.LeftShift))
            moveForce = 9f;
        else
            moveForce = 3f;

        HorizontalMovement();
        PlayerCrouch();
    }

    private void LateUpdate()
    {
        CheckWhereToFace();
    }


    // Player Movement & Animations
    void PlayerMovementKeyboard(float horizontal)
    {
        transform.position += new Vector3(horizontal, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void HorizontalMovement()
    {
        if (horizontal == 0)
        {
            anim.SetBool(WALK, false);
            anim.SetBool(RUN, false);
        }
        if (horizontal != 0 && moveForce == 3f)
            anim.SetBool(WALK, true);

        if (horizontal != 0 && moveForce == 9f)
            anim.SetBool(RUN, true);
        else
            anim.SetBool(RUN, false);
    }

    void CheckWhereToFace()
    {
        if (horizontal > 0)
            sr.flipX = false;
        else if (horizontal < 0)
            sr.flipX = true;
    }

    void PlayerJump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
            anim.SetTrigger(JUMP);
            isGrounded = false;
        }
        anim.SetBool(GROUNDED, isGrounded);
    }

    void PlayerCrouch()
    {
        if (Input.GetKey(KeyCode.C))
        {
            anim.SetBool(CROUCH, true);
        }
        else
        {
            anim.SetBool(CROUCH, false);
        }
    }


    // Interactable functions
    public void PickUpKey()
    {
        hasKey = true;
        StartCoroutine(tMPController.KeyReceive());
    }

    // Collision check
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
    }
}
