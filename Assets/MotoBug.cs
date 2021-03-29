
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class MotoBug : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    public GameObject hurtbox;
    public GameObject squishPad;

    //PlayerController pm;

    [Header("Enemy Walker Health")]
    public int health;
    [Header("Enemy Walker Moving Speed")]
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        if (speed <= 0)
        {
            speed = 5.0f;
        }
        if (health <= 0)
        {
            health = 1; //changed health to 1 to simplify the animation triggers; if setting to 3, change "Squished" to a trigger or add a "wait" ienumerator and turn squished off if not dead
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.GetBool("Squished") /*&& !anim.GetBool("MotoBug")*/)
        {
            if (sr.flipX) //switched the speed and -speed to have the enemy facing the right way
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Barrier")
        {
            sr.flipX = !sr.flipX;
        }
    }



    public void IsDead()
    {
        Debug.Log("damage dealt to moto. health = " + health);
        health--;
        anim.SetBool("Squished", true); // i suggest setting "Squished" as a trigger instead of a bool, so the animation plays once

        if (health <= 0)
        {
            anim.SetBool("Dead", true); //this tells the animator that the enemy is dead, keep animation on squished instead of returning to idle state
            rb.velocity = Vector2.zero;
            hurtbox.SetActive(false);
            squishPad.SetActive(false);
            anim.SetBool("Squished", true);
            Destroy(gameObject);

        }

    }


    //public void isSquished() //this is currently unused, as the set anim is being called above
    //{
    //    anim.SetBool("Squished", true);
    //}

    public void FinishedDeath() //this is currenttly not being used, but can be added to either the animator or to the if statement above with a wait ienumerator
    {
        
        Destroy(gameObject);
    }
}

