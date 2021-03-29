using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{


    public Animator theAnimator;
    public float speed;
    public float dfltSpeed;
    public float maxSpeed;
    public float jumpForce;
    private bool canMove;
    private Rigidbody2D Sonic;


    public GameManager theGM;
    public LivesManager theLM;



    // Start is called before the first frame update
    void Start()
    {
        theLM = FindObjectOfType<LivesManager>();

        Sonic = GetComponent<Rigidbody2D>();
        theAnimator = GetComponent<Animator>();

        dfltSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D Sonic = GetComponent<Rigidbody2D>();
        float hori = Input.GetAxis("Horizontal");



        if (hori > 0)
        {
            Sonic.velocity = new Vector2(speed, Sonic.velocity.y);
            GetComponent<SpriteRenderer>().flipX = true;
            canMove = true;
        }
        else if (hori < 0)
        {
            Sonic.velocity = new Vector2(speed * -1f, Sonic.velocity.y);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            Sonic.velocity = new Vector2(0f, Sonic.velocity.y);
        }


        if (hori != 0f)
        {
            GetComponent<Animator>().SetBool("MOVING", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("MOVING", false);
        }


    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (canMove)
        {
            Sonic.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Sonic.velocity.y);
        }

    }

    private void OnTriggerEnter2D(Collider2D other) //this now detects the Hurtbox triggers and applies damage
    {
        if (other.gameObject.tag == "Hurtbox")
        {
            Debug.Log("player takes damage from MotoBug");

            theLM.TakeLife();

        }

    }




}

