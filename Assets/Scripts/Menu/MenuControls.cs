using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuControls : MonoBehaviour
{
    public int difficulty = 0;


    public void PlayPressed()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        switch(difficulty)
        {
            case 0:
                SceneManager.LoadScene("Game");
                break;
            
            
            case 1:
                SceneManager.LoadScene("Map Hard");
                break;
        }
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
