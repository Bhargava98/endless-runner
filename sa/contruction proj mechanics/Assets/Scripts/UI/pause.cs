using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour {
    bool isPaused = false;
    public GameObject pauseMenu;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPaused == false)
            {
                Time.timeScale = 0;
                isPaused = true;
                //Cursor.visible = true;
                pauseMenu.SetActive(true);
            }

            else
            {
                pauseMenu.SetActive(false);
                //Cursor.visible = false;

                isPaused = false;
                Time.timeScale = 1;
            }
        }
    }
    public void resume()
    {
        pauseMenu.SetActive(false);
        //Cursor.visible = false;

        isPaused = false;
        Time.timeScale = 1;
    }
    public  void restart()
    {
        SceneManager.LoadScene("testScene");
    }
}

   

