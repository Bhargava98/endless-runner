using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu1 : MonoBehaviour
{
    public string MainMenu;
    public GameManager gm;
    public GameObject pausepanel;
   // public GameObject backButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void pauseGame()
    {
       
        gm.ispaused = true;
        pausepanel.SetActive(true);
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0f;
            
        }
       
    }
    public void resume()
    {
        gm.ispaused = false;
        pausepanel.SetActive(false);
        if (Time.timeScale == 0)
        {
            gm.ispaused = false;
            Time.timeScale = 1f;

        }
    }

    public void menu()
    {
        SceneManager.LoadScene(1);
    }
    public void quit()
    {
        Application.LoadLevel(MainMenu);
    }

}
