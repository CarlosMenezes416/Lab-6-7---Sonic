using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
//[RequireComponent(typeof(Rigidbody2D))] a rigid body is not needed, as the turret is stationary, simply use a collision box and sprite transform, projectiles will require a rigid body


public class EnemyTurret : MonoBehaviour
{
    [Header("Enemy Turret Health")]
    public int health;


    [Header("Enemy Projectile Rates")]
    public float projectileForce;
    public float projectileFirerate;
    float fireRate;



    [Header("Enemy To Player Distance Checker")]
    public float distance;
    public float maxRange;
    //float timeSinceLastFire = 0.0f;


    [Header("Player & Enemy GameObject")]
    //public GameObject Enemy; //you do not have to reference the GameObject the script is attached to
    public GameObject Player;


    [Header("Enemy Projectile")]
    public Animator anim;
    public GameObject projectilePrefab; //must be set to GameObject, not Projectile, or you cannopt set in the inpector
    public Transform projectileSpawnPointLeft;
    public Transform projectileSpawnPointRight;

    [Header("Enemy Sprite & Anim")]
    SpriteRenderer sr;
    //bool isIdle;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        //isIdle = true;
        //hasFired = false;

        //Enemy Projectile Force
        if (projectileForce <= 0)
        {
            projectileForce = 100.0f; // increased the force applied
        }
        //Turret Enemy Health
        if (health <= 0)
        {
            health = 5;
        }


    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(Player.transform.position, transform.position);
        //Debug.Log("player is " + distance + "away from turret");

        ////Turret Idles
        //if (distance > maxRange && !isIdle)
        //{
        //    //ReturnToIdle();
        //}

        // Turret In Range
        if (distance < maxRange)
        {
            fireRate -= Time.deltaTime; //if in range, start shoot timer
                                        //Debug.Log("fire timer: " + fireRate);

            //isIdle = false;

            //Turret Shoots Left
            if (Player.transform.position.x < transform.position.x)
            {
                //Debug.Log("shooting left");

                //flip sprite to face left if facing right
                if (!sr.flipX)
                {
                    sr.flipX = true;
                }

                if (fireRate <= 0f) //fires one projectile when shoot timer reaches 0
                {
                    Fire();
                    fireRate = 2f; //Resets the time after one projectile
                }


            }
            //Turret Shoots Right
            else
            {
                //Debug.Log("shooting right");

                //flip sprite to face right if facing left
                if (sr.flipX)
                {
                    sr.flipX = false;
                }

                if (fireRate <= 0f) //fires one projectile when shoot timer reaches 0
                {
                    Fire();
                    fireRate = 2f; //Resets the time after one projectile
                }
            }
        }
    }

    //Turret Projectile Fire Function
    public void Fire()
    {
        //anim.SetTrigger("Fire"); //the current "fire" animation is wrong
        if (transform.position.x > Player.transform.position.x)
        {
            //Projectile temp = Instantiate(projectilePrefab, projectileSpawnPointLeft.position, projectileSpawnPointLeft.rotation);
            //temp.speed = -projectileForce;

            GameObject temp = Instantiate(projectilePrefab, projectileSpawnPointLeft.transform.position, Quaternion.identity) as GameObject;
            temp.GetComponent<Rigidbody2D>().AddForce(Vector2.left * projectileForce, ForceMode2D.Force); //applies projectile force left


        }
        else
        {
            //Projectile temp = Instantiate(projectilePrefab, projectileSpawnPointRight.position, projectileSpawnPointRight.rotation);
            //temp.speed = projectileForce;

            GameObject temp = Instantiate(projectilePrefab, projectileSpawnPointRight.transform.position, Quaternion.identity) as GameObject;
            temp.GetComponent<Rigidbody2D>().AddForce(Vector2.right * projectileForce, ForceMode2D.Force);//applies projectile force right

        }


    }

    #region UNUSED CODE
    //public void ReturnToIdle()
    //{
    //    //anim.SetBool("Fire", false);
    //    //anim.SetBool("FireLeft", false);
    //    //anim.SetBool("Idle", true); // currently no idle bool in projectile animator
    //    anim.SetTrigger("Idle");
    //    isIdle = true;
    //    Debug.Log("Player: Not Detected By Enemy");
    //}


    //the below code is not needed
    //public void FireLeft()
    //{
    //    anim.SetBool("Fire", false);
    //    anim.SetBool("FireLeft", true);
    //    Debug.Log("Enemy: DetectedLeft");
    //}

    //public void FireRight()
    //{
    //    anim.SetBool("FireLeft", false);
    //    anim.SetBool("Fire", true);
    //    Debug.Log("Enemy: DetectedRIght");
    //}
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health--;
            //Destroy(collision.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

    }



}