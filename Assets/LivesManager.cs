using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{

    //public int defaultLives;
    public int livesCounter;

    public Text livesText;

    private GameManager theGM;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("CurentLives") >= 3)
        {
            livesCounter = PlayerPrefs.GetInt("CurrentLives"); //lives will stay persistant between saves, consider setting lives to a default value when a new game is started
        }
        else
        {
            livesCounter = 3;
            PlayerPrefs.SetInt("CurrentLives", 3);
        }
        theGM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "x " + livesCounter;

        if (livesCounter < 1)
        {
            theGM.GameOver();
        }
    }

    public void TakeLife()
    {
        livesCounter -= 1;
        PlayerPrefs.SetInt("CurrentLives", livesCounter);
    }

    public void AddLife()
    {
        livesCounter++;
        PlayerPrefs.SetInt("CurrentLives", livesCounter);

    }
}

