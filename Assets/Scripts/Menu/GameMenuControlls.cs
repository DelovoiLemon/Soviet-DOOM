using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMenuControlls : MonoBehaviour
{
    public GameObject menu;
    bool state = false;
    // Start is called before the first frame update
    void Start()
    {
         //= new GameObject("GameMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey (KeyCode.Escape)) state = true;
        if(state)
        {
            menu.transform.gameObject.SetActive(true);
            if (Input.GetKey (KeyCode.Y))
            {
                state = false;
                menu.transform.gameObject.SetActive(false);
                SceneManager.LoadScene("Menu");
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;   
            }
            else if (Input.GetKey (KeyCode.N))
            {
                state = false;
            }
        }
    }
}
