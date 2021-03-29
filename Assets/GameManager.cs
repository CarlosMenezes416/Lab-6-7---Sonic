using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public PlayerController thePlayer;
    private Vector2 playerStart;

    public GameObject victoryScreen;
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        playerStart = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Victory()
    {
        victoryScreen.SetActive(true);
        Time.timeScale = 0;
        //thePlayer.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
        //thePlayer.gameObject.SetActive(false);
    }

    public void Reset()
    {
        victoryScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        thePlayer.gameObject.SetActive(true);
        thePlayer.transform.position = playerStart;
    }
}
