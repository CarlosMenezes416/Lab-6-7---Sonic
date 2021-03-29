using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{

    //public int damageToDeal; //not used

    private Rigidbody2D theRB2D;
    public float bouceForce;
    public PlayerController pc;


    // Start is called before the first frame update
    void Start()
    {
        theRB2D = gameObject.GetComponentInParent<Rigidbody2D>();
        pc = GetComponentInParent<PlayerController>();

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Squished")
        {
            Debug.Log("damage box entered"); //added to ensure that the stomper colider was detecting damage

            theRB2D.AddForce(transform.up * bouceForce, ForceMode2D.Impulse); // this is not currently adding any force, consider possibly replacing this.

            other.gameObject.GetComponentInParent<MotoBug>().IsDead(); //this line needed to be fixed, as is was causing a "no reference set" error  


        }


    }
}