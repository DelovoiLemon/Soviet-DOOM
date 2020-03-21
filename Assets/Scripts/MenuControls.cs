using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuControls : MonoBehaviour
{
    public int difficulty = 0;


    public void PlayPressed()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
    public void Difficulty(int m)
    {
        difficulty = m;
    }
}
