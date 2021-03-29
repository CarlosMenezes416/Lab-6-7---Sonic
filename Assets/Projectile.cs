using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    #region UNUSED CODE
    //public float speed;
    //Rigidbody2D rb;
    //EnemyTurret enemyTurret;

    //private void Awake()
    //{
    //    //rb = GetComponent<Rigidbody2D>();
    //    //enemyTurret = EnemyTurret.FindObjectOfType<EnemyTurret>();
    //    //Debug.Log("Awake");
    //}
    //// Start is called before the first frame update
    //void Start()
    //{
    //    //Debug.Log("Start");

    //}
    #endregion

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("FixedUpdate");
        //Invoke("DestroyProjectile", 1.5f); //destroys the projectile after 1.5 seconds if no collision detected 

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Projectile col with " + col.gameObject.name);
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerController>().theLM.TakeLife();
            //DestroyProjectile();
        }
        Destroy(gameObject);
    }

    //void DestroyProjectile()
    //{
    //    Destroy(gameObject);
    //}



}
