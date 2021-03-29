using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public void Replay()
    {
        Time.timeScale = 1;
        FindObjectOfType<GameManager>().Reset();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //public void PauseLevel()
    //{
    //    if (Input.GetKeyDown("p"))
    //    {

    //    }
    //}
}