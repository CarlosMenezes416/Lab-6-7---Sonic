using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
 


    private Animator theAnim;
    private bool health;
    private int currentHP;
    public int enemyHP;

    private Collider2D parentCol;
    private Collider2D hurtBox;


    // Start is called before the first frame update
   void Start()
    {
        currentHP = enemyHP;

        theAnim = transform.parent.GetComponent<Animator>();

        parentCol = transform.parent.GetComponent<Collider2D>();
        hurtBox = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP <= 0)
        {
            health = true;
            theAnim.SetBool("Squished", true);
            parentCol.enabled = false;
            hurtBox.enabled = false;
            
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
    }
}
