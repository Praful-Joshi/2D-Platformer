using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Declaring Constants
    private string WALK = "Walk";

    //Declaring Variables
    [SerializeField]
    private float moveForce = 10f, jumpForce = 10f;
    private float movementX;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementKeyboard();
        AnimatePlayer();
    }

    void PlayerMovementKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        if(movementX > 0)
        {
            anim.SetBool(WALK, true);
            sr.flipX = false;
        }
        else if(movementX < 0)
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
}
