using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pausemenucanvas;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            if(paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    void Stop()
    {
        pausemenucanvas.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }
    public void Play()
    {
        pausemenucanvas.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void mainmenubutton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
