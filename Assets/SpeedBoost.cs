using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{

    private PlayerController thePlayer;
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine("speedBoost");
        }
    }

    IEnumerator speedBoost()
    {
        thePlayer.speed *= 2;
        yield return new WaitForSeconds(duration);
        thePlayer.speed = thePlayer.dfltSpeed;
        Destroy(gameObject);
    }
}
